// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nether.Data.EntityFramework.PlayerManagement;
using System.Reflection;

namespace Nether.Data.MySql.PlayerManagement
{
    public class MySqlPlayerManagementContext : PlayerManagementContextBase
    {
        private readonly MySqlPlayerManagementContextOptions _options;

        public MySqlPlayerManagementContext(ILoggerFactory loggerFactory, MySqlPlayerManagementContextOptions options)
            : base(loggerFactory)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PlayerGroupEntity>().ForMySqlToTable("PlayerGroups");
            builder.Entity<PlayerEntity>().ForMySqlToTable("Players");
            builder.Entity<GroupEntity>().ForMySqlToTable("Groups");
            builder.Entity<PlayerExtendedEntity>().ForMySqlToTable("PlayersExtended");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            builder.UseMySql(_options.ConnectionString, options =>
            {
                options.MigrationsAssembly(GetType().GetTypeInfo().Assembly.GetName().Name);
            });
        }
    }

    public class MySqlPlayerManagementContextOptions
    {
        public string ConnectionString { get; set; }
    }
}