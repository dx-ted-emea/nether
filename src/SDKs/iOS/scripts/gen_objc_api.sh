#!/usr/bin/env bash
#
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
. $(dirname $0)/common.inc
gen_api objc "--config $outdir/objc_config.json"
exit 0
#
# Local Variables: 
# mode: shell-script
# comment-column: 0
# End:
