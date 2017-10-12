#!/usr/bin/env bash
#
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
. $(dirname $0)/common.inc

url=$(${mydir}/get_github_url.sh -p)/${POD_GIT}
contact=$(jq .info.contact.name < "$api_file" | tr -d '"')
contact_email=$(jq .info.contact.email < "$api_file" | tr -d '"')
[ -n "$contact" -a -n "$contact_email" ] || exit_with_error "Cannot extract contact data from ${api_file}."
version=$(jq .info.version < "$api_file" | tr -d '"' | tr -d 'v')
[ -n "$version" ] || exit_with_error "Cannot extract version from ${api_file}."
version=${version}.${POD_VERSION}.${build_nr}

nth_trace "replacing @PODURL@ by ${url}"
nth_trace "replacing @PODNAME@ by ${POD_NAME}"
nth_trace "Replacing @AUTHOR@ by ${contact} and @EMAIL@ ny ${contact_email}"
nth_trace "replacing @APIVERSION@ by ${version}"

sed -e "s%@PODURL@%${url}%g" \
    -e "s%@PODNAME@%${POD_NAME}%g" \
    -e "s%@AUTHOR@%${contact}%g" \
    -e "s%@EMAIL@%${contact_email}%g" \
    -e "s%@APIVERSION@%${version}%g"

exit 0
#
# Local Variables: 
# mode: shell-script
# comment-column: 0
# End:
