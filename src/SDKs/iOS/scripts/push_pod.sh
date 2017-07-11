#!/usr/bin/env bash
#
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root
# for license information.
#
. $(dirname $0)/common.inc

[ -n "${GIT_REPO_ID}" ] || \
    exit_with_error "Environment varibale GIT_REPO_ID not set."
[ -n "${GIT_USER_ID}" ] || \
    exit_with_error "Environment varibale GIT_USER_ID not set."
[ -n "${GIT_PUBLISHER_ID}" ] || \
    exit_with_error "Environment varibale GIT_PUBLISHER_ID not set."
[ -n "${GIT_TOKEN}" ] || \
    exit_with_error "Environment varibale GIT_TOKEN not set."

[ -d "$poddir" ] || \
    exit_with_error "Directory $poddir not found."
pscript=git_push.sh
[ -f "$poddir/$pscript" ] ||\
    exit_with_error "Script $pscript not found."
echo GIT_REPO_ID=${GIT_REPO_ID}
echo GIT_USER_ID=${GIT_USER_ID}
echo GIT_PUBLISHER_ID=${GIT_PUBLISHER_ID}
echo GIT_TOKEN=${GIT_TOKEN}

pushd "$poddir/" >/dev/null
if [ -r README.md ]; then
    sed -i -e "s/GIT_USER_ID/${GIT_PUBLISHER_ID}/g" README.md
    sed -i -e "s/GIT_REPO_ID/${GIT_REPO_ID}/g" README.md
    rm -f README.md-e
fi
$SHELL ./${pscript} $GIT_USER_ID $GIT_REPO_ID
popd >/dev/null

exit 0
#
# Local Variables: 
# mode: shell-script
# comment-column: 0
# End:
