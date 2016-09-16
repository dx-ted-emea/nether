using Nether.Data.Leaderboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nether.Data.DocumentDB.Leaderboard
{
    public static class DocumentDbModelExtensions
    {
        public static DocumentDbGameScore ToDb(this GameScore score)
        {
            return new DocumentDbGameScore
            {
                GamerTag = score.Gamertag,
                Score = score.Score
            };
        }
    }
}
