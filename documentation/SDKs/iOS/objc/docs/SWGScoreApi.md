# SWGScoreApi

All URIs are relative to *https://localhost/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**scoresDelete**](SWGScoreApi.md#scoresdelete) | **DELETE** /scores | Deletes all score achievements for the logged in user
[**scoresPost**](SWGScoreApi.md#scorespost) | **POST** /scores | Posts a new score of currently logged in player


# **scoresDelete**
```objc
-(NSURLSessionTask*) scoresDeleteWithCompletionHandler: 
        (void (^)(NSError* error)) handler;
```

Deletes all score achievements for the logged in user

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGScoreApi*apiInstance = [[SWGScoreApi alloc] init];

// Deletes all score achievements for the logged in user
[apiInstance scoresDeleteWithCompletionHandler: 
          ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling SWGScoreApi->scoresDelete: %@", error);
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

# **scoresPost**
```objc
-(NSURLSessionTask*) scoresPostWithRequest: (SWGNetherWebFeaturesLeaderboardModelsScoreScorePostRequestModel*) request
        completionHandler: (void (^)(NSError* error)) handler;
```

Posts a new score of currently logged in player

### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


SWGNetherWebFeaturesLeaderboardModelsScoreScorePostRequestModel* request = [[SWGNetherWebFeaturesLeaderboardModelsScoreScorePostRequestModel alloc] init]; // Achieved score, must be positive (optional)

SWGScoreApi*apiInstance = [[SWGScoreApi alloc] init];

// Posts a new score of currently logged in player
[apiInstance scoresPostWithRequest:request
          completionHandler: ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling SWGScoreApi->scoresPost: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **request** | [**SWGNetherWebFeaturesLeaderboardModelsScoreScorePostRequestModel***](SWGNetherWebFeaturesLeaderboardModelsScoreScorePostRequestModel.md)| Achieved score, must be positive | [optional] 

### Return type

void (empty response body)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/json-patch+json, text/plain
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

