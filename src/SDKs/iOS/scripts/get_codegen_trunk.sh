#!/usr/bin/env bash
#
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
. $(dirname $0)/common.inc

repo="https://github.com/swagger-api/swagger-codegen.git"
build=0

MVN=mvn
if [ "$package_manager" != "brew" ]; then
    MVN=${MVN}3
fi
ensure_software_exists $MVN maven maven3

pushd $outdir >/dev/null
[ -f swagger-codegen-cli.jar ] || build=1

if [ ! -d swagger-codegen/.git ]; then
    git clone $repo
    build=1
fi
[ -d swagger-codegen/.git ] || exit_with_error "swagger-codegen not cloned?"
cd swagger-codegen
git diff origin/master >/dev/null 2>&1
if [ $? -ne 0 ]; then
    git pull
    build=1
fi

if [ $build -ne 0 ]; then
    $MVN clean package
    if [ $? -eq 0 ]; then
	cd $outdir
	if [ -r swagger-codegen/modules/swagger-codegen-cli/target/swagger-codegen-cli.jar ]; then
	    rm -f swagger-codegen-cli.jar
	    ln swagger-codegen/modules/swagger-codegen-cli/target/swagger-codegen-cli.jar .
	fi
    fi
fi
popd >/dev/null

exit 0
#
# Local Variables: 
# mode: shell-script
# comment-column: 0
# End:
