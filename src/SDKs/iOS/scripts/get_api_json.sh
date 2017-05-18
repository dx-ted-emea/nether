#!/usr/bin/env bash
#
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
. $(dirname $0)/common.inc

location="http://localhost:5000/api/swagger/v0.1/swagger.json"
f=$(mktemp)
curl -s "$location" > $f
if [ $? -ne 0 ]; then
    rm -f $f
    exit_with_error "The Nether service must run locally on port 5000"
fi
if [ -f "$api_file" ]; then
    cmp -s $f "$api_file" >/dev/null 2>&1
    if [ $? -ne 0 ]; then
	echo Regenerate $api_file >&2
	mv -f $f "$api_file"
    else
	echo Unchanged $api_file >&2
	rm -f $f
    fi
else
    echo New $api_file >&2
    mv -f $f "$api_file"
fi

exit 0
#
# Local Variables: 
# mode: shell-script
# comment-column: 0
# End:
