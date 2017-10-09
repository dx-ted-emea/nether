// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nether.Ingest;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Nether.Test.ConsoleClient
{
    public class MainMenu : ConsoleMenu
    {
        private IAnalyticsClient _client;
        private static Random s_randonScore = new Random();

        public MainMenu(IAnalyticsClient client)
        {
            _client = client;

            Title = "Nether Analytics Test Client - Main Menu";

            MenuItems.Add('1', new ConsoleMenuItem("Send Typed Game Messages ...", () => { new SendTypedGameEventMenu(_client).Show(); }));
            MenuItems.Add('2', new ConsoleMenuItem("Send Game Scores", SendScoreEvent));
            MenuItems.Add('3', new ConsoleMenuItem("Send Custom Game Message", SendCustomGameEvent));
            MenuItems.Add('4', new ConsoleMenuItem("Simulate moving game client ...", () => { new SimulateMovementMenu(_client).Show(); }));
            MenuItems.Add('5', new ConsoleMenuItem("USQL Script ...", () => new USQLJobMenu().Show()));
            MenuItems.Add('6', new ConsoleMenuItem("Results API Consumer ...", () => { new ResultsApiConsumerMenu().Show(); }));
            MenuItems.Add('7', new ConsoleMenuItem("Scheduler ...", () => { new SchedulerJobMenu().Show(); }));
        }

        private void SendScoreEvent()
        {
            var gamerTagFile1 = ConsoleEx.ReadLine("GamerTags File 1", "DataFiles/GamerTags1.txt", s => File.Exists(s));
            var gamerTagFile2 = ConsoleEx.ReadLine("GamerTags File 2", "DataFiles/GamerTags2.txt", s => File.Exists(s));
            var gamerTagFile3 = ConsoleEx.ReadLine("GamerTags File 3", "DataFiles/GamerTags3.txt", s => File.Exists(s));
            var gamerTagProvider = new GamerTagProvider(gamerTagFile1, gamerTagFile2, gamerTagFile3);

            Console.WriteLine("Sending score events...");

            for (int i = 0; i < 100; i++)
            {
                ScoreMessage message = new ScoreMessage
                {
                    type = "score",
                    version = "1.0.0",
                    gameId = $"{i % 2}",
                    userId = gamerTagProvider.GetGamerTag(),
                    score = s_randonScore.Next(0, 1000)
                };
                // Serialize object to JSON
                var json = JsonConvert.SerializeObject(message);
                _client.SendMessageAsync(json).Wait();
            }
        }

        private void SendCustomGameEvent()
        {
            var msg = (string)EditProperty("Custom Message", $"This is a custom msg at {DateTime.UtcNow}", typeof(string));

            _client.SendMessageAsync(msg).Wait();
        }
    }

    internal class ScoreMessage
    {
        public string type { get; set; }
        public string version { get; set; }
        public string gameId { get; set; }
        public string userId { get; set; }
        public int score { get; set; }
    }
}