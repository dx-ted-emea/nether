# SWGAnalyticsApi

All URIs are relative to *https://localhost/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**analyticsActiveSessionsDailyGet**](SWGAnalyticsApi.md#analyticsactivesessionsdailyget) | **GET** /analytics/active-sessions/daily | 
[**analyticsActiveSessionsMonthlyGet**](SWGAnalyticsApi.md#analyticsactivesessionsmonthlyget) | **GET** /analytics/active-sessions/monthly | 
[**analyticsActiveSessionsYearlyGet**](SWGAnalyticsApi.md#analyticsactivesessionsyearlyget) | **GET** /analytics/active-sessions/yearly | 
[**analyticsActiveUsersDailyGet**](SWGAnalyticsApi.md#analyticsactiveusersdailyget) | **GET** /analytics/active-users/daily | 
[**analyticsActiveUsersMonthlyGet**](SWGAnalyticsApi.md#analyticsactiveusersmonthlyget) | **GET** /analytics/active-users/monthly | 
[**analyticsActiveUsersYearlyGet**](SWGAnalyticsApi.md#analyticsactiveusersyearlyget) | **GET** /analytics/active-users/yearly | 
[**analyticsDurationsByNameDailyGet**](SWGAnalyticsApi.md#analyticsdurationsbynamedailyget) | **GET** /analytics/durations/{name}/daily | 
[**analyticsDurationsByNameMonthlyGet**](SWGAnalyticsApi.md#analyticsdurationsbynamemonthlyget) | **GET** /analytics/durations/{name}/monthly | 
[**analyticsDurationsByNameYearlyGet**](SWGAnalyticsApi.md#analyticsdurationsbynameyearlyget) | **GET** /analytics/durations/{name}/yearly | 
[**analyticsGameDurationsDailyGet**](SWGAnalyticsApi.md#analyticsgamedurationsdailyget) | **GET** /analytics/game-durations/daily | 
[**analyticsGameDurationsMonthlyGet**](SWGAnalyticsApi.md#analyticsgamedurationsmonthlyget) | **GET** /analytics/game-durations/monthly | 
[**analyticsGameDurationsYearlyGet**](SWGAnalyticsApi.md#analyticsgamedurationsyearlyget) | **GET** /analytics/game-durations/yearly | 
[**analyticsLevelDropOffsDailyGet**](SWGAnalyticsApi.md#analyticsleveldropoffsdailyget) | **GET** /analytics/level-drop-offs/daily | 
[**analyticsLevelDropOffsMonthlyGet**](SWGAnalyticsApi.md#analyticsleveldropoffsmonthlyget) | **GET** /analytics/level-drop-offs/monthly | 
[**analyticsLevelDropOffsYearlyGet**](SWGAnalyticsApi.md#analyticsleveldropoffsyearlyget) | **GET** /analytics/level-drop-offs/yearly | 


# **analyticsActiveSessionsDailyGet**
```objc
-(NSURLSessionTask*) analyticsActiveSessionsDailyGetWithCompletionHandler: 
        (void (^)(SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGAnalyticsApi*apiInstance = [[SWGAnalyticsApi alloc] init];

[apiInstance analyticsActiveSessionsDailyGetWithCompletionHandler: 
          ^(SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGAnalyticsApi->analyticsActiveSessionsDailyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel***](SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsActiveSessionsMonthlyGet**
```objc
-(NSURLSessionTask*) analyticsActiveSessionsMonthlyGetWithCompletionHandler: 
        (void (^)(SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGAnalyticsApi*apiInstance = [[SWGAnalyticsApi alloc] init];

[apiInstance analyticsActiveSessionsMonthlyGetWithCompletionHandler: 
          ^(SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGAnalyticsApi->analyticsActiveSessionsMonthlyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel***](SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsActiveSessionsYearlyGet**
```objc
-(NSURLSessionTask*) analyticsActiveSessionsYearlyGetWithCompletionHandler: 
        (void (^)(SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGAnalyticsApi*apiInstance = [[SWGAnalyticsApi alloc] init];

[apiInstance analyticsActiveSessionsYearlyGetWithCompletionHandler: 
          ^(SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGAnalyticsApi->analyticsActiveSessionsYearlyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel***](SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsActiveUsersDailyGet**
```objc
-(NSURLSessionTask*) analyticsActiveUsersDailyGetWithCompletionHandler: 
        (void (^)(SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGAnalyticsApi*apiInstance = [[SWGAnalyticsApi alloc] init];

[apiInstance analyticsActiveUsersDailyGetWithCompletionHandler: 
          ^(SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGAnalyticsApi->analyticsActiveUsersDailyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel***](SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsActiveUsersMonthlyGet**
```objc
-(NSURLSessionTask*) analyticsActiveUsersMonthlyGetWithCompletionHandler: 
        (void (^)(SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGAnalyticsApi*apiInstance = [[SWGAnalyticsApi alloc] init];

[apiInstance analyticsActiveUsersMonthlyGetWithCompletionHandler: 
          ^(SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGAnalyticsApi->analyticsActiveUsersMonthlyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel***](SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsActiveUsersYearlyGet**
```objc
-(NSURLSessionTask*) analyticsActiveUsersYearlyGetWithCompletionHandler: 
        (void (^)(SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGAnalyticsApi*apiInstance = [[SWGAnalyticsApi alloc] init];

[apiInstance analyticsActiveUsersYearlyGetWithCompletionHandler: 
          ^(SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGAnalyticsApi->analyticsActiveUsersYearlyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel***](SWGNetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsDurationsByNameDailyGet**
```objc
-(NSURLSessionTask*) analyticsDurationsByNameDailyGetWithName: (NSString*) name
        completionHandler: (void (^)(SWGNetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* name = @"name_example"; // 

SWGAnalyticsApi*apiInstance = [[SWGAnalyticsApi alloc] init];

[apiInstance analyticsDurationsByNameDailyGetWithName:name
          completionHandler: ^(SWGNetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGAnalyticsApi->analyticsDurationsByNameDailyGet: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **NSString***|  | 

### Return type

[**SWGNetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel***](SWGNetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsDurationsByNameMonthlyGet**
```objc
-(NSURLSessionTask*) analyticsDurationsByNameMonthlyGetWithName: (NSString*) name
        completionHandler: (void (^)(SWGNetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* name = @"name_example"; // 

SWGAnalyticsApi*apiInstance = [[SWGAnalyticsApi alloc] init];

[apiInstance analyticsDurationsByNameMonthlyGetWithName:name
          completionHandler: ^(SWGNetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGAnalyticsApi->analyticsDurationsByNameMonthlyGet: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **NSString***|  | 

### Return type

[**SWGNetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel***](SWGNetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsDurationsByNameYearlyGet**
```objc
-(NSURLSessionTask*) analyticsDurationsByNameYearlyGetWithName: (NSString*) name
        completionHandler: (void (^)(SWGNetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* name = @"name_example"; // 

SWGAnalyticsApi*apiInstance = [[SWGAnalyticsApi alloc] init];

[apiInstance analyticsDurationsByNameYearlyGetWithName:name
          completionHandler: ^(SWGNetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGAnalyticsApi->analyticsDurationsByNameYearlyGet: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **NSString***|  | 

### Return type

[**SWGNetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel***](SWGNetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsGameDurationsDailyGet**
```objc
-(NSURLSessionTask*) analyticsGameDurationsDailyGetWithCompletionHandler: 
        (void (^)(SWGNetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGAnalyticsApi*apiInstance = [[SWGAnalyticsApi alloc] init];

[apiInstance analyticsGameDurationsDailyGetWithCompletionHandler: 
          ^(SWGNetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGAnalyticsApi->analyticsGameDurationsDailyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SWGNetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel***](SWGNetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsGameDurationsMonthlyGet**
```objc
-(NSURLSessionTask*) analyticsGameDurationsMonthlyGetWithCompletionHandler: 
        (void (^)(SWGNetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGAnalyticsApi*apiInstance = [[SWGAnalyticsApi alloc] init];

[apiInstance analyticsGameDurationsMonthlyGetWithCompletionHandler: 
          ^(SWGNetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGAnalyticsApi->analyticsGameDurationsMonthlyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SWGNetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel***](SWGNetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsGameDurationsYearlyGet**
```objc
-(NSURLSessionTask*) analyticsGameDurationsYearlyGetWithCompletionHandler: 
        (void (^)(SWGNetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGAnalyticsApi*apiInstance = [[SWGAnalyticsApi alloc] init];

[apiInstance analyticsGameDurationsYearlyGetWithCompletionHandler: 
          ^(SWGNetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGAnalyticsApi->analyticsGameDurationsYearlyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SWGNetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel***](SWGNetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsLevelDropOffsDailyGet**
```objc
-(NSURLSessionTask*) analyticsLevelDropOffsDailyGetWithCompletionHandler: 
        (void (^)(SWGNetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGAnalyticsApi*apiInstance = [[SWGAnalyticsApi alloc] init];

[apiInstance analyticsLevelDropOffsDailyGetWithCompletionHandler: 
          ^(SWGNetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGAnalyticsApi->analyticsLevelDropOffsDailyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SWGNetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel***](SWGNetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsLevelDropOffsMonthlyGet**
```objc
-(NSURLSessionTask*) analyticsLevelDropOffsMonthlyGetWithCompletionHandler: 
        (void (^)(SWGNetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGAnalyticsApi*apiInstance = [[SWGAnalyticsApi alloc] init];

[apiInstance analyticsLevelDropOffsMonthlyGetWithCompletionHandler: 
          ^(SWGNetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGAnalyticsApi->analyticsLevelDropOffsMonthlyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SWGNetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel***](SWGNetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsLevelDropOffsYearlyGet**
```objc
-(NSURLSessionTask*) analyticsLevelDropOffsYearlyGetWithCompletionHandler: 
        (void (^)(SWGNetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
SWGDefaultConfiguration *apiConfig = [SWGDefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



SWGAnalyticsApi*apiInstance = [[SWGAnalyticsApi alloc] init];

[apiInstance analyticsLevelDropOffsYearlyGetWithCompletionHandler: 
          ^(SWGNetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGAnalyticsApi->analyticsLevelDropOffsYearlyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SWGNetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel***](SWGNetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

