using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.WindowsAzure.Storage.Core;
using Microsoft.WindowsAzure.Storage.Blob;

using Nether.Data.Analytics;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nether.Web.Features.Analytics
{
    // TODO: get from configuration
    string storageConnectionString = "";
    [Route("api/[controller]")]
    public class RawDataFileController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new RawDataFile[] { };
        }

        // GET api/values/20170120
        [HttpGet("{dateFilter}")]
        public string Get(string dateFilter)
        {
            return "value";
        }

    }
}
