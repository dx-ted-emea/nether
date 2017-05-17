// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using NGeoHash;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Nether.Analytics.Logging;

namespace Nether.Analytics.GeoLocation
{
    public class BingLocationLookupHandler : IMessageHandler
    {
        private string _bingMapsKey;
        private string _latProperty;
        private string _lonProperty;
        private IGeoHashCacheProvider _geoHashCacheProvider;

        private ILogger _logger { get; } = ApplicationLogging.CreateLogger<BingLocationLookupHandler>();
        private EventId _messageErrorLogEventId = new EventId(9); // <-- TODO: maybe come up with a set of level codes/event ids?


        public BingLocationLookupHandler(string bingMapsKey, IGeoHashCacheProvider geoHashCacheProvider, int geoHashPrecision,
            string latProperty = "lat", string lonProperty = "lon")
        {
            _bingMapsKey = bingMapsKey;
            _latProperty = latProperty;
            _lonProperty = lonProperty;
            _geoHashCacheProvider = geoHashCacheProvider;
            _geoHashCacheProvider.Precision = geoHashPrecision;
        }

        public async Task<MessageHandlerResults> ProcessMessageAsync(Message msg, string pipelineName, int idx)
        {
            double lat;
            double lon;

            //TODO: Catch more specific error if property doesn't exist or use another method to get the properties
            try
            {
                lat = double.Parse(msg.Properties[_latProperty]);
                lon = double.Parse(msg.Properties[_lonProperty]);
            }
            catch (Exception)
            {
                _logger.LogError($"Unable to find required properties: '{_latProperty}' and '{_lonProperty}' on message");
                return MessageHandlerResults.FailStopProcessing;
            }

            var geoHash = GeoHash.EncodeInt(lat, lon, _geoHashCacheProvider.Precision);

            BingResult bingParsingResult;
            //if we have the result in the cache, fetch it
            if (_geoHashCacheProvider.ContainsGeoHash(geoHash))
            {
                bingParsingResult = _geoHashCacheProvider[geoHash];
                _logger.LogInformation("Found in cache");
            }
            //else, query bing directly
            else
            {
                _logger.LogInformation("Not found in cache");
                double geoHashCenterLat, geoHashCenterLon;

                //get the center of the geoHash in order to call Bing API with this {lat,lon}
                var decodedGeoHash = GeoHash.DecodeInt(geoHash, _geoHashCacheProvider.Precision);
                geoHashCenterLat = decodedGeoHash.Coordinates.Lat;
                geoHashCenterLon = decodedGeoHash.Coordinates.Lon;

                var bingUrl = $"http://dev.virtualearth.net/REST/v1/Locations/{geoHashCenterLat},{geoHashCenterLon}?key={_bingMapsKey}";
                string bingResult;

                try
                {
                    var client = new HttpClient();
                    bingResult = await client.GetStringAsync(bingUrl);
                }
                catch (Exception ex)
                {
                    _logger.LogError(_messageErrorLogEventId, ex, "An exception occurred while calling Bing to Lookup coordinates");

                    return MessageHandlerResults.FailStopProcessing;
                }

                try
                {
                    var json = JObject.Parse(bingResult);
                    var address = json["resourceSets"][0]["resources"][0]["address"];

                    //create a bing parsing result instance and cache it
                    bingParsingResult = new BingResult() { City = (string)address["locality"], Country = (string)address["countryRegion"], District = (string)address["adminDistrict"] };
                    _geoHashCacheProvider.AppendToCache(geoHash, bingParsingResult);
                }
                catch (Exception ex)
                {
                    _logger.LogError(_messageErrorLogEventId, ex, "An exception occurred while trying to parse Location Lookup results from Bing");

                    return MessageHandlerResults.FailStopProcessing;
                }
            }

            //add values to msg
            msg.Properties.Add("country", bingParsingResult.Country);
            msg.Properties.Add("district", bingParsingResult.District);
            msg.Properties.Add("city", bingParsingResult.City);

            return MessageHandlerResults.Success;
        }
    }

    public class BingResult
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
    }
}
