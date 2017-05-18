# LeaderboardApi

All URIs are relative to *https://localhost/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**leaderboardsByNameGet**](LeaderboardApi.md#leaderboardsbynameget) | **GET** /leaderboards/{name} | Gets leaderboard by leaderboard configured name
[**leaderboardsGet**](LeaderboardApi.md#leaderboardsget) | **GET** /leaderboards | Gets leaderboard by leaderboard configured name


# **leaderboardsByNameGet**
```objc
-(NSURLSessionTask*) leaderboardsByNameGetWithName: (NSString*) name
        completionHandler: (void (^)(NetherWebFeaturesLeaderboardModelsLeaderboardLeaderboardGetResponseModel* output, NSError* error)) handler;
```

Gets leaderboard by leaderboard configured name

### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* name = @"name_example"; // Name of the leaderboard

LeaderboardApi*apiInstance = [[LeaderboardApi alloc] init];

// Gets leaderboard by leaderboard configured name
[apiInstance leaderboardsByNameGetWithName:name
          completionHandler: ^(NetherWebFeaturesLeaderboardModelsLeaderboardLeaderboardGetResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling LeaderboardApi->leaderboardsByNameGet: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **NSString***| Name of the leaderboard | 

### Return type

[**NetherWebFeaturesLeaderboardModelsLeaderboardLeaderboardGetResponseModel***](NetherWebFeaturesLeaderboardModelsLeaderboardLeaderboardGetResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **leaderboardsGet**
```objc
-(NSURLSessionTask*) leaderboardsGetWithCompletionHandler: 
        (void (^)(NetherWebFeaturesLeaderboardModelsLeaderboardLeaderboardListResponseModel* output, NSError* error)) handler;
```

Gets leaderboard by leaderboard configured name

### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



LeaderboardApi*apiInstance = [[LeaderboardApi alloc] init];

// Gets leaderboard by leaderboard configured name
[apiInstance leaderboardsGetWithCompletionHandler: 
          ^(NetherWebFeaturesLeaderboardModelsLeaderboardLeaderboardListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling LeaderboardApi->leaderboardsGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**NetherWebFeaturesLeaderboardModelsLeaderboardLeaderboardListResponseModel***](NetherWebFeaturesLeaderboardModelsLeaderboardLeaderboardListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

