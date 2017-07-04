// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;

namespace Nether.Analytics.SqlDatabase
{
    /// <summary>
    /// This is a base abstract class for SQL messages.
    /// Each message will have at least an Id and message ID. implemetion classes will add additional properties
    /// </summary>s   
    public abstract class SqlMessageBase
    {
        public Guid Id { get; set; }
        public string MessageId { get; set; }

        // set the object properties values from the message properties
        public abstract void SetProperties(Dictionary<string, string> properties);

        // return a query to create a sql table for the message if the table *does not exist*
        public abstract string GetCreateTableQuery(string tableName);
    }
}