// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.EntityFrameworkCore;

namespace Nether.SqlDatabase
{
    internal class SqlMessageContext<T> : DbContext where T : SqlMessageBase
    {
        private readonly string _connectionString;
        private readonly string _tableName;

        public DbSet<T> Messages { get; set; }

        public SqlMessageContext(string connectionString, string tableName)
        {
            _connectionString = connectionString;
            _tableName = tableName;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<T>().HasKey(c => c.Id);
            builder.Entity<T>().Property(m => m.Id).HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.GuidValueGenerator>();
            builder.Entity<T>().ForSqlServerToTable(_tableName);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseSqlServer(_connectionString);
        }
    }
}