#!/usr/bin/env bash
#
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
_nth_call_trace() {
    local i=0
    local f=$(mktemp)
    while true
    do
	caller  $i >>$f
	[ $? -ne 0 ] && break
	i=$(expr $i + 1)
    done
    echo "#####          bash stack trace          #####" >&2
    while read -r
    do
	  echo "   --> $REPLY" >&2
    done < $f
    echo "##### ###########################" >&2
    rm -f $f
}

# Write a message to the trace channel
nth_trace() {
    [ -n "${NTH_TRACE:-}" ] && echo "$1" >&3
}

# Write a diagnostic message
# Arg 1 : The message
nth_message() {
    echo "$1" >&2
}

# Exit with an error message
# Arg 1 : The error message
nth_exit() {
    [ -n "$1" ] && nth_message "$1"
    _nth_call_trace
    exit 1
}

nth_check_root() {
    local tst
    local res=1

    tst=$(uname -s)
    if [ "${tst::4}" = "MSYS" ]; then
	tst=$(cygpath -u -a $SYSTEMROOT)
	[ -n "$tst" ] || nth_exit "Cannot resolve SYSTEMROOT environment variable"
	[ -x "$tst/System32/net" ] || nth_exit "Cannot find Windows net.exe"
	"$tst/System32/net" session >/dev/null 2>&1
	res=$?
    else
	test $(id -u) -eq 0
	res=$?
    fi
    return $res
}

nth_ensure_root() {
    nth_check_root || nth_exit "Fatal error. Must run as root."
}

nth_not_implemented() {
    nth_exit "The requested function is not implemented for this OS."
}

nth_test_function() {
    [ $# -ne 1 ] && nth_exit "$FUNCNAME: Expecting function name as  argument."
    [ "$(type -t $1)" = "function" ]
}

nth_ensure_function() {
    nth_test_function $@ || nth_exit "Function $1 not implemented."
}

# Arg1: Name of array
# Arg2: Element to seek
nth_array_contains() {
    local array="$1[@]"
    local seeking=$2
    local element
    local in=1
    for element in "${!array}"; do
        if [[ $element == $seeking ]]; then
            in=0
            break
        fi
    done
    return $in
}

# Arg1: Array Name
# Arg2: Element to seek
nth_array_index() {
    local array="$1[@]"
    local seeking=$2
    local element
    local i=0
    local idx=
    local in=1
    for element in "${!array}"; do
        if [[ $element == $seeking ]]; then
            idx=$i
	    in=0
            break
        fi
	i=$(expr $i + 1)
    done
    echo $idx
    return $in
}

# Arg 1: Separator
# Arg 2..n: strings to be joined
nth_join_by() { local IFS="$1" ; shift; echo "$*"; }

nth_list_function() {
    [ $# -ne 1 ] && nth_exit "Expecting function name argument."
    export -f $1
    echo -n $1
    printenv BASH_FUNC_${1}%%
    echo "#"
}

exit_with_error() {
    cat >&2 <<EOF
******************** ERROR ********************
An error occured:	

$1

Please fix the underlying cause and rerun this
script.
***********************************************
EOF
    nth_exit
}

sdkdir=$(dirname $0)/..
pushd "$sdkdir" >/dev/null
[ $? -eq 0 ] || exit_with_error "Cannot change to $sdkdir"
sdkdir=$(pwd)
popd >/dev/null
mydir=${sdkdir}/scripts
[ -d "$mydir" ] || exit_with_error "Directory $mydir not found."

outdir=$sdkdir/build_dir
mkdir -p "$outdir" 2>/dev/null
[ -d "$outdir" ] || exit_with_error "Directory $outdir not found."

defdir=${sdkdir}/defs
[ -d "$defdir" ] || exit_with_error "Directory $defdir not found."

pushd $(dirname $0)/../../../../documentation/SDKs/iOS >/dev/null
[ $? -eq 0 ] || exit_with_error "Error in directory structure. Verify your git checkout"
docdir=$(pwd)
popd >/dev/null
[ -n "$docdir" ] || exit_with_error "Cannot determine documentation directory"
[ -d "$docdir" ] || exit_with_error "Documentation directory not found"

api_file="$outdir/nether_api.json"

[ -d "$outdir" ] || exit_with_error "Directory $outdir is missing"

package_manager=""
type -p brew >/dev/null
if [ $? -eq 0 ]; then
    package_manager="brew"
else
    type -p port >/dev/null
    if [ $? -eq 0 ]; then
	package_manager="sudo port"
    fi
fi

inform_about_missing_software() {
    local brew=$2
    local port=$3
    local pkg
    if [ "$package_manager" = "brew" ]; then
	pkg=$2
    else
	pkg=$3
    fi
    [ -n "$pkg" ] || pkg=$1
    if [ -n "$package_manager" ]; then
	cat >&2 <<EOF
******************** ERROR ********************
The program $1 is missing.
Please use this command to install it:
       	   
$package_manager install $pkg

Then re-run this script.
***********************************************
EOF
    fi
    nth_exit
}

ensure_software_exists() {
    local brew=$2
    local port=$3
    type -p "$1" >/dev/null
    [ $? -eq 0 ] || inform_about_missing_software "$@"
}

gen_api() {
    local lang="$1"
    local opts="$2"
    local args="generate $opts -D license=MIT --api-package Nether -i $api_file  -l $lang -o $outdir/nether-${lang}-api/"

    [ -r "$api_file" ] || exit_with_error "$api_file not found. Please run script to generate it"
 
    rm -rf $outdir/nether-${lang}-api/docs
    rm -rf $outdir/nether-${lang}-api/NetherSDK
    java -DappName=NetherClient -jar "$outdir/swagger-codegen-cli.jar" $args

    return 0
}

publish_api_doc() {
    local lang="$1"
    local oldlist
    local newlist
    [ -d $outdir/nether-${lang}-api/docs ] || return 0
    pushd $outdir/nether-${lang}-api/ >/dev/null
    target=${docdir}/${lang}
    mkdir -p ${target}
    [ -d ${target} ] || exit_with_error "Cannot find directory ${target}"
    if [ -r README.md ]; then
	cp -f README.md ${target}/
	pushd $target >/dev/null
	git add README.md
	popd >/dev/null
    else
	pushd $target >/dev/null
	git rm -f README.md 2>/dev/null
	popd >/dev/null
    fi
    mkdir -p ${target}/docs 2>/dev/null
    [ -d ${target}/docs ] || exit_with_error "Cannot find directory $target/docs"
    oldlist=$(mktemp)
    pushd $target/docs >/dev/null
    find . -type f | sort > $oldlist
    popd >/dev/null
    newlist=$(mktemp)
    pushd ./docs >/dev/null
    find . -type f | sort > $newlist
    find . -type f | cpio -pdmu ${target}/docs/
    popd > /dev/null
    popd >/dev/null
    pushd $target/docs >/dev/null
    for f in $(diff -uN $oldlist $newlist |grep ^- |grep -v ^-- |cut -d- -f2)
    do
	git rm -f "$f"
    done
    git add $(cat $newlist)
    popd >/dev/null
    rm -f $oldlist $newlist
    return 0
}

search_jdk() {
    local res=1
    local v=$(/usr/libexec/java_home -v 1.8 -t CommandLine)
    if [ -n "$v" ]; then
	echo $v
	res=0
    else
	v=$(/usr/libexec/java_home -v 1.7 -t CommandLine)
	if [ -n "$v" ]; then
	    echo $v
	    res=0
	fi
    fi
    return $res
}

ensure_software_exists curl
ensure_software_exists jq

if [ -z "$JAVA_HOME" ]; then
    # echo java is apparently not configured, let's see what's there
    JAVA_HOME=$(search_jdk)
    if [ -n "$JAVA_HOME" ]; then
	export JAVA_HOME
	export PATH=${JAVA_HOME}bin:$PATH
    else
	exit_with_error "java not installed."
    fi
fi
#
# Local Variables: 
# mode: shell-script
# comment-column: 0
# End:
