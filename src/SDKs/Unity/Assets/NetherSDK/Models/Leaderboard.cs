using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetherSDK.Models
{
    [Serializable]
    public class LeaderboardsResult
    {
        public Leaderboard[] leaderboards;
    }

    [Serializable]
    public class Leaderboard
    {
        public string name;
        public string _link;
    }


    [Serializable]
    public class LeaderboardNamed
    {
        public LeaderboardEntry[] entries;
        public LeaderboardEntry currentPlayer;
    }

    [Serializable]
    public class LeaderboardEntry
    {
        public string gamertag;
        public int score;
        public int rank;
        public bool isCurrentPlayer;
    }

}
