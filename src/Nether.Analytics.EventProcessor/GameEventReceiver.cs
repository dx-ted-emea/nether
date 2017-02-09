// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Microsoft.Azure.WebJobs.ServiceBus;
using Nether.Analytics.EventProcessor.Output.Blob;
using Nether.Analytics.EventProcessor.Output.EventHub;

namespace Nether.Analytics.EventProcessor
{
    /// <summary>
    /// Main class of the EventProcessor. This class has the required trigger(s) to
    /// get called by the WebJob SDK whenever there is a new Event to Process
    /// </summary>
    public static class GameEventReceiver
    {
        private static readonly GameEventRouter Router;

        static GameEventReceiver()
        {
            // Read Environment Variables for configuration
            // TODO: Fix configuration to be in line with other configuration in Nether

            Console.WriteLine("Configuring GameEventReceiver (from Environment Variables");

            var outputStorageAccountConnectionString = Environment.GetEnvironmentVariable("NETHER_ANALYTICS_STORAGE_CONNECTIONSTRING");
            Console.WriteLine($"outputStorageAccountConnectionString: {outputStorageAccountConnectionString}");

            var outputContainer = Environment.GetEnvironmentVariable("NETHER_ANALYTICS_STORAGE_CONTAINER");
            Console.WriteLine($"outputContainer: {outputContainer}");

            var outputEventHubConnectionString = Environment.GetEnvironmentVariable("NETHER_INTERMEDIATE_EVENTHUB_CONNECTIONSTRING");
            Console.WriteLine($"outputEventHubConnectionString: {outputEventHubConnectionString}");

            var outputEventHubName = Environment.GetEnvironmentVariable("NETHER_INTERMEDIATE_EVENTHUB_NAME");
            Console.WriteLine($"outputEventHubName: {outputEventHubName}");

            var maxBlobSize = 100 * 1024 * 1024;

            Console.WriteLine($"Max Blob Size: {maxBlobSize / 1024 / 1024}MB ({maxBlobSize}B)");
            Console.WriteLine();

            // Configure Blob Output
            var blobOutputManager = new BlobOutputManager(
                outputStorageAccountConnectionString,
                outputContainer,
                BlobOutputFolderStructure.YearMonthDay,
                maxBlobSize);

            // Configure EventHub Output
            var eventHubOutputManager = new EventHubOutputManager(outputEventHubConnectionString, outputEventHubName);

            // Setup Handler to use above configured output managers
            var handler = new GameEventHandler(blobOutputManager, eventHubOutputManager);

            // Configure Router to switch handeling to correct method depending on game event type
            Router = new GameEventRouter(GameEventHandler.ResolveEventType,
                GameEventHandler.UnknownGameEventFormatHandler,
                GameEventHandler.UnknownGameEventTypeHandler,
                handler.Flush);

            Router.RegEventTypeAction("count", "1.0.0", handler.HandleCountEvent);
            Router.RegEventTypeAction("game-heartbeat", "1.0.0", handler.HandleGameHeartbeat);
            Router.RegEventTypeAction("game-start", "1.0.0", handler.HandleGameStartEvent);
            Router.RegEventTypeAction("game-stop", "1.0.0", handler.HandleGameStopEvent);
            Router.RegEventTypeAction("location", "1.0.0", handler.HandleLocationEvent);
            Router.RegEventTypeAction("score", "1.0.0", handler.HandleScoreEvent);
            Router.RegEventTypeAction("start", "1.0.0", handler.HandleStartEvent);
            Router.RegEventTypeAction("stop", "1.0.0", handler.HandleStopEvent);
            Router.RegEventTypeAction("generic", "1.0.0", handler.HandleGenericEvent);
        }


        //public void HandleOne([EventHubTrigger("ingest")] string data)
        //{
        //    //TODO: Figure out how to configure above EventHubName now named ingest

        //    // Forward data to "router" in order to handle the event
        //    _router.HandleGameEvent(data);
        //}

        public static void HandleBatch([EventHubTrigger("ingest")] string[] events)
        {
            if (events.Length > 1)
                Console.WriteLine($"....Received batch of {events.Length} events");
            foreach (var e in events)
            {
                Router.HandleGameEvent(e);
            }

            Router.Flush();
        }
    }
}