# Post a new score to a Leaderboard

Called after the game session has finished and user achieved a new score in the game. Or at any time called during the game. The score can be posted against different leaderboards per game.

## Request

See Common parameters and headers that are used by all requests related to the Leaderboard Building Block

Method  | Request URI |
--------|-------------|
POST    | `/api/updateplayerscore` |

### Request parameters

No parameters

### Request body

```json
{
	"LeaderboardName": "top",
	"score": 4711,    
  	"location" : "NL"
}
```

|  Name  | Required  | Type  | Description |
|--------|-----------|-------|-------------|
|LeaderBoardName|yes|string|Name of the leaderboard the score is posted against. Id the leaderboard doesn't exists it will be created|
|score|yes|number|Achieved score, must be non-negative|
|location|no|string|Country code (US, UK, etc.) 

### Response

| Status Code | Description |
|-------------|-------------|
|200|Operation completed successfully|
|400|Score is negative or user has no assigned `gamerTag`|
|403|You dont' have permissions to sumbit the score|

### JSON Body

Empty body
