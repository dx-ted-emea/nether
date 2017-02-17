﻿/* Copyright (c) Microsoft. All rights reserved.
Licensed under the MIT license. See LICENSE file in the project root for full license information. */

CREATE PROCEDURE [dbo].[GetHighScores]
	@StartRank int = 0,
	@Count int
AS
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
		RANK() OVER(ORDER BY Score DESC) AS Ranking
		FROM (
			SELECT
				Gamertag,
				MAX(Score) AS Score,
				MAX(CustomTag) AS CustomTag
			FROM Scores
			GROUP BY GamerTag
		) AS T
	) AS T2
WHERE Ranking BETWEEN @StartRank AND (@StartRank + @Count)
ORDER BY Score DESC
RETURN 0
