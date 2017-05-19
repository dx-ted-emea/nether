#!/usr/bin/env bash
#
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
. $(dirname $0)/common.inc

# Normalized basepath without protocol
_basepath() {
    local url
    [ $# -ne 1 ] && nth_exit "Expecting URL argument."
    url=$1
    if [ "${url::4}" = "git@" ]; then
	url=$(echo ${url:4} | tr ":" "/")
	echo ${url}
	return 0
    elif [ "${url::8}" = "https://" ]; then
	echo ${url:8}
	return 0
    else
	echo "Invalid github URL: $url" >&2
	return 1
    fi
}

# Normalize a github repository URL to https
_normalize_git_url() {
    local url
    [ $# -ne 1 ] && nth_exit "Expecting URL argument."
    url=$(_basepath "$1")
    echo https://${url}
    return 0
}

_usage() {
    local s=$(basename $0)
    local res=1
    [ $# -eq 1 ] && res=$1
    cat >&2 <<EOF
Usage: $s [-h|--help] [-n|--normalized]

Options
    -h or --help
       Shows this help text.

    -n or --normalized
       Shows the github URL in https:// notattion

    -p or --parent
       Shows only the owners root github path without the repository part

    -u or --user
       Extract only the github userId from the repo URL

Without any option, the github URL is displayed as stored in the
config file of the repository.
EOF
    if [ $res -ne 0 ]; then
	echo "Terminating $s" >&2
    fi
    exit $res
}

[ $# -le 1 ] || _usage

url=$(git config --get remote.origin.url)
[ -n "$url" ] || \
    exit_with_error "No remote origin configured for this repository"

if [ $# -eq 1 ]; then
    case "$1" in
	-h|--help)
	    _usage 0
	    ;;
	-n|--normalized)
	    url=$(_normalize_git_url "$url")
	    ;;
	-p|--parent)
	    url=https://$(dirname $(_basepath "$url"))
	    ;;
	-u|--user)
	    url=$(basename $(dirname $(_basepath "$url")))
	    ;;
	*)
	    echo "Unsupported option/argument $1" >&2
	    _usage
	    ;;
    esac    
fi
echo $url
exit 0
