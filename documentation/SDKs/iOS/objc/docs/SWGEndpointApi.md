# SWGEndpointApi

All URIs are relative to *https://localhost/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**endpointGet**](SWGEndpointApi.md#endpointget) | **GET** /endpoint | 


# **endpointGet**
```objc
-(NSURLSessionTask*) endpointGetWithCompletionHandler: 
        (void (^)(SWGNetherWebFeaturesAnalyticsAnalyticsEndpointInfoResponseModel* output, NSError* error)) handler;
```



### Example 
```objc


SWGEndpointApi*apiInstance = [[SWGEndpointApi alloc] init];

[apiInstance endpointGetWithCompletionHandler: 
          ^(SWGNetherWebFeaturesAnalyticsAnalyticsEndpointInfoResponseModel* output, NSError* error) {
                        if (output) {
                            NSLog(@"%@", output);
                        }
                        if (error) {
                            NSLog(@"Error calling SWGEndpointApi->endpointGet: %@", error);
                        }
                    }];
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SWGNetherWebFeaturesAnalyticsAnalyticsEndpointInfoResponseModel***](SWGNetherWebFeaturesAnalyticsAnalyticsEndpointInfoResponseModel.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

