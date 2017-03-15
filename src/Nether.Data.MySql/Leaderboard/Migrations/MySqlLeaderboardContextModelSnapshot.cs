using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Nether.Data.MySql.Leaderboard;

namespace Nether.Data.MySql.Leaderboard.Migrations
{
    [DbContext(typeof(MySqlLeaderboardContext))]
    partial class MySqlLeaderboardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Nether.Data.EntityFramework.Leaderboard.SavedGamerScore", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomTag")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DateAchieved");

                    b.Property<string>("Gamertag")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Score");

                    b.HasKey("Id");

                    b.HasIndex("DateAchieved", "Gamertag", "Score");

                    b.ToTable("Scores");

                    b.HasAnnotation("MySql:TableName", "Scores");
                });

            modelBuilder.Entity("Nether.Data.MySql.Leaderboard.QueriedGamerScore", b =>
                {
                    b.Property<string>("Gamertag")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomTag");

                    b.Property<long>("Ranking");

                    b.Property<int>("Score");

                    b.HasKey("Gamertag");

                    b.ToTable("Ranks");
                });
        }
    }
}
