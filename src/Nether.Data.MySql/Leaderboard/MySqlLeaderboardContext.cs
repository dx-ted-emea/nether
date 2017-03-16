// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nether.Data.EntityFramework.Leaderboard;
using Nether.Data.Leaderboard;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nether.Data.MySql.Leaderboard
{
    public class MySqlLeaderboardContext : LeaderboardContextBase
    {
        private readonly MySqlLeaderboardContextOptions _options;

        private static string s_topSql = "CALL GetHighScores (0,{0})";
        private static string s_aroundMeSql = "CALL GetScoresAroundPlayer ({0}, {1})";

        public DbSet<QueriedGamerScore> Ranks { get; set; }

        public MySqlLeaderboardContext(ILoggerFactory loggerFactory, MySqlLeaderboardContextOptions options)
            : base(loggerFactory)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<QueriedGamerScore>()
                .HasKey(c => c.Gamertag);

            builder.Entity<SavedGamerScore>()
                .ForMySqlToTable("Scores");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySql(_options.ConnectionString);
        }

        public override async Task<List<GameScore>> GetHighScoresAsync(int n)
        {
            if (n == 0)
            {
                // temporary - set n to large number. Will remove this once we implement paging
                n = 1000;
            }
            return await Ranks.FromSql(s_topSql, n)
                .Select(s =>
                new GameScore
                {
                    Score = s.Score,
                    Gamertag = s.Gamertag,
                    CustomTag = s.CustomTag,
                    Rank = s.Ranking
                }).ToListAsync();
        }

        public override async Task<List<GameScore>> GetScoresAroundMeAsync(string gamertag, int radius)
        {
            return await Ranks.FromSql(s_aroundMeSql, gamertag, radius)
                .Select(s =>
                new GameScore
                {
                    Score = s.Score,
                    Gamertag = s.Gamertag,
                    CustomTag = s.CustomTag,
                    Rank = s.Ranking
                }).ToListAsync();
        }
    }
    public class MySqlLeaderboardContextOptions
    {
        public string ConnectionString { get; set; }
    }
}

