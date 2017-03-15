using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nether.Data.MySql.Leaderboard.Migrations
{
    public partial class InitialLeaderboardContextMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    CustomTag = table.Column<string>(maxLength: 50, nullable: true),
                    DateAchieved = table.Column<DateTime>(nullable: false),
                    Gamertag = table.Column<string>(maxLength: 50, nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Gamertag = table.Column<string>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    CustomTag = table.Column<string>(nullable: true),
                    Ranking = table.Column<long>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Gamertag);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scores_DateAchieved_Gamertag_Score",
                table: "Scores",
                columns: new[] { "DateAchieved", "Gamertag", "Score" });

            migrationBuilder.Sql(@"
CREATE PROCEDURE GetPlayerRank
	(
		IN gamertag_input VARCHAR(50),
		OUT Rank INT
    )
BEGIN
SELECT -1 INTO Rank;

SELECT
	Ranking INTO Rank
FROM (
	SELECT
		gt,
		Score,
		CustomTag,
		Ranking
	FROM
		(
			SELECT
				gt,
				Score,
				CustomTag,
				CAST(IF(Score=@lastScore,@currentRank:=@currentRank,@currentRank:=@rowNumber) AS SIGNED) AS Ranking,
                @rowNumber:=@rowNumber+1,
                @lastScore:=Score
			FROM
				(
					SELECT
						Gamertag as gt,
						MAX(Score) AS Score,
						MAX(CustomTag) AS CustomTag
					FROM Scores
					GROUP BY gt
					ORDER BY Score DESC
				) bestScores
                , (SELECT @currentRank := 1, @rowNumber:=1, @lastScore:=0) r
		) rankedScores
	WHERE gt = gamertag_input
) AS T
;
END
            ");

            migrationBuilder.Sql(@"
CREATE PROCEDURE GetHighScores
	(
		IN startRank INT,
        IN count INT
    )
BEGIN
SELECT
	Score,
	Gamertag,
	CustomTag,
	Ranking
FROM
	(SELECT
		Score,
		Gamertag,
		CustomTag,
		  CAST(IF(Score=@lastScore,@currentRank:=@currentRank,@currentRank:=@rowNumber) AS SIGNED) AS Ranking,
		  @rowNumber:=@rowNumber+1,@lastScore:=Score
		FROM (
			SELECT
				Gamertag,
				MAX(Score) AS Score,
				MAX(CustomTag) AS CustomTag
			FROM Scores
			GROUP BY GamerTag
            ORDER BY Score DESC
		) AS T
	   , (SELECT @currentRank := 1, @rowNumber:=1, @lastScore:=0) r

	) AS T2
WHERE Ranking BETWEEN startRank AND (startRank + count) 
ORDER BY Ranking, Gamertag
;
END
            ");

            migrationBuilder.Sql(@"
CREATE PROCEDURE GetScoresAroundPlayer
	(
		IN gamertag_input varchar(50),
        IN radius INT
    )
BEGIN

CALL GetPlayerRank (gamertag_input, @playerRank);

IF(@PlayerRank >= 0) THEN
    SELECT
        Gamertag,
        Score,
        CustomTag,
        Ranking
    FROM(
			SELECT
				Gamertag,
				Score,
				CustomTag,
				CAST(IF(Score=@lastScore,@currentRank:=@currentRank,@currentRank:=@rowNumber) AS SIGNED) AS Ranking,
                @rowNumber:=@rowNumber+1,
                @lastScore:=Score
			FROM
				(
					SELECT
						Gamertag,
						MAX(Score) AS Score,
						MAX(CustomTag) AS CustomTag
					FROM Scores
					GROUP BY Gamertag
					ORDER BY Score DESC
				) bestScores
                , (SELECT @currentRank := 1, @rowNumber:=1, @lastScore:=0) r
		) rankedScores
    WHERE Ranking BETWEEN(@PlayerRank - radius) AND(@PlayerRank + radius)
    ORDER BY Ranking, Gamertag;
ELSE
    SELECT
        NULL AS Gamertag,
        NULL AS Score,
        NULL AS CustomTag,
        NULL AS Ranking;
END IF;
	
END 
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE[dbo].[GetScoresAroundPlayer]");
            migrationBuilder.Sql("DROP PROCEDURE[dbo].[GetHighScores]");
            migrationBuilder.Sql("DROP PROCEDURE[dbo].[GetPlayerRank]");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Ranks");
        }
    }
}
