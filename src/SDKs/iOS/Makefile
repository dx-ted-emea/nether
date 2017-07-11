# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
PROJ_ROOT=$(shell pwd -P)
include $(PROJ_ROOT)/defs/product
include $(PROJ_ROOT)/defs/make.inc
PODSPEC=$(PROJ_ROOT)/$(POD_GIT)/$(POD_NAME).podspec

all:: 	doc
	@echo Done.

$(BUILD_DIR)/nether_api.json::
	@$(SCRIPT_DIR)/get_api_json.sh

$(BUILD_DIR)/swagger-codegen-cli.jar::
ifeq ($(CODEGEN),release)
	@$(SCRIPT_DIR)/get_codegen.sh
endif
ifeq ($(CODEGEN),trunk)
	@$(SCRIPT_DIR)/get_codegen_trunk.sh
endif

$(PODSPEC):: \
	$(DEF_DIR)/product \
	$(BUILD_DIR)/objc_config.json \
	$(BUILD_DIR)/nether_api.json \
	$(BUILD_DIR)/nether_api.json \
	$(BUILD_DIR)/swagger-codegen-cli.jar
	@$(SCRIPT_DIR)/upd_build.sh
	@$(SCRIPT_DIR)/gen_objc_api.sh

$(BUILD_DIR)/objc_config.json: \
	$(DEF_DIR)/objc_config.json.in $(BUILD_DIR)/nether_api.json \
	$(DEF_DIR)/product
	@(rm -f "$@" ; $(SCRIPT_DIR)/transform_config.sh < "$<" > "$@")

$(PODLINT_INDICATOR): $(PODSPEC)
	($(POD) lib lint --allow-warnings --silent $< && touch $@)


lint:: $(PODLINT_INDICATOR)
	@true

doc:: 	$(PODLINT_INDICATOR)
	@$(SCRIPT_DIR)/publish_api_docu.sh

push:	$(PODLINT_INDICATOR)
ifeq ($(GIT_TOKEN),)
$(error You need to create a persnal access token in github and store it in environment varibale GIT_TOKEN if you want to publish the CocoaPod to github)
endif
	@$(SCRIPT_DIR)/push_pod.sh

clean::
	@rm -rf $(PROJ_ROOT)/$(POD_GIT)/$(POD_NAME)
	@rm -rf $(PROJ_ROOT)/$(POD_GIT)/docs
	@rm -rf $(PODSPEC)
	@rm -f  $(BUILD_DIR)/*.json $(BUILD_DIR)/lint.*

veryclean:: clean
	@[ -d "$(BUILD_DIR)" ] && rm -rf $(BUILD_DIR)
