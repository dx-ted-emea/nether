# SWGLeaderboardApi

All URIs are relative to *https://localhost/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**leaderboardsByNameGet**](SWGLeaderboardApi.md#leaderboardsbynameget) | **GET** /leaderboards/{name} | Gets leaderboard by leaderboard configured name
[**leaderboardsGet**](SWGLeaderboardApi.md#leaderboardsget) | **GET** /leaderboards | Gets leaderboard by leaderboard configured name


# **leaderboardsByNameGet**
```objc
-(NSURLSessionTask*) leaderboardsByNameGetWithName: (NSString*) name
        completionHandler: (void (^)(SWGNetherWebFeaturesLeaderboardModelsLeaderboardLeaderboardGetResponseModel* output, NSError* error)) handler;
```

Gets leaderboard by leaderboard configured name

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* name = @"name_example"; // Name of the leaderboard

SWGLeaderboardApi*apiInstance = [[SWGLeaderboardApi alloc] init];

// Gets leaderboard by leaderboard configured name
[apiInstance leaderboardsByNameGetWithName:name
          completionHandler: ^(SWGNetherWebFeaturesLeaderboardModelsLeaderboardLeaderboardGetResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGLeaderboardApi->leaderboardsByNameGet: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **NSString***| Name of the leaderboard | 

### Return type

[**SWGNetherWebFeaturesLeaderboardModelsLeaderboardLeaderboardGetResponseModel***](SWGNetherWebFeaturesLeaderboardModelsLeaderboardLeaderboardGetResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **leaderboardsGet**
```objc
-(NSURLSessionTask*) leaderboardsGetWithCompletionHandler: 
        (void (^)(SWGNetherWebFeaturesLeaderboardModelsLeaderboardLeaderboardListResponseModel* output, NSError* error)) handler;
```

Gets leaderboard by leaderboard configured name

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGLeaderboardApi*apiInstance = [[SWGLeaderboardApi alloc] init];

// Gets leaderboard by leaderboard configured name
[apiInstance leaderboardsGetWithCompletionHandler: 
          ^(SWGNetherWebFeaturesLeaderboardModelsLeaderboardLeaderboardListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGLeaderboardApi->leaderboardsGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SWGNetherWebFeaturesLeaderboardModelsLeaderboardLeaderboardListResponseModel***](SWGNetherWebFeaturesLeaderboardModelsLeaderboardLeaderboardListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

