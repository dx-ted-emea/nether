# AnalyticsApi

All URIs are relative to *https://localhost/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**analyticsActiveSessionsDailyGet**](AnalyticsApi.md#analyticsactivesessionsdailyget) | **GET** /analytics/active-sessions/daily | 
[**analyticsActiveSessionsMonthlyGet**](AnalyticsApi.md#analyticsactivesessionsmonthlyget) | **GET** /analytics/active-sessions/monthly | 
[**analyticsActiveSessionsYearlyGet**](AnalyticsApi.md#analyticsactivesessionsyearlyget) | **GET** /analytics/active-sessions/yearly | 
[**analyticsActiveUsersDailyGet**](AnalyticsApi.md#analyticsactiveusersdailyget) | **GET** /analytics/active-users/daily | 
[**analyticsActiveUsersMonthlyGet**](AnalyticsApi.md#analyticsactiveusersmonthlyget) | **GET** /analytics/active-users/monthly | 
[**analyticsActiveUsersYearlyGet**](AnalyticsApi.md#analyticsactiveusersyearlyget) | **GET** /analytics/active-users/yearly | 
[**analyticsDurationsByNameDailyGet**](AnalyticsApi.md#analyticsdurationsbynamedailyget) | **GET** /analytics/durations/{name}/daily | 
[**analyticsDurationsByNameMonthlyGet**](AnalyticsApi.md#analyticsdurationsbynamemonthlyget) | **GET** /analytics/durations/{name}/monthly | 
[**analyticsDurationsByNameYearlyGet**](AnalyticsApi.md#analyticsdurationsbynameyearlyget) | **GET** /analytics/durations/{name}/yearly | 
[**analyticsGameDurationsDailyGet**](AnalyticsApi.md#analyticsgamedurationsdailyget) | **GET** /analytics/game-durations/daily | 
[**analyticsGameDurationsMonthlyGet**](AnalyticsApi.md#analyticsgamedurationsmonthlyget) | **GET** /analytics/game-durations/monthly | 
[**analyticsGameDurationsYearlyGet**](AnalyticsApi.md#analyticsgamedurationsyearlyget) | **GET** /analytics/game-durations/yearly | 
[**analyticsLevelDropOffsDailyGet**](AnalyticsApi.md#analyticsleveldropoffsdailyget) | **GET** /analytics/level-drop-offs/daily | 
[**analyticsLevelDropOffsMonthlyGet**](AnalyticsApi.md#analyticsleveldropoffsmonthlyget) | **GET** /analytics/level-drop-offs/monthly | 
[**analyticsLevelDropOffsYearlyGet**](AnalyticsApi.md#analyticsleveldropoffsyearlyget) | **GET** /analytics/level-drop-offs/yearly | 


# **analyticsActiveSessionsDailyGet**
```objc
-(NSURLSessionTask*) analyticsActiveSessionsDailyGetWithCompletionHandler: 
        (void (^)(NetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



AnalyticsApi*apiInstance = [[AnalyticsApi alloc] init];

[apiInstance analyticsActiveSessionsDailyGetWithCompletionHandler: 
          ^(NetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling AnalyticsApi->analyticsActiveSessionsDailyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**NetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel***](NetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsActiveSessionsMonthlyGet**
```objc
-(NSURLSessionTask*) analyticsActiveSessionsMonthlyGetWithCompletionHandler: 
        (void (^)(NetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



AnalyticsApi*apiInstance = [[AnalyticsApi alloc] init];

[apiInstance analyticsActiveSessionsMonthlyGetWithCompletionHandler: 
          ^(NetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling AnalyticsApi->analyticsActiveSessionsMonthlyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**NetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel***](NetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsActiveSessionsYearlyGet**
```objc
-(NSURLSessionTask*) analyticsActiveSessionsYearlyGetWithCompletionHandler: 
        (void (^)(NetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



AnalyticsApi*apiInstance = [[AnalyticsApi alloc] init];

[apiInstance analyticsActiveSessionsYearlyGetWithCompletionHandler: 
          ^(NetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling AnalyticsApi->analyticsActiveSessionsYearlyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**NetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel***](NetherWebFeaturesAnalyticsModelsAnalyticsActiveSessionsListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsActiveUsersDailyGet**
```objc
-(NSURLSessionTask*) analyticsActiveUsersDailyGetWithCompletionHandler: 
        (void (^)(NetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



AnalyticsApi*apiInstance = [[AnalyticsApi alloc] init];

[apiInstance analyticsActiveUsersDailyGetWithCompletionHandler: 
          ^(NetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling AnalyticsApi->analyticsActiveUsersDailyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**NetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel***](NetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsActiveUsersMonthlyGet**
```objc
-(NSURLSessionTask*) analyticsActiveUsersMonthlyGetWithCompletionHandler: 
        (void (^)(NetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



AnalyticsApi*apiInstance = [[AnalyticsApi alloc] init];

[apiInstance analyticsActiveUsersMonthlyGetWithCompletionHandler: 
          ^(NetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling AnalyticsApi->analyticsActiveUsersMonthlyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**NetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel***](NetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsActiveUsersYearlyGet**
```objc
-(NSURLSessionTask*) analyticsActiveUsersYearlyGetWithCompletionHandler: 
        (void (^)(NetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



AnalyticsApi*apiInstance = [[AnalyticsApi alloc] init];

[apiInstance analyticsActiveUsersYearlyGetWithCompletionHandler: 
          ^(NetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling AnalyticsApi->analyticsActiveUsersYearlyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**NetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel***](NetherWebFeaturesAnalyticsModelsAnalyticsActiveUsersListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsDurationsByNameDailyGet**
```objc
-(NSURLSessionTask*) analyticsDurationsByNameDailyGetWithName: (NSString*) name
        completionHandler: (void (^)(NetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* name = @"name_example"; // 

AnalyticsApi*apiInstance = [[AnalyticsApi alloc] init];

[apiInstance analyticsDurationsByNameDailyGetWithName:name
          completionHandler: ^(NetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling AnalyticsApi->analyticsDurationsByNameDailyGet: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **NSString***|  | 

### Return type

[**NetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel***](NetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsDurationsByNameMonthlyGet**
```objc
-(NSURLSessionTask*) analyticsDurationsByNameMonthlyGetWithName: (NSString*) name
        completionHandler: (void (^)(NetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* name = @"name_example"; // 

AnalyticsApi*apiInstance = [[AnalyticsApi alloc] init];

[apiInstance analyticsDurationsByNameMonthlyGetWithName:name
          completionHandler: ^(NetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling AnalyticsApi->analyticsDurationsByNameMonthlyGet: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **NSString***|  | 

### Return type

[**NetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel***](NetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsDurationsByNameYearlyGet**
```objc
-(NSURLSessionTask*) analyticsDurationsByNameYearlyGetWithName: (NSString*) name
        completionHandler: (void (^)(NetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];


NSString* name = @"name_example"; // 

AnalyticsApi*apiInstance = [[AnalyticsApi alloc] init];

[apiInstance analyticsDurationsByNameYearlyGetWithName:name
          completionHandler: ^(NetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling AnalyticsApi->analyticsDurationsByNameYearlyGet: %@", error);
                        }
                    }];
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **NSString***|  | 

### Return type

[**NetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel***](NetherWebFeaturesAnalyticsModelsAnalyticsDurationsListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsGameDurationsDailyGet**
```objc
-(NSURLSessionTask*) analyticsGameDurationsDailyGetWithCompletionHandler: 
        (void (^)(NetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



AnalyticsApi*apiInstance = [[AnalyticsApi alloc] init];

[apiInstance analyticsGameDurationsDailyGetWithCompletionHandler: 
          ^(NetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling AnalyticsApi->analyticsGameDurationsDailyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**NetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel***](NetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsGameDurationsMonthlyGet**
```objc
-(NSURLSessionTask*) analyticsGameDurationsMonthlyGetWithCompletionHandler: 
        (void (^)(NetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



AnalyticsApi*apiInstance = [[AnalyticsApi alloc] init];

[apiInstance analyticsGameDurationsMonthlyGetWithCompletionHandler: 
          ^(NetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling AnalyticsApi->analyticsGameDurationsMonthlyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**NetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel***](NetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsGameDurationsYearlyGet**
```objc
-(NSURLSessionTask*) analyticsGameDurationsYearlyGetWithCompletionHandler: 
        (void (^)(NetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



AnalyticsApi*apiInstance = [[AnalyticsApi alloc] init];

[apiInstance analyticsGameDurationsYearlyGetWithCompletionHandler: 
          ^(NetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling AnalyticsApi->analyticsGameDurationsYearlyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**NetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel***](NetherWebFeaturesAnalyticsModelsAnalyticsGameDurationsListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsLevelDropOffsDailyGet**
```objc
-(NSURLSessionTask*) analyticsLevelDropOffsDailyGetWithCompletionHandler: 
        (void (^)(NetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



AnalyticsApi*apiInstance = [[AnalyticsApi alloc] init];

[apiInstance analyticsLevelDropOffsDailyGetWithCompletionHandler: 
          ^(NetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling AnalyticsApi->analyticsLevelDropOffsDailyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**NetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel***](NetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsLevelDropOffsMonthlyGet**
```objc
-(NSURLSessionTask*) analyticsLevelDropOffsMonthlyGetWithCompletionHandler: 
        (void (^)(NetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



AnalyticsApi*apiInstance = [[AnalyticsApi alloc] init];

[apiInstance analyticsLevelDropOffsMonthlyGetWithCompletionHandler: 
          ^(NetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling AnalyticsApi->analyticsLevelDropOffsMonthlyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**NetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel***](NetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **analyticsLevelDropOffsYearlyGet**
```objc
-(NSURLSessionTask*) analyticsLevelDropOffsYearlyGetWithCompletionHandler: 
        (void (^)(NetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel* output, NSError* error)) handler;
```



### Example 
```objc
DefaultConfiguration *apiConfig = [DefaultConfiguration sharedConfig];

// Configure OAuth2 access token for authorization: (authentication scheme: oauth2)
[apiConfig setAccessToken:@"YOUR_ACCESS_TOKEN"];



AnalyticsApi*apiInstance = [[AnalyticsApi alloc] init];

[apiInstance analyticsLevelDropOffsYearlyGetWithCompletionHandler: 
          ^(NetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling AnalyticsApi->analyticsLevelDropOffsYearlyGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**NetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel***](NetherWebFeaturesAnalyticsModelsAnalyticsLevelDropOffListResponseModel.md)

### Authorization

[oauth2](../README.md#oauth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

