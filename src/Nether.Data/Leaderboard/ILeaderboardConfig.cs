using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nether.Data.Leaderboard
{
    public interface ILeaderboardConfig
    {
        LeaderboardConfigItem getConfigByType(LeaderboardType type);
    }
        
    /// <summary>
    /// Type of the leaderboard
    /// </summary>
    public enum LeaderboardType
    {
        /// <summary>
        /// Default leaderboard
        /// </summary>
        Default,
        Top,
        AroundMe
    }

    public class LeaderboardConfigItem
    {
        public bool AroundMe { get; set; }
        public int Radius { get; set; }
        public int Top { get; set; }
    }
}
