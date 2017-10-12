# SWGPlayerApi

All URIs are relative to *https://localhost/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**playerDelete**](SWGPlayerApi.md#playerdelete) | **DELETE** /player | Deletes the player information for the currently logged in user
[**playerGet**](SWGPlayerApi.md#playerget) | **GET** /player | Gets the player information from currently logged in user
[**playerPut**](SWGPlayerApi.md#playerput) | **PUT** /player | Updates information about the current player
[**playerStateGet**](SWGPlayerApi.md#playerstateget) | **GET** /player/state | Gets the player state for the current player
[**playerStatePut**](SWGPlayerApi.md#playerstateput) | **PUT** /player/state | Updates state for the current player


# **playerDelete**
```objc
-(NSURLSessionTask*) playerDeleteWithCompletionHandler: 
        (void (^)(NSError* error)) handler;
```

Deletes the player information for the currently logged in user

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGPlayerApi*apiInstance = [[SWGPlayerApi alloc] init];

// Deletes the player information for the currently logged in user
[apiInstance playerDeleteWithCompletionHandler: 
          ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling SWGPlayerApi->playerDelete: %@", error);
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
        (void (^)(SWGNetherWebFeaturesPlayerManagementModelsPlayerPlayerGetResponseModel* output, NSError* error)) handler;
```

Gets the player information from currently logged in user

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGPlayerApi*apiInstance = [[SWGPlayerApi alloc] init];

// Gets the player information from currently logged in user
[apiInstance playerGetWithCompletionHandler: 
          ^(SWGNetherWebFeaturesPlayerManagementModelsPlayerPlayerGetResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGPlayerApi->playerGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SWGNetherWebFeaturesPlayerManagementModelsPlayerPlayerGetResponseModel***](SWGNetherWebFeaturesPlayerManagementModelsPlayerPlayerGetResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **playerPut**
```objc
-(NSURLSessionTask*) playerPutWithPlayer: (SWGNetherWebFeaturesPlayerManagementModelsPlayerPlayerPutRequestModel*) player
        completionHandler: (void (^)(NSError* error)) handler;
```

Updates information about the current player

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


SWGNetherWebFeaturesPlayerManagementModelsPlayerPlayerPutRequestModel* player = [[SWGNetherWebFeaturesPlayerManagementModelsPlayerPlayerPutRequestModel alloc] init]; // Player data (optional)

SWGPlayerApi*apiInstance = [[SWGPlayerApi alloc] init];

// Updates information about the current player
[apiInstance playerPutWithPlayer:player
          completionHandler: ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling SWGPlayerApi->playerPut: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **player** | [**SWGNetherWebFeaturesPlayerManagementModelsPlayerPlayerPutRequestModel***](SWGNetherWebFeaturesPlayerManagementModelsPlayerPlayerPutRequestModel.md)| Player data | [optional] 

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
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGPlayerApi*apiInstance = [[SWGPlayerApi alloc] init];

// Gets the player state for the current player
[apiInstance playerStateGetWithCompletionHandler: 
          ^(NSString* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGPlayerApi->playerStateGet: %@", error);
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
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* state = state_example; // Player data (optional)

SWGPlayerApi*apiInstance = [[SWGPlayerApi alloc] init];

// Updates state for the current player
[apiInstance playerStatePutWithState:state
          completionHandler: ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling SWGPlayerApi->playerStatePut: %@", error);
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

