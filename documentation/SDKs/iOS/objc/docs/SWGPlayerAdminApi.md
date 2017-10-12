# SWGPlayerAdminApi

All URIs are relative to *https://localhost/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**adminPlayersByGamertagGet**](SWGPlayerAdminApi.md#adminplayersbygamertagget) | **GET** /admin/players/{gamertag} | Gets player information by player&#39;s gamer tag. You have to be an administrator to perform this action.
[**adminPlayersByGamertagPut**](SWGPlayerAdminApi.md#adminplayersbygamertagput) | **PUT** /admin/players/{gamertag} | Updates a player. You have to be an administrator to perform this action.
[**adminPlayersByGamertagStateGet**](SWGPlayerAdminApi.md#adminplayersbygamertagstateget) | **GET** /admin/players/{gamertag}/state | Gets player state. You have to be an administrator to perform this action.
[**adminPlayersByGamertagStatePut**](SWGPlayerAdminApi.md#adminplayersbygamertagstateput) | **PUT** /admin/players/{gamertag}/state | Set player state. You have to be an administrator to perform this action.
[**adminPlayersGet**](SWGPlayerAdminApi.md#adminplayersget) | **GET** /admin/players | Gets all players
[**adminPlayersPost**](SWGPlayerAdminApi.md#adminplayerspost) | **POST** /admin/players | Creates a player. You have to be an administrator to perform this action.


# **adminPlayersByGamertagGet**
```objc
-(NSURLSessionTask*) adminPlayersByGamertagGetWithGamertag: (NSString*) gamertag
        completionHandler: (void (^)(SWGNetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerGetResponseModel* output, NSError* error)) handler;
```

Gets player information by player's gamer tag. You have to be an administrator to perform this action.

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* gamertag = @"gamertag_example"; // Gamer tag

SWGPlayerAdminApi*apiInstance = [[SWGPlayerAdminApi alloc] init];

// Gets player information by player's gamer tag. You have to be an administrator to perform this action.
[apiInstance adminPlayersByGamertagGetWithGamertag:gamertag
          completionHandler: ^(SWGNetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerGetResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGPlayerAdminApi->adminPlayersByGamertagGet: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **gamertag** | **NSString***| Gamer tag | 

### Return type

[**SWGNetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerGetResponseModel***](SWGNetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerGetResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **adminPlayersByGamertagPut**
```objc
-(NSURLSessionTask*) adminPlayersByGamertagPutWithGamertag: (NSString*) gamertag
    varNewPlayer: (SWGNetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPutRequestModel*) varNewPlayer
        completionHandler: (void (^)(NSError* error)) handler;
```

Updates a player. You have to be an administrator to perform this action.

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* gamertag = @"gamertag_example"; // The gamertag
SWGNetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPutRequestModel* varNewPlayer = [[SWGNetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPutRequestModel alloc] init]; // Player data (optional)

SWGPlayerAdminApi*apiInstance = [[SWGPlayerAdminApi alloc] init];

// Updates a player. You have to be an administrator to perform this action.
[apiInstance adminPlayersByGamertagPutWithGamertag:gamertag
              varNewPlayer:varNewPlayer
          completionHandler: ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling SWGPlayerAdminApi->adminPlayersByGamertagPut: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **gamertag** | **NSString***| The gamertag | 
 **varNewPlayer** | [**SWGNetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPutRequestModel***](SWGNetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPutRequestModel.md)| Player data | [optional] 

### Return type

void (empty response body)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/json-patch+json, text/plain
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **adminPlayersByGamertagStateGet**
```objc
-(NSURLSessionTask*) adminPlayersByGamertagStateGetWithGamertag: (NSString*) gamertag
        completionHandler: (void (^)(NSString* output, NSError* error)) handler;
```

Gets player state. You have to be an administrator to perform this action.

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* gamertag = @"gamertag_example"; // Gamer tag

SWGPlayerAdminApi*apiInstance = [[SWGPlayerAdminApi alloc] init];

// Gets player state. You have to be an administrator to perform this action.
[apiInstance adminPlayersByGamertagStateGetWithGamertag:gamertag
          completionHandler: ^(NSString* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGPlayerAdminApi->adminPlayersByGamertagStateGet: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **gamertag** | **NSString***| Gamer tag | 

### Return type

**NSString***

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **adminPlayersByGamertagStatePut**
```objc
-(NSURLSessionTask*) adminPlayersByGamertagStatePutWithGamertag: (NSString*) gamertag
    state: (NSString*) state
        completionHandler: (void (^)(NSError* error)) handler;
```

Set player state. You have to be an administrator to perform this action.

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* gamertag = @"gamertag_example"; // 
NSString* state = state_example; //  (optional)

SWGPlayerAdminApi*apiInstance = [[SWGPlayerAdminApi alloc] init];

// Set player state. You have to be an administrator to perform this action.
[apiInstance adminPlayersByGamertagStatePutWithGamertag:gamertag
              state:state
          completionHandler: ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling SWGPlayerAdminApi->adminPlayersByGamertagStatePut: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **gamertag** | **NSString***|  | 
 **state** | **NSString***|  | [optional] 

### Return type

void (empty response body)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: text/plain
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **adminPlayersGet**
```objc
-(NSURLSessionTask*) adminPlayersGetWithCompletionHandler: 
        (void (^)(SWGNetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerListGetResponseModel* output, NSError* error)) handler;
```

Gets all players

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGPlayerAdminApi*apiInstance = [[SWGPlayerAdminApi alloc] init];

// Gets all players
[apiInstance adminPlayersGetWithCompletionHandler: 
          ^(SWGNetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerListGetResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGPlayerAdminApi->adminPlayersGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SWGNetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerListGetResponseModel***](SWGNetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerListGetResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **adminPlayersPost**
```objc
-(NSURLSessionTask*) adminPlayersPostWithVarNewPlayer: (SWGNetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPostRequestModel*) varNewPlayer
        completionHandler: (void (^)(NSError* error)) handler;
```

Creates a player. You have to be an administrator to perform this action.

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


SWGNetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPostRequestModel* varNewPlayer = [[SWGNetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPostRequestModel alloc] init]; // Player data (optional)

SWGPlayerAdminApi*apiInstance = [[SWGPlayerAdminApi alloc] init];

// Creates a player. You have to be an administrator to perform this action.
[apiInstance adminPlayersPostWithVarNewPlayer:varNewPlayer
          completionHandler: ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling SWGPlayerAdminApi->adminPlayersPost: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **varNewPlayer** | [**SWGNetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPostRequestModel***](SWGNetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPostRequestModel.md)| Player data | [optional] 

### Return type

void (empty response body)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/json-patch+json, text/plain
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

