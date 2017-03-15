// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Nether.Data.EntityFramework.Common;

namespace Nether.Data.MySql.Leaderboard
{
    /// <summary>
    /// Class added to enable creating EF Migrations
    /// See https://docs.microsoft.com/en-us/ef/core/api/microsoft.entityframeworkcore.infrastructure.idbcontextfactory-1
    /// </summary>
    public class MySqlLeaderboardContextFactory : IDbContextFactory<MySqlLeaderboardContext>
    {
        public MySqlLeaderboardContext Create(DbContextFactoryOptions options)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddConsole();
            var logger = loggerFactory.CreateLogger<MySqlLeaderboardContextFactory>();


            var configuration = ConfigurationHelper.GetConfiguration(logger, options.ContentRootPath, options.EnvironmentName);

            var connectionString = configuration["Leaderboard:Store:properties:ConnectionString"];
            logger.LogInformation("Using connection string: {0}", connectionString);

            return new MySqlLeaderboardContext(
                loggerFactory,
                new MySqlLeaderboardContextOptions
                {
                    ConnectionString = connectionString
                });
        }
    }
}
