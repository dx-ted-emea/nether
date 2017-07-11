# SWGUserLoginApi

All URIs are relative to *https://localhost/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**identityUsersByUserIdLoginsByProviderTypeByProviderIdDelete**](SWGUserLoginApi.md#identityusersbyuseridloginsbyprovidertypebyprovideriddelete) | **DELETE** /identity/users/{userId}/logins/{providerType}/{providerId} | Deletes the specified login for the user
[**identityUsersByUserIdLoginsByProviderTypeByProviderIdPut**](SWGUserLoginApi.md#identityusersbyuseridloginsbyprovidertypebyprovideridput) | **PUT** /identity/users/{userId}/logins/{providerType}/{providerId} | Update the user and logins for a user
[**identityUsersByUserIdLoginsGet**](SWGUserLoginApi.md#identityusersbyuseridloginsget) | **GET** /identity/users/{userId}/logins | Return a list of logins for the specified user


# **identityUsersByUserIdLoginsByProviderTypeByProviderIdDelete**
```objc
-(NSURLSessionTask*) identityUsersByUserIdLoginsByProviderTypeByProviderIdDeleteWithUserId: (NSString*) userId
    providerType: (NSString*) providerType
    providerId: (NSString*) providerId
        completionHandler: (void (^)(NSError* error)) handler;
```

Deletes the specified login for the user

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* userId = @"userId_example"; // 
NSString* providerType = @"providerType_example"; // 
NSString* providerId = @"providerId_example"; // 

SWGUserLoginApi*apiInstance = [[SWGUserLoginApi alloc] init];

// Deletes the specified login for the user
[apiInstance identityUsersByUserIdLoginsByProviderTypeByProviderIdDeleteWithUserId:userId
              providerType:providerType
              providerId:providerId
          completionHandler: ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling SWGUserLoginApi->identityUsersByUserIdLoginsByProviderTypeByProviderIdDelete: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **NSString***|  | 
 **providerType** | **NSString***|  | 
 **providerId** | **NSString***|  | 

### Return type

void (empty response body)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **identityUsersByUserIdLoginsByProviderTypeByProviderIdPut**
```objc
-(NSURLSessionTask*) identityUsersByUserIdLoginsByProviderTypeByProviderIdPutWithUserId: (NSString*) userId
    providerType: (NSString*) providerType
    providerId: (NSString*) providerId
    userLoginModel: (SWGNetherWebFeaturesIdentityModelsUserLoginUserLoginRequestModel*) userLoginModel
        completionHandler: (void (^)(SWGNetherWebFeaturesIdentityModelsUserLoginUserLoginRequestModel* output, NSError* error)) handler;
```

Update the user and logins for a user

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* userId = @"userId_example"; // The id of the user to update
NSString* providerType = @"providerType_example"; // The type of login provider
NSString* providerId = @"providerId_example"; // The provider specific id for the login
SWGNetherWebFeaturesIdentityModelsUserLoginUserLoginRequestModel* userLoginModel = [[SWGNetherWebFeaturesIdentityModelsUserLoginUserLoginRequestModel alloc] init]; // Any additional parameters required by the provider (optional)

SWGUserLoginApi*apiInstance = [[SWGUserLoginApi alloc] init];

// Update the user and logins for a user
[apiInstance identityUsersByUserIdLoginsByProviderTypeByProviderIdPutWithUserId:userId
              providerType:providerType
              providerId:providerId
              userLoginModel:userLoginModel
          completionHandler: ^(SWGNetherWebFeaturesIdentityModelsUserLoginUserLoginRequestModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGUserLoginApi->identityUsersByUserIdLoginsByProviderTypeByProviderIdPut: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **NSString***| The id of the user to update | 
 **providerType** | **NSString***| The type of login provider | 
 **providerId** | **NSString***| The provider specific id for the login | 
 **userLoginModel** | [**SWGNetherWebFeaturesIdentityModelsUserLoginUserLoginRequestModel***](SWGNetherWebFeaturesIdentityModelsUserLoginUserLoginRequestModel.md)| Any additional parameters required by the provider | [optional] 

### Return type

[**SWGNetherWebFeaturesIdentityModelsUserLoginUserLoginRequestModel***](SWGNetherWebFeaturesIdentityModelsUserLoginUserLoginRequestModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/json-patch+json, text/plain
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **identityUsersByUserIdLoginsGet**
```objc
-(NSURLSessionTask*) identityUsersByUserIdLoginsGetWithUserId: (NSString*) userId
        completionHandler: (void (^)(SWGNetherWebFeaturesIdentityModelsUserLoginUserLoginListModel* output, NSError* error)) handler;
```

Return a list of logins for the specified user

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* userId = @"userId_example"; // The id of the user

SWGUserLoginApi*apiInstance = [[SWGUserLoginApi alloc] init];

// Return a list of logins for the specified user
[apiInstance identityUsersByUserIdLoginsGetWithUserId:userId
          completionHandler: ^(SWGNetherWebFeaturesIdentityModelsUserLoginUserLoginListModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGUserLoginApi->identityUsersByUserIdLoginsGet: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **NSString***| The id of the user | 

### Return type

[**SWGNetherWebFeaturesIdentityModelsUserLoginUserLoginListModel***](SWGNetherWebFeaturesIdentityModelsUserLoginUserLoginListModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

