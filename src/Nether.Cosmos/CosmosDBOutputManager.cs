// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Nether.Ingest;
using System;
using System.Threading.Tasks;

namespace Nether.Cosmos
{
    /// <summary>
    /// Output Manager for Azure Cosmos DB.
    /// 1. Creates a collection collectionName if does not exist
    /// 2. Writes a message into a new document in the collection (each message into a seperate document)
    /// </summary>
    public class CosmosDBOutputManager : IOutputManager
    {
        private string _databaseName;
        private string _collectionName;
        private DocumentClient _client;
        private IOutputProcessor _outputPrcoessor;

        public CosmosDBOutputManager(string cosmosDbUrl, string cosmosDbKey, string databaseName, string collectionName, IOutputProcessor outputProcessor)
        {
            _databaseName = databaseName;
            _collectionName = collectionName;

            _client = new DocumentClient(new Uri(cosmosDbUrl), cosmosDbKey);

            _outputPrcoessor = outputProcessor;
            _outputPrcoessor.Set(_databaseName, _collectionName, _client);

            init();
        }

        private void init()
        {
            // Create the database
            _client.CreateDatabaseIfNotExistsAsync(new Database() { Id = _databaseName }).GetAwaiter().GetResult();

            // Create the collections
            _client.CreateDocumentCollectionIfNotExistsAsync(
                UriFactory.CreateDatabaseUri(_databaseName),
                new DocumentCollection { Id = _collectionName }).
                GetAwaiter()
                .GetResult();
        }

        public Task FlushAsync(string partitionId)
        {
            return Task.CompletedTask;
        }

        public async Task OutputMessageAsync(string partitionId, string pipelineName, int index, Message msg)
        {
            await _outputPrcoessor.ProcessMessage(msg);
        }
    }
}
