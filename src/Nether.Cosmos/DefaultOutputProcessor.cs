// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Nether.Ingest;

namespace Nether.Cosmos
{
    /// <summary>
    /// This defauult output processor writes the messages to cosmos db directly with no processing. 
    /// A new document is created for the message
    /// </summary>
    public class DefaultOutputProcessor : IOutputProcessor
    {
        private string _collectionName;
        private string _databaseName;
        private DocumentClient _client;

        public async Task ProcessMessage(Message msg)
        {
            await _client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(_databaseName, _collectionName), msg);
        }

        public void Set(string databaseName, string collectionName, DocumentClient client)
        {
            _databaseName = databaseName;
            _collectionName = collectionName;
            _client = client;
        }
    }
}
