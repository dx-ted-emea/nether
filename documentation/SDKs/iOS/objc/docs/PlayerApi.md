# PlayerApi

All URIs are relative to *https://localhost/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**playerDelete**](PlayerApi.md#playerdelete) | **DELETE** /player | Deletes the player information for the currently logged in user
[**playerGet**](PlayerApi.md#playerget) | **GET** /player | Gets the player information from currently logged in user
[**playerPut**](PlayerApi.md#playerput) | **PUT** /player | Updates information about the current player
[**playerStateGet**](PlayerApi.md#playerstateget) | **GET** /player/state | Gets the player state for the current player
[**playerStatePut**](PlayerApi.md#playerstateput) | **PUT** /player/state | Updates state for the current player


# **playerDelete**
```objc
-(NSURLSessionTask*) playerDeleteWithCompletionHandler: 
        (void (^)(NSError* error)) handler;
```

Deletes the player information for the currently logged in user

### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



PlayerApi*apiInstance = [[PlayerApi alloc] init];

// Deletes the player information for the currently logged in user
[apiInstance playerDeleteWithCompletionHandler: 
          ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling PlayerApi->playerDelete: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **playerGet**
```objc
-(NSURLSessionTask*) playerGetWithCompletionHandler: 
        (void (^)(NetherWebFeaturesPlayerManagementModelsPlayerPlayerGetResponseModel* output, NSError* error)) handler;
```

Gets the player information from currently logged in user

### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



PlayerApi*apiInstance = [[PlayerApi alloc] init];

// Gets the player information from currently logged in user
[apiInstance playerGetWithCompletionHandler: 
          ^(NetherWebFeaturesPlayerManagementModelsPlayerPlayerGetResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling PlayerApi->playerGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**NetherWebFeaturesPlayerManagementModelsPlayerPlayerGetResponseModel***](NetherWebFeaturesPlayerManagementModelsPlayerPlayerGetResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **playerPut**
```objc
-(NSURLSessionTask*) playerPutWithPlayer: (NetherWebFeaturesPlayerManagementModelsPlayerPlayerPutRequestModel*) player
        completionHandler: (void (^)(NSError* error)) handler;
```

Updates information about the current player

### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NetherWebFeaturesPlayerManagementModelsPlayerPlayerPutRequestModel* player = [[NetherWebFeaturesPlayerManagementModelsPlayerPlayerPutRequestModel alloc] init]; // Player data (optional)

PlayerApi*apiInstance = [[PlayerApi alloc] init];

// Updates information about the current player
[apiInstance playerPutWithPlayer:player
          completionHandler: ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling PlayerApi->playerPut: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **player** | [**NetherWebFeaturesPlayerManagementModelsPlayerPlayerPutRequestModel***](NetherWebFeaturesPlayerManagementModelsPlayerPlayerPutRequestModel.md)| Player data | [optional] 

### Return type

void (empty response body)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/json-patch+json, text/plain
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **playerStateGet**
```objc
-(NSURLSessionTask*) playerStateGetWithCompletionHandler: 
        (void (^)(NSString* output, NSError* error)) handler;
```

Gets the player state for the current player

### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



PlayerApi*apiInstance = [[PlayerApi alloc] init];

// Gets the player state for the current player
[apiInstance playerStateGetWithCompletionHandler: 
          ^(NSString* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling PlayerApi->playerStateGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

**NSString***

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **playerStatePut**
```objc
-(NSURLSessionTask*) playerStatePutWithState: (NSString*) state
        completionHandler: (void (^)(NSError* error)) handler;
```

Updates state for the current player

### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* state = state_example; // Player data (optional)

PlayerApi*apiInstance = [[PlayerApi alloc] init];

// Updates state for the current player
[apiInstance playerStatePutWithState:state
          completionHandler: ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling PlayerApi->playerStatePut: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **state** | **NSString***| Player data | [optional] 

### Return type

void (empty response body)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: text/plain
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

