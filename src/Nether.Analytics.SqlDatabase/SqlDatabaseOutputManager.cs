// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Nether.Analytics.SqlDatabase
{
    public class SqlDatabaseOutputManager<T> : IOutputManager where T : SqlMessageBase
    {
        private static SqlMessageContext<T> s_context;
        private string _connectionString;
        private string _tableName;

        private SqlMessageContext<T> Context
        {
            get
            {
                if (s_context == null)
                {
                    s_context = new SqlMessageContext<T>(_connectionString, _tableName);
                    s_context.Database.EnsureCreated();

                    try
                    {
                        // create table if does not exist
                        T obj = (T)Activator.CreateInstance(typeof(T));
                        s_context.Database.ExecuteSqlCommand(obj.GetCreateTableQuery(_tableName));
                    }
                    catch (SqlException e)
                    {
                        // failed becasue the table already exist - continue
                    }
                }
                return s_context;
            }
        }

        public SqlDatabaseOutputManager(string connectionString, string tableName)
        {
            _connectionString = connectionString;
            _tableName = tableName;
        }

        private T CreateMessageObject(Message msg)
        {
            T obj = (T)Activator.CreateInstance(typeof(T));
            obj.SetProperties(msg.Properties);
            return obj;
        }

        public async Task OutputMessageAsync(string partitionId, string pipelineName, int index, Message msg)
        {
            T obj = CreateMessageObject(msg);
            await Context.Messages.AddAsync(obj);
            await Context.SaveChangesAsync();
        }

        public Task FlushAsync(string partitionId)
        {
            return Task.CompletedTask;
        }
    }
}

