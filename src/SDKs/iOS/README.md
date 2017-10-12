# Source Code for Nether SDK for iOS
To build the SDK, certain requirements must be met

- You must run under MacOS
- Certain development software must be installed:
    - Apples Xcode
    - ruby, java, maven, cocoapods
    - text2html, jq, curl
- Nether must have been build and the Web API must be up on localhost port 5000 (usually achieved by build.sh and rundev.sh in the root directory of Nether)
- As on optional prerequisite - in order to be able to automatically push the generated CocoaPod to github inside the build scripts - you need to create a Personal Access Token on github (especially if you use 2FA).
    - Please see the github documentation how to create such a token
    - You must store the created token in environment variable GIT_TOKEN before running the build. You may do this in your .profile or .bashrc shell init-files.
    - Please note that this step is only required if you plan to publish the CocoaPod "officially". For local development you can just use the generated CocoaPod directory.

The build system checks for the existence of the required tools and environment varibales and provides hints how to install them if they are not found.

If your system meets all the requirements, just just run this command to do the build:

$ make

This will build the SDK as a CocoaPod and update the Nether documentation.

There are several specific make targets you may also try:

- $ make push
    - This publishes to generated pod into your github account as repository netherpod
    - If you don't have that repository, please create it as an empty reposittory in your github account
- $ make clean
    - This cleans all the built artefacts, including the generated CocoaPod directory.
    - Please delete and recreate the netherpod repository manually in your github account if you want to rerun make
- $ make lint
    - Does a "tolerant" validation of the generated pod. Tolerant means, warings are ignored
- $ make strictlint
    - Does a string validation, which means warnings are treated as ewrrors.
    - Please note, that at the moment we don't pass strict validation, mainly due to missing comments in the generated Swagger API description.

# Developing an Apple client with Xcode on the local machine
- Create a Xcode project as you do normally. Close XCode after that.
- Open a terminal and go to the directory where you have stored your project.
- Create a Podfile by running "$ pod init".
- Open the Podfile and add the following content
```
target 'MyApp' do
  pod 'NetherSDK', :path => 'IOS_SDK_SRC/netherpod'
end
```
Please replace IOS_SDK_SRC with the path appropriate to your environment.

Save the Podfile and run "$pod install". After that you can start Xcode and open your project. You'll now see NetherSDK and its dependencies as part of your project.
