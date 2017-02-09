// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus;

namespace Nether.Analytics.EventProcessor
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    internal static class Program
    {
        private static string _webJobDashboardAndStorageConnectionString;
        private static string _ingestEventHubConnectionString;
        private static string _ingestEventHubName;

        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        public static void Main()
        {
            Greet();

            var jobHostConfig = Configure();

            // Run and block
            var host = new JobHost(jobHostConfig);
            host.RunAndBlock();
        }

        private static JobHostConfiguration Configure()
        {
            //TODO: Make all configuration work in the same way across Nether
            Console.WriteLine("Configuring WebJob (from Environment Variables");

            _webJobDashboardAndStorageConnectionString =
                Environment.GetEnvironmentVariable("NETHER_WEBJOB_DASHBOARD_AND_STORAGE_CONNECTIONSTRING");
            Console.WriteLine($"webJobDashboardAndStorageConnectionString:");
            Console.WriteLine($"  {_webJobDashboardAndStorageConnectionString}");

            _ingestEventHubConnectionString =
                Environment.GetEnvironmentVariable("NETHER_INGEST_EVENTHUB_CONNECTIONSTRING");
            Console.WriteLine($"ingestEventHubConnectionString:");
            Console.WriteLine($"  {_ingestEventHubConnectionString}");

            _ingestEventHubName =
                Environment.GetEnvironmentVariable("NETHER_INGEST_EVENTHUB_NAME");
            Console.WriteLine($"ingestEventHubName:");
            Console.WriteLine($"  {_ingestEventHubName}");

            Console.WriteLine();

            // Setup Web Job Config
            var jobHostConfig = new JobHostConfiguration(_webJobDashboardAndStorageConnectionString);
            var eventHubConfig = new EventHubConfiguration();
            eventHubConfig.AddReceiver(_ingestEventHubName, _ingestEventHubConnectionString);

            jobHostConfig.UseEventHub(eventHubConfig);

            if (jobHostConfig.IsDevelopment)
            {
                jobHostConfig.UseDevelopmentSettings();
            }

            return jobHostConfig;

        }

        private static void Greet()
        {
            Console.WriteLine();
            Console.WriteLine(@" _   _      _   _               ");
            Console.WriteLine(@"| \ | | ___| |_| |__   ___ _ __ ");
            Console.WriteLine(@"|  \| |/ _ \ __| '_ \ / _ \ '__|");
            Console.WriteLine(@"| |\  |  __/ |_| | | |  __/ |   ");
            Console.WriteLine(@"|_| \_|\___|\__|_| |_|\___|_|   ");
            Console.WriteLine(@"- Analytics Event Processor -");
            Console.WriteLine();
        }
    }
}
