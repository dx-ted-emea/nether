#!/usr/bin/env bash
#
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
. $(dirname $0)/common.inc
build_nr=$(expr $build_nr + 1)
echo $build_nr > "$bldfile"
[ -f "$bldfile" ] && git add "$bldfile"

exit 0
#
# Local Variables: 
# mode: shell-script
# comment-column: 0
# End:
