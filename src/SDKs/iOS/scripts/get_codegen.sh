#!/usr/bin/env bash
#
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
. $(dirname $0)/common.inc

location="https://oss.sonatype.org/content/repositories/releases/io/swagger/swagger-codegen-cli/"

ensure_software_exists html2text

version=$(curl -s "$location" | html2text -ascii -nobs | grep ^[0-9].*/ | cut -d/ -f1 | sort | tail -1)
[ -n "$version" ] || version="2.2.1"
echo "$version" > "$outdir/cg_version"
if [ ! -f "${outdir}/swagger-codegen-cli-${version}.jar" ]; then
    curl -s "${location}${version}/swagger-codegen-cli-${version}.jar" > "$outdir/swagger-codegen-cli-${version}.jar"
    [ $? -eq 0 ] || exit_with_error "Couldn't download ${location}${version}/swagger-codegen-cli-${version}.jar - check your internet connection."
fi
pushd "$outdir" >/dev/null
rm -f "swagger-codegen-cli.jar"
ln "swagger-codegen-cli-${version}.jar" "swagger-codegen-cli.jar" 
popd >/dev/null
exit 0
#
# Local Variables: 
# mode: shell-script
# comment-column: 0
# End:
