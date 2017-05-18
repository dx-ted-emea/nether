BUILD_DIR=$(PROJ_ROOT)/build_dir
SCRIPT_DIR=$(PROJ_ROOT)/scripts
DEF_DIR=$(PROJ_ROOT)/defs
OS=$(shell uname -s)
# You may specify CODEGEN=trunk on the make commandline for alternate codegen
CODEGEN=release

ifneq ($(OS),Darwin)
$(error This Makefile is intended for MacOS Darwin only)
endif
