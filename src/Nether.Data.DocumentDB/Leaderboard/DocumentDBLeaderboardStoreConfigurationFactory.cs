using Nether.Common.DependencyInjection;
using Nether.Data.Leaderboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Nether.Data.DocumentDB.Leaderboard
{
    public class DocumentDBLeaderboardStoreConfigurationFactory : IDependencyFactory<ILeaderboardStore>
    {
        public ILeaderboardStore CreateInstance(IConfiguration configuration)
        {
            // TODO - explore scoping the configuration to the "properties" section. This would change the code to:
            //                     string connectionString = configuration["ConnectionString"];
            string endpoint = configuration["LeaderboardStore:properties:Endpoint"];
            string key = configuration["LeaderboardStore:properties:Key"];
            string databaseName = configuration["LeaderboardStore:properties:DatabaseName"];
            string collectionName = configuration["LeaderboardStore:properties:CollectionName"];
            return new DocumentDBLeaderboardStore(endpoint, key, databaseName, collectionName);
        }
    }
}
