// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Nether.Data.Leaderboard;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Nether.Web.Features.Leaderboard.Models.Leaderboard
{
    public class LeaderboardGetResponseModel
    {
        public List<LeaderboardEntry> Entries { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue((object)null)]
        public LeaderboardEntry CurrentPlayer { get; set; }

        public class LeaderboardEntry
        {
            /// <summary>
            /// Gamertag
            /// </summary>
            public string Gamertag { get; set; }

            /// <summary>
            /// Scores
            /// </summary>
            public int Score { get; set; }

            /// <summary>
            /// Player rank
            /// </summary>
            public long Rank { get; set; }
            /// <summary>
            /// True if the score is for the current player
            /// </summary>
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            [DefaultValue(false)]
            public bool IsCurrentPlayer { get; set; }
        }
    }
}