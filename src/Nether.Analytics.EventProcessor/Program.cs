using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nether.Analytics.EventProcessor
{
    public class Program
    {
        private const string InputEventHubName = "analytics";
        private const string IntermediateEventHubName = "nether-intermediate";

        static void Main(string[] args)
        {
            // Endpoint = sb://nether.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=h16jv6nc0bVfgdWrZp7f5Fpau4jaSu2YH+U2xg0YI14=


            var eventHubConfig = new EventHubConfiguration();
            eventHubConfig.AddReceiver(InputEventHubName, "Endpoint=sb://nether.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=h16jv6nc0bVfgdWrZp7f5Fpau4jaSu2YH+U2xg0YI14=");
            //eventHubConfig.AddSender(IntermediateEventHubName, "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=SendRule;SharedAccessKey=xxxxxxxx");


            var webJobDashboardConnectionString = "DefaultEndpointsProtocol=https;AccountName=netherdashboard;AccountKey=oT30a8/BSwTFg/4GGWLPCeGIHBfgDcMf9zEThKHlY4hjUNy3sYUTSWXWa3yJMoX2lvTnWSIrjtwU9kg9YaL0Qw==";
            var jobHostConfig = new JobHostConfiguration(webJobDashboardConnectionString);
            jobHostConfig.UseEventHub(eventHubConfig);

            var host = new JobHost(jobHostConfig);
            host.RunAndBlock();
        }

        public static void HandleOne([EventHubTrigger(InputEventHubName)] string data)
        {
            Console.WriteLine(data);
        }

        //static void SendOne([EventHub("MyHub")] out EventData output);

    }

    public class BlobWriter
    {
        private const string BlobStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=netherdashboard;AccountKey=oT30a8/BSwTFg/4GGWLPCeGIHBfgDcMf9zEThKHlY4hjUNy3sYUTSWXWa3yJMoX2lvTnWSIrjtwU9kg9YaL0Qw==";
        private const string ContainerName = "rawdata";
        public void WriteToCsvBlob(string eventType, DateTime date, string blobName, string[] data)
        {

            var storageAccount = CloudStorageAccount.Parse(BlobStorageConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(ContainerName);
            container.CreateIfNotExists();
            var blob = container.GetAppendBlobReference("test.csv");
            blob.FetchAttributes();

        }
    }
}
