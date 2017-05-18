# PlayerAdminApi

All URIs are relative to *https://localhost/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**adminPlayersByGamertagGet**](PlayerAdminApi.md#adminplayersbygamertagget) | **GET** /admin/players/{gamertag} | Gets player information by player&#39;s gamer tag. You have to be an administrator to perform this action.
[**adminPlayersByGamertagPut**](PlayerAdminApi.md#adminplayersbygamertagput) | **PUT** /admin/players/{gamertag} | Updates a player. You have to be an administrator to perform this action.
[**adminPlayersByGamertagStateGet**](PlayerAdminApi.md#adminplayersbygamertagstateget) | **GET** /admin/players/{gamertag}/state | Gets player state. You have to be an administrator to perform this action.
[**adminPlayersByGamertagStatePut**](PlayerAdminApi.md#adminplayersbygamertagstateput) | **PUT** /admin/players/{gamertag}/state | Set player state. You have to be an administrator to perform this action.
[**adminPlayersGet**](PlayerAdminApi.md#adminplayersget) | **GET** /admin/players | Gets all players
[**adminPlayersPost**](PlayerAdminApi.md#adminplayerspost) | **POST** /admin/players | Creates a player. You have to be an administrator to perform this action.


# **adminPlayersByGamertagGet**
```objc
-(NSURLSessionTask*) adminPlayersByGamertagGetWithGamertag: (NSString*) gamertag
        completionHandler: (void (^)(NetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerGetResponseModel* output, NSError* error)) handler;
```

Gets player information by player's gamer tag. You have to be an administrator to perform this action.

### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* gamertag = @"gamertag_example"; // Gamer tag

PlayerAdminApi*apiInstance = [[PlayerAdminApi alloc] init];

// Gets player information by player's gamer tag. You have to be an administrator to perform this action.
[apiInstance adminPlayersByGamertagGetWithGamertag:gamertag
          completionHandler: ^(NetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerGetResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling PlayerAdminApi->adminPlayersByGamertagGet: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **gamertag** | **NSString***| Gamer tag | 

### Return type

[**NetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerGetResponseModel***](NetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerGetResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **adminPlayersByGamertagPut**
```objc
-(NSURLSessionTask*) adminPlayersByGamertagPutWithGamertag: (NSString*) gamertag
    varNewPlayer: (NetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPutRequestModel*) varNewPlayer
        completionHandler: (void (^)(NSError* error)) handler;
```

Updates a player. You have to be an administrator to perform this action.

### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* gamertag = @"gamertag_example"; // The gamertag
NetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPutRequestModel* varNewPlayer = [[NetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPutRequestModel alloc] init]; // Player data (optional)

PlayerAdminApi*apiInstance = [[PlayerAdminApi alloc] init];

// Updates a player. You have to be an administrator to perform this action.
[apiInstance adminPlayersByGamertagPutWithGamertag:gamertag
              varNewPlayer:varNewPlayer
          completionHandler: ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling PlayerAdminApi->adminPlayersByGamertagPut: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **gamertag** | **NSString***| The gamertag | 
 **varNewPlayer** | [**NetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPutRequestModel***](NetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPutRequestModel*.md)| Player data | [optional] 

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
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* gamertag = @"gamertag_example"; // Gamer tag

PlayerAdminApi*apiInstance = [[PlayerAdminApi alloc] init];

// Gets player state. You have to be an administrator to perform this action.
[apiInstance adminPlayersByGamertagStateGetWithGamertag:gamertag
          completionHandler: ^(NSString* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling PlayerAdminApi->adminPlayersByGamertagStateGet: %@", error);
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
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* gamertag = @"gamertag_example"; // 
NSString* state = state_example; //  (optional)

PlayerAdminApi*apiInstance = [[PlayerAdminApi alloc] init];

// Set player state. You have to be an administrator to perform this action.
[apiInstance adminPlayersByGamertagStatePutWithGamertag:gamertag
              state:state
          completionHandler: ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling PlayerAdminApi->adminPlayersByGamertagStatePut: %@", error);
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
        (void (^)(NetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerListGetResponseModel* output, NSError* error)) handler;
```

Gets all players

### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



PlayerAdminApi*apiInstance = [[PlayerAdminApi alloc] init];

// Gets all players
[apiInstance adminPlayersGetWithCompletionHandler: 
          ^(NetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerListGetResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling PlayerAdminApi->adminPlayersGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**NetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerListGetResponseModel***](NetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerListGetResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **adminPlayersPost**
```objc
-(NSURLSessionTask*) adminPlayersPostWithVarNewPlayer: (NetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPostRequestModel*) varNewPlayer
        completionHandler: (void (^)(NSError* error)) handler;
```

Creates a player. You have to be an administrator to perform this action.

### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPostRequestModel* varNewPlayer = [[NetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPostRequestModel alloc] init]; // Player data (optional)

PlayerAdminApi*apiInstance = [[PlayerAdminApi alloc] init];

// Creates a player. You have to be an administrator to perform this action.
[apiInstance adminPlayersPostWithVarNewPlayer:varNewPlayer
          completionHandler: ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling PlayerAdminApi->adminPlayersPost: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **varNewPlayer** | [**NetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPostRequestModel***](NetherWebFeaturesPlayerManagementModelsPlayerAdminPlayerPostRequestModel*.md)| Player data | [optional] 

### Return type

void (empty response body)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/json-patch+json, text/plain
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

