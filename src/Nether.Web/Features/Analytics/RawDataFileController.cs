// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Blob.Protocol;


using Nether.Data.Analytics;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nether.Web.Features.Analytics
{
    [Route("api/[controller]")]
    public class RawDataFileController : Controller
    {
        // TODO: get from configuration
        string storageConnectionString = @"DefaultEndpointsProtocol=http;AccountName=account;AccountKey=key";
        string containerName = "analyticsdata";
        // GET: api/values
        [HttpGet]
        public IEnumerable<RawDataFile> Get()
        {
            return GetRawDataFile("").Result;
        }

        // GET api/values/20170120
        [HttpGet("{dateFilter}")]
        public IEnumerable<RawDataFile> Get(string dateFilter)
        {
            return GetRawDataFile(dateFilter).Result;
        }

        private async Task<IEnumerable<RawDataFile>> GetRawDataFile(string dateFilter)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(storageConnectionString);
            CloudBlobClient blobClient = account.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);
            // TODO: create container Sas and add create Sas donwload Url
            BlobContinuationToken continuationToken = null;
            List<IListBlobItem> results = new List<IListBlobItem>();
            do
            {
                var response = await blobContainer.ListBlobsSegmentedAsync(dateFilter, continuationToken);
                continuationToken = response.ContinuationToken;
                results.AddRange(response.Results);
            }
            while (continuationToken != null);
            List<RawDataFile> dataFileList = new List<RawDataFile>();
            foreach (var blobItem in results)
            {
                dataFileList.Add(new RawDataFile { Name = blobItem.Uri.LocalPath, Url = blobItem.Uri.ToString() });
            }

            return dataFileList;
        }

    }
}
