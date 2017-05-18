# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
PROJ_ROOT=$(shell pwd)
include $(PROJ_ROOT)/defs/make.inc

all:: doc
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

$(BUILD_DIR)/nether-objc-api/NetherSDK.podspec:: \
	$(DEF_DIR)/objc_config.json \
	$(BUILD_DIR)/nether_api.json \
	$(BUILD_DIR)/nether_api.json \
	$(BUILD_DIR)/swagger-codegen-cli.jar
	@$(SCRIPT_DIR)/gen_objc_api.sh

doc:: $(BUILD_DIR)/nether-objc-api/NetherSDK.podspec
	@$(SCRIPT_DIR)/publish_api_docu.sh

clean::
	@[ -d "$(BUILD_DIR)" ] && rm -rf $(BUILD_DIR)

