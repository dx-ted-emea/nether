// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nether.Analytics;
using System;

namespace AnalyticsTestClient
{
    internal class ResultsApiConsumerMenu : ConsoleMenu
    {
        public ResultsApiConsumerMenu()
        {
            Title = "Nether Analytics Test Client - Results API Consumer";

            MenuItems.Add('1', new ConsoleMenuItem("Get Latest Results (FS)", () => new ResultsFileSystemMenu().Show()));
            //MenuItems.Add('2', new ConsoleMenuItem("Time Span Results (FS)", () => new ResultsTimeSpanMenu().Show()));
        }

        private class ResultsTimeSpanMenu : ConsoleMenu
        {
            public ResultsTimeSpanMenu()
            {
                Title = "Latest Results (FS)";

                // TODO: WIP
                //MenuItems.Add('1', new ConsoleMenuItem("DAU", () => GetResults(dauSerializer, "dau", "session-start")));
                //MenuItems.Add('2', new ConsoleMenuItem("Clustering", () => GetResults(clusteringSerializer, "clustering", "geo-location")));
            }

            private void GetResults(IMessageFormatter formatter, string pipeline, string messageType)
            {
               
            }

            private DateTime? GetDate(string type)
            {
                Console.Write($"{type}:");
                var d = Console.ReadLine();

                DateTime date;
                if (!DateTime.TryParse(d, out date))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Date was incorrectly formatted.");
                    Console.ResetColor();
                    return null;
                }

                return date;
            }
        }


        private class ResultsFileSystemMenu : ConsoleMenu
        {
            public ResultsFileSystemMenu()
            {
                Title = "Latest Results (FS)";
                
                MenuItems.Add('1', new ConsoleMenuItem("DAU", () => GetLatestFromFileSystem("dau")));
                MenuItems.Add('2', new ConsoleMenuItem("Clustering", () => GetLatestFromFileSystem("cluster")));
            }

            public void GetLatestFromFileSystem(string pipeline)
            {
                Console.Write("Root directory: ");

                var path = Console.ReadLine();

                var fileStoreStore = new Nether.Analytics.Results.FileResultsStore(path);
                Console.WriteLine(fileStoreStore.For(pipeline).Latest().AsText());
            }
        }
    }
}
