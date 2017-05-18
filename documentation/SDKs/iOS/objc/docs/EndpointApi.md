# EndpointApi

All URIs are relative to *https://localhost/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**endpointGet**](EndpointApi.md#endpointget) | **GET** /endpoint | 


# **endpointGet**
```objc
-(NSURLSessionTask*) endpointGetWithCompletionHandler: 
        (void (^)(NetherWebFeaturesAnalyticsAnalyticsEndpointInfoResponseModel* output, NSError* error)) handler;
```



### Example 
```objc


EndpointApi*apiInstance = [[EndpointApi alloc] init];

[apiInstance endpointGetWithCompletionHandler: 
          ^(NetherWebFeaturesAnalyticsAnalyticsEndpointInfoResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling EndpointApi->endpointGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**NetherWebFeaturesAnalyticsAnalyticsEndpointInfoResponseModel***](NetherWebFeaturesAnalyticsAnalyticsEndpointInfoResponseModel.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

