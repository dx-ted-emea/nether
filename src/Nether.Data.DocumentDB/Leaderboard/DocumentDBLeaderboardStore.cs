using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Nether.Common;
using Nether.Data.Leaderboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nether.Data.DocumentDB.Leaderboard
{
    public class DocumentDBLeaderboardStore : ILeaderboardStore
    {
        // TODO - revisit the configurable DI to allow dependencies to be injected, e.g. ILoggerFactory, DocumentClient
        //          In the case of DocumentClient, the guidance is a single instance: https://azure.microsoft.com/en-us/documentation/articles/documentdb-performance-tips/#sdk-usage
        private readonly DocumentClient _client;
        private readonly string _collectionName;
        private readonly string _databaseName;

        private DocumentCollection _collection = null;
        private object _collectionLock = new object();

        public DocumentDBLeaderboardStore(string endpoint, string key, string databaseName, string collectionName)
        {
            ArgumentValidation.EnsureNotNull(endpoint, nameof(endpoint));
            ArgumentValidation.EnsureNotNull(key, nameof(key));
            ArgumentValidation.EnsureNotNull(databaseName, nameof(databaseName));
            ArgumentValidation.EnsureNotNull(collectionName, nameof(collectionName));

            _client = new DocumentClient(new Uri(endpoint), key);
            _databaseName = databaseName;
            _collectionName = collectionName;
        }
        public Task<List<GameScore>> GetAllHighScoresAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SaveScoreAsync(GameScore score)
        {
            // TODO - error handling/logging
            var collection = GetDatabaseCollection();

            var dbScore = score.ToDb();

            await _client.CreateDocumentAsync(collection.SelfLink, dbScore);
        }

        private DocumentCollection GetDatabaseCollection()
        {
            if (_collection == null)
            {
                lock (_collectionLock)
                {
                    if (_collection == null)
                    {
                        // TODO - error handling/logging
                        var database = _client.CreateDatabaseQuery()
                                            .Where(db => db.Id == _databaseName)
                                            .ToList() // doesn't like First(db=>db....) :-(
                                            .First();
                        _collection = _client.CreateDocumentCollectionQuery(database.SelfLink)
                                            .Where(collection => collection.Id == _collectionName)
                                            .ToList() // doesn't like First(collection=>collection....) :-(
                                            .First();
                    }
                }
            }
            return _collection;

        }
    }
}
