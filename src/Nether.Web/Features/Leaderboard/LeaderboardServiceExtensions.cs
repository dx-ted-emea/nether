// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Nether.Common.DependencyInjection;
using Nether.Data.Leaderboard;
using Nether.Data.MongoDB.Leaderboard;
using Nether.Data.Sql.Leaderboard;
using Nether.Integration.Analytics;
using Nether.Integration.Default.Analytics;
using Nether.Web.Features.Leaderboard.Configuration;
using System.Collections.Generic;

namespace Nether.Web.Features.Leaderboard
{
    public static class LeaderboardServiceExtensions
    {
        public static IServiceCollection AddLeaderboardServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddLeaderboardStore(services, configuration);

            AddAnalyticsIntegrationClient(services, configuration);

            return services;
        }

        private static void AddAnalyticsIntegrationClient(IServiceCollection services, IConfiguration configuration)
        {
            // TODO - look at what can be extracted to generalise this
            if (configuration.Exists("Leaderboard:AnalyticsIntegrationClient:wellKnown"))
            {
                // register using well-known type
                var wellKnownType = configuration["Leaderboard:AnalyticsIntegrationClient:wellknown"];
                switch (wellKnownType)
                {
                    case "null":
                        services.AddSingleton<IAnalyticsIntegrationClient, AnalyticsIntegrationNullClient>();
                        break;
                    case "default":
                        var scopedConfiguration = configuration.GetSection("Leaderboard:AnalyticsIntegrationClient:properties");
                        string baseUrl = scopedConfiguration["AnalyticsBaseUrl"];

                        services.AddTransient<IAnalyticsIntegrationClient>(serviceProvider =>
                        {
                            return new AnalyticsIntegrationClient(baseUrl);
                        });
                        break;
                    default:
                        throw new Exception($"Unhandled 'wellKnown' type for AnalyticsIntegrationClient: '{wellKnownType}'");
                }
            }
            else
            {
                // fall back to generic "factory"/"implementation" configuration
                services.AddServiceFromConfiguration<IAnalyticsIntegrationClient>(configuration, "Leaderboard:AnalyticsIntegrationClient");
            }
        }

        private static void AddLeaderboardStore(IServiceCollection services, IConfiguration configuration)
        {
            // TODO - look at what can be extracted to generalise this
            if (configuration.Exists("Leaderboard:Store:wellKnown"))
            {
                // register using well-known type
                var wellKnownType = configuration["Leaderboard:Store:wellknown"];
                var scopedConfiguration = configuration.GetSection("Leaderboard:Store:properties");
                Dictionary<LeaderboardType, LeaderboardConfigItem> leaderboards = GetLeaderboardsConfig(configuration);
                string connectionString;
                switch (wellKnownType)
                {
                    case "mongo":
                        connectionString = scopedConfiguration["ConnectionString"];
                        string databaseName = scopedConfiguration["DatabaseName"];

                        services.AddTransient<ILeaderboardStore>(serviceProvider =>
                        {
                            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                            // TODO - look at encapsulating the connection info and registering that so that we can just register the type without the factory
                            return new MongoDBLeaderboardStore(connectionString, databaseName, loggerFactory);
                        });
                        break;
                    case "sql":
                        connectionString = scopedConfiguration["ConnectionString"];
                        services.AddTransient<ILeaderboardStore>(serviceProvider =>
                        {
                            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                            return new SqlLeaderboardStore(connectionString, loggerFactory);
                        });
                        services.AddTransient<ILeaderboardConfig>(serviceProvider =>
                        {
                            return new LeaderboardConfig(leaderboards);
                        });
                        break;
                    default:
                        throw new Exception($"Unhandled 'wellKnown' type for Leaderboard:Store: '{wellKnownType}'");
                }
            }
            else
            {
                // fall back to generic "factory"/"implementation" configuration
                services.AddServiceFromConfiguration<ILeaderboardStore>(configuration, "Leaderboard:Store");
            }
        }

        private static Dictionary<LeaderboardType, LeaderboardConfigItem> GetLeaderboardsConfig(IConfiguration configuration)
        {
            Dictionary<LeaderboardType, LeaderboardConfigItem> config = new Dictionary<LeaderboardType, LeaderboardConfigItem>();

            if (configuration.Exists("Leaderboard:Leaderboards:Default:Enabled") &&
                Boolean.Parse(configuration["Leaderboard:Leaderboards:Default:Enabled"]))
            {
                config.Add(LeaderboardType.Default, new LeaderboardConfigItem
                {
                    AroundMe = false,
                    Radius = 0,
                    Top = 0
                });
            }
            if (configuration.Exists("Leaderboard:Leaderboards:Top:Enabled") &&
                Boolean.Parse(configuration["Leaderboard:Leaderboards:Top:Enabled"]))
            {
                var configurationSection = configuration.GetSection("Leaderboard:Leaderboards:Top");
                config.Add(LeaderboardType.Top, new LeaderboardConfigItem
                {
                    AroundMe = false,
                    Radius = 0,
                    Top = Int32.Parse(configurationSection["Top"])
                });
            }
            if (configuration.Exists("Leaderboard:Leaderboards:AroundMe:Enabled") &&
                Boolean.Parse(configuration["Leaderboard:Leaderboards:AroundMe:Enabled"]))
            {
                var configurationSection = configuration.GetSection("Leaderboard:Leaderboards:AroundMe");
                config.Add(LeaderboardType.AroundMe, new LeaderboardConfigItem
                {
                    AroundMe = true,
                    Radius = Int32.Parse(configurationSection["Radius"]),
                    Top = 0
                });
            }

            return config;
        }
    }
}