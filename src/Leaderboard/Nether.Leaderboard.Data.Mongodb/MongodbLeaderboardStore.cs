using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using System;

namespace Nether.Leaderboard.Data.Mongodb
{
    public class MongodbLeaderboardStore : ILeaderboardStore
    {
        private readonly IMongoDatabase _database;

        private IMongoCollection<MongoDbGameScore> ScoresCollection
            => _database.GetCollection<MongoDbGameScore>("scores");

        public MongodbLeaderboardStore(string connectionString, string dbName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(dbName);
        }

        public async Task SaveScoreAsync(GameScore gameScore)
        {
            await ScoresCollection.InsertOneAsync(gameScore);
        }

        public async Task<List<GameScore>> GetAllHighScoresAsync()
        {           
            var collection = _database.GetCollection<BsonDocument>("scores");
            var all = collection.Find(new BsonDocument()).ToList();
            
            var query = from l in all
                        group l by l.GetValue("Gamertag") into lbgt           
                        let topscore = lbgt.Max(x => x.GetValue("Score"))
                        select new GameScore
                        {
                            Gamertag = lbgt.Key.AsString,
                            Score = topscore.AsInt32
                        };

            return query.ToList();
            
        }
    }
}
