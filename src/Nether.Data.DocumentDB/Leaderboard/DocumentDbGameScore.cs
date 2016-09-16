using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nether.Data.DocumentDB.Leaderboard
{
    public class DocumentDbGameScore
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("gamerTag")]
        public string GamerTag { get; set; }
        [JsonProperty("score")]
        public int Score { get; set; }
    }
}
