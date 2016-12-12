// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nether.Data.Leaderboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nether.Web.Features.Leaderboard.Configuration
{    

    public class LeaderboardConfig : ILeaderboardConfig
    {
        private Dictionary<LeaderboardType, LeaderboardConfigItem> _leaderboards;

        public LeaderboardConfig()
        {
        }

        public LeaderboardConfig(Dictionary<LeaderboardType, LeaderboardConfigItem> leaderboards)
        {
            _leaderboards = leaderboards;
        }        

        public LeaderboardConfigItem getConfigByType(LeaderboardType type)
        {
            LeaderboardConfigItem config;
            _leaderboards.TryGetValue(type, out config);
            return config;
        }
    }        
}
