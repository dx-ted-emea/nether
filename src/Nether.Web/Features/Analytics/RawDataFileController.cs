using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

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
            return GetRawDataFile("");
        }

        // GET api/values/20170120
        [HttpGet("{dateFilter}")]
        public IEnumerable<RawDataFile> Get(string dateFilter)
        {
            return GetRawDataFile(dateFilter);
        }

        private RawDataFile[] GetRawDataFile(string datefilter)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(storageConnectionString);
            CloudBlobClient blobClient = account.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);
            // TODO: create container Sas list blobs and create Sas donwload Url

            return new RawDataFile[] { };
        }
    }
}
