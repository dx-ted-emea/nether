using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
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
        public async Task<List<GameScore>> GetAllHighScoresAsync()
        {
            var collection = GetDatabaseCollection();

            var query = _client.CreateDocumentQuery<DocumentDbGamerHighScore>(collection.SelfLink)
                .OrderByDescending(hs => hs.HighScore)
                .AsDocumentQuery();

            var response = await query.ExecuteNextAsync<DocumentDbGamerHighScore>();

            // TODO handle navigating paged responses from DocDb
            // TODO handle paging controlled by caller (Take/Skip/...)
            return response
                        .Select(hs => new GameScore { Gamertag = hs.GamerTag, Score = hs.HighScore })
                        .ToList();
        }

        public async Task SaveScoreAsync(GameScore score)
        {
            // TODO - error handling/logging
            var collection = GetDatabaseCollection();

            // Currently not storing the individual scores as there's currently nothing driving that

            // Could look at wrapping the check and update logic in a user-defined function to make it a single call

            var result = await _client.CreateDocumentQuery<DocumentDbGamerHighScore>(collection.SelfLink)
                .Where(hs => hs.GamerTag == score.Gamertag)
                .Take(1) 
                .AsDocumentQuery()
                .ExecuteNextAsync<DocumentDbGamerHighScore>();
            var gamerHighScore = result.FirstOrDefault(); // TODO Create a DocDbFirstAsync helper!!

            if (gamerHighScore == null)
            {
                // doesn't exist
                gamerHighScore = new DocumentDbGamerHighScore
                {
                    GamerTag = score.Gamertag,
                    HighScore = score.Score
                };
                await _client.CreateDocumentAsync(collection.SelfLink, gamerHighScore);
            }
            else
            {
                if (gamerHighScore.HighScore < score.Score)
                {
                    // update
                    gamerHighScore.HighScore = score.Score;
                    await _client.ReplaceDocumentAsync(gamerHighScore.SelfLink, gamerHighScore);
                }
            }
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
