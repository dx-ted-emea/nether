using Microsoft.Azure.Documents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nether.Data.DocumentDB.Leaderboard
{
    public class DocumentDbGamerHighScore : Resource
    {
        private string _gamertag;
        [JsonProperty("gamertag")]
        public string GamerTag
        {
            get { return _gamertag; }
            set
            {
                _gamertag = value;
                Id = "highscore:" + value;
            }
        }

        [JsonProperty("highScore")]
        public int HighScore { get; set; }

        [JsonProperty("type")]
        public string Type { get { return "gamerHighScore"; } }
    }
}
