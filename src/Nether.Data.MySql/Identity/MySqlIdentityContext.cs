// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

using Pomelo.EntityFrameworkCore.MySql;

namespace Nether.Data.Sql.Identity
{
    public class MySqlIdentityContext : IdentityContextBase
    {
        private readonly MySqlIdentityContextOptions _options;

        public MySqlIdentityContext(ILoggerFactory loggerFactory, MySqlIdentityContextOptions options)
            : base(loggerFactory)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserEntity>().ForMySqlToTable("Users");
            builder.Entity<LoginEntity>().ForMySqlToTable("UserLogins");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            builder.UseMySql(_options.ConnectionString, options =>
            {
                options.MigrationsAssembly(typeof(MySqlIdentityContext).GetTypeInfo().Assembly.GetName().Name);
            });
        }
    }

    public class MySqlIdentityContextOptions
    {
        public string ConnectionString { get; set; }
    }
}