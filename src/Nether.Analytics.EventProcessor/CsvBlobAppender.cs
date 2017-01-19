using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;

namespace Nether.Analytics.EventProcessor
{
    public interface IBlobAppender
    {
        void Append(string eventType, params string[] values);
    }

    class CsvBlobAppender : IBlobAppender
    {
        private static string currentBlobName = "Kristofer";

        public void Append(string eventType, params string[] values)
        {
            var storageAccount = CloudStorageAccount.Parse("");
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("");
            container.CreateIfNotExists();
            var blob = container.GetAppendBlobReference("test.csv");
            blob.FetchAttributes();

            //blob.AppendText();
        }

        private string FormatCsvRow(string eventType, params string[] values)
        {
            //var row = new 
            throw new NotImplementedException();
        }
    }
}
