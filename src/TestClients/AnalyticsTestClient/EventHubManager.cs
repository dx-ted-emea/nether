// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;

namespace AnalyticsTestClient.Utils
{
    public static class EventHubManager
    {
        private static EventHubClient _client;
        private static string lastMsg;

        static EventHubManager()
        {
            Console.WriteLine($"Connecting to EventHub [{ConfigCache.EventHubName}]");
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(ConfigCache.EventHubConnectionString)
            {
                EntityPath = ConfigCache.EventHubName
            };

            _client = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());

        }

        public static async Task SendMessageToEventHub(string msg)
        {

            Console.WriteLine($"Sending message...");
            Console.WriteLine(msg);
            await _client.SendAsync(new EventData(Encoding.UTF8.GetBytes(msg)));
            Console.WriteLine("Message sent!");
            lastMsg = msg;
        }

        public static async Task ReSendLastMessageToEventHub()
        {
            if (!string.IsNullOrWhiteSpace(lastMsg))
                await SendMessageToEventHub(lastMsg);
        }

        public static async Task CloseConnectionToEventHub()
        {
            await _client.CloseAsync();
        }


    }
}