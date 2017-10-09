// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Nether.Ingest;
using System.Linq;

namespace Nether.Cosmos
{
    /// <summary>
    /// Top Scores leaderboard - update top score per player
    /// </summary>
    public class TopScoresOutputProcessor : IOutputProcessor
    {
        private string _collectionName;
        private string _databaseName;
        private DocumentClient _client;

        public async Task ProcessMessage(Message msg)
        {
            ScoreDocument score = new ScoreDocument { UserId = msg.Properties["userId"], Score = Convert.ToInt32(msg.Properties["score"]) };

            // update the high score collection
            var highScoresCollectionLink = UriFactory.CreateDocumentCollectionUri(_databaseName, _collectionName);

            // query for the same user with lower score
            ScoreDocument queryScores = _client.CreateDocumentQuery<ScoreDocument>(highScoresCollectionLink)
                                            .Where(sd => (sd.UserId == score.UserId) && (sd.Score < score.Score))
                                            .AsEnumerable()
                                            .FirstOrDefault();

            if (queryScores == null)
            {
                // check if the user was already added to the db

                var query = _client.CreateDocumentQuery<ScoreDocument>(highScoresCollectionLink)
                    .Where(sd => sd.UserId == score.UserId).AsEnumerable()
                    .FirstOrDefault();

                if (query == null)
                {
                    await _client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(_databaseName, _collectionName), score);
                }
            }
            else
            {
                // update the saved score for user with the new top score                
                queryScores.Score = score.Score;
                await _client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(_databaseName, _collectionName, queryScores.Id), queryScores);
            }
        }

        public void Set(string databaseName, string collectionName, DocumentClient client)
        {
            _databaseName = databaseName;
            _collectionName = collectionName;
            _client = client;
        }
    }
}
