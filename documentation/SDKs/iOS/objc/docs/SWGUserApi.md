# SWGUserApi

All URIs are relative to *https://localhost/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**identityUsersByUserIdDelete**](SWGUserApi.md#identityusersbyuseriddelete) | **DELETE** /identity/users/{userId} | Deletes the specified user
[**identityUsersByUserIdGet**](SWGUserApi.md#identityusersbyuseridget) | **GET** /identity/users/{userId} | Get user and logins information for a user
[**identityUsersByUserIdPut**](SWGUserApi.md#identityusersbyuseridput) | **PUT** /identity/users/{userId} | Update the user and logins for a user
[**identityUsersGet**](SWGUserApi.md#identityusersget) | **GET** /identity/users | Return a list of users
[**identityUsersPost**](SWGUserApi.md#identityuserspost) | **POST** /identity/users | Add a new user


# **identityUsersByUserIdDelete**
```objc
-(NSURLSessionTask*) identityUsersByUserIdDeleteWithUserId: (NSString*) userId
        completionHandler: (void (^)(NSError* error)) handler;
```

Deletes the specified user

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* userId = @"userId_example"; // The id of the user

SWGUserApi*apiInstance = [[SWGUserApi alloc] init];

// Deletes the specified user
[apiInstance identityUsersByUserIdDeleteWithUserId:userId
          completionHandler: ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling SWGUserApi->identityUsersByUserIdDelete: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **NSString***| The id of the user | 

### Return type

void (empty response body)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **identityUsersByUserIdGet**
```objc
-(NSURLSessionTask*) identityUsersByUserIdGetWithUserId: (NSString*) userId
        completionHandler: (void (^)(SWGNetherWebFeaturesIdentityModelsUserUserResponseModel* output, NSError* error)) handler;
```

Get user and logins information for a user

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* userId = @"userId_example"; // The id of the user to retrieve

SWGUserApi*apiInstance = [[SWGUserApi alloc] init];

// Get user and logins information for a user
[apiInstance identityUsersByUserIdGetWithUserId:userId
          completionHandler: ^(SWGNetherWebFeaturesIdentityModelsUserUserResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGUserApi->identityUsersByUserIdGet: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **NSString***| The id of the user to retrieve | 

### Return type

[**SWGNetherWebFeaturesIdentityModelsUserUserResponseModel***](SWGNetherWebFeaturesIdentityModelsUserUserResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **identityUsersByUserIdPut**
```objc
-(NSURLSessionTask*) identityUsersByUserIdPutWithUserId: (NSString*) userId
    userModel: (SWGNetherWebFeaturesIdentityModelsUserUserRequestModel*) userModel
        completionHandler: (void (^)(SWGNetherWebFeaturesIdentityModelsUserUserResponseModel* output, NSError* error)) handler;
```

Update the user and logins for a user

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* userId = @"userId_example"; // The id of the user to update
SWGNetherWebFeaturesIdentityModelsUserUserRequestModel* userModel = [[SWGNetherWebFeaturesIdentityModelsUserUserRequestModel alloc] init]; // The new user and logins details for the user (optional)

SWGUserApi*apiInstance = [[SWGUserApi alloc] init];

// Update the user and logins for a user
[apiInstance identityUsersByUserIdPutWithUserId:userId
              userModel:userModel
          completionHandler: ^(SWGNetherWebFeaturesIdentityModelsUserUserResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGUserApi->identityUsersByUserIdPut: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **NSString***| The id of the user to update | 
 **userModel** | [**SWGNetherWebFeaturesIdentityModelsUserUserRequestModel***](SWGNetherWebFeaturesIdentityModelsUserUserRequestModel.md)| The new user and logins details for the user | [optional] 

### Return type

[**SWGNetherWebFeaturesIdentityModelsUserUserResponseModel***](SWGNetherWebFeaturesIdentityModelsUserUserResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/json-patch+json, text/plain
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **identityUsersGet**
```objc
-(NSURLSessionTask*) identityUsersGetWithCompletionHandler: 
        (void (^)(SWGNetherWebFeaturesIdentityModelsUserUserListModel* output, NSError* error)) handler;
```

Return a list of users

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGUserApi*apiInstance = [[SWGUserApi alloc] init];

// Return a list of users
[apiInstance identityUsersGetWithCompletionHandler: 
          ^(SWGNetherWebFeaturesIdentityModelsUserUserListModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGUserApi->identityUsersGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SWGNetherWebFeaturesIdentityModelsUserUserListModel***](SWGNetherWebFeaturesIdentityModelsUserUserListModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **identityUsersPost**
```objc
-(NSURLSessionTask*) identityUsersPostWithUserModel: (SWGNetherWebFeaturesIdentityModelsUserUserRequestModel*) userModel
        completionHandler: (void (^)(NSError* error)) handler;
```

Add a new user

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


SWGNetherWebFeaturesIdentityModelsUserUserRequestModel* userModel = [[SWGNetherWebFeaturesIdentityModelsUserUserRequestModel alloc] init]; // The new user and login details for the user (including user id) (optional)

SWGUserApi*apiInstance = [[SWGUserApi alloc] init];

// Add a new user
[apiInstance identityUsersPostWithUserModel:userModel
          completionHandler: ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling SWGUserApi->identityUsersPost: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userModel** | [**SWGNetherWebFeaturesIdentityModelsUserUserRequestModel***](SWGNetherWebFeaturesIdentityModelsUserUserRequestModel.md)| The new user and login details for the user (including user id) | [optional] 

### Return type

void (empty response body)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/json-patch+json, text/plain
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

