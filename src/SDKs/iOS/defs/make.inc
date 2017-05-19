# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
BUILD_DIR=$(PROJ_ROOT)/build_dir
SCRIPT_DIR=$(PROJ_ROOT)/scripts
DEF_DIR=$(PROJ_ROOT)/defs
OS=$(shell uname -s)
#
GIT_BASE_URL=$(shell $(SCRIPT_DIR)/get_github_url.sh -p)

export GIT_USER_ID=$(shell $(SCRIPT_DIR)/get_github_url.sh -u)
export GIT_REPO_ID=netherpod
export GIT_PUBLISHER_ID=MicrosoftDX
#
# -----------------------------------------------------------------------------
# You may specify CODEGEN=release on the make commandline for alternate codegen
# Please note, the release codegen fails at the moment of this writing
CODEGEN=trunk
# -----------------------------------------------------------------------------
ifneq ($(OS),Darwin)
$(error This Makefile is intended for MacOS Darwin only)
endif
# -----------------------------------------------------------------------------
POD=$(shell type -p pod)
ifeq ($(POD),)
$(error cocoapods not installed. Please see https://guides.cocoapods.org/using/getting-started.html)
endif
# -----------------------------------------------------------------------------
ifeq ($(GIT_TOKEN),)
$(error You need to create a persnal access token in github and store it in environment varibale GIT_TOKEN)
endif
# -----------------------------------------------------------------------------
LINT_INDICATOR=$(BUILD_DIR)/lint.done
STRICT_LINT_INDICATOR=$(BUILD_DIR)/strictlint.done

