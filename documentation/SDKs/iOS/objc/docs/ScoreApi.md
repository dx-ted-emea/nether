# ScoreApi

All URIs are relative to *https://localhost/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**scoresDelete**](ScoreApi.md#scoresdelete) | **DELETE** /scores | Deletes all score achievements for the logged in user
[**scoresPost**](ScoreApi.md#scorespost) | **POST** /scores | Posts a new score of currently logged in player


# **scoresDelete**
```objc
-(NSURLSessionTask*) scoresDeleteWithCompletionHandler: 
        (void (^)(NSError* error)) handler;
```

Deletes all score achievements for the logged in user

### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



ScoreApi*apiInstance = [[ScoreApi alloc] init];

// Deletes all score achievements for the logged in user
[apiInstance scoresDeleteWithCompletionHandler: 
          ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling ScoreApi->scoresDelete: %@", error);
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
-(NSURLSessionTask*) scoresPostWithRequest: (NetherWebFeaturesLeaderboardModelsScoreScorePostRequestModel*) request
        completionHandler: (void (^)(NSError* error)) handler;
```

Posts a new score of currently logged in player

### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NetherWebFeaturesLeaderboardModelsScoreScorePostRequestModel* request = [[NetherWebFeaturesLeaderboardModelsScoreScorePostRequestModel alloc] init]; // Achieved score, must be positive (optional)

ScoreApi*apiInstance = [[ScoreApi alloc] init];

// Posts a new score of currently logged in player
[apiInstance scoresPostWithRequest:request
          completionHandler: ^(NSError* error) {
                        if (error) {
                            NSLog(@"Error calling ScoreApi->scoresPost: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **request** | [**NetherWebFeaturesLeaderboardModelsScoreScorePostRequestModel***](NetherWebFeaturesLeaderboardModelsScoreScorePostRequestModel*.md)| Achieved score, must be positive | [optional] 

### Return type

void (empty response body)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/json-patch+json, text/plain
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

