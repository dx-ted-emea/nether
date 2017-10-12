# Get Leaderboard

Get a sorted list of scores and gamertags for a defined leaderboard.

## Request

See Common parameters and headers that are used by all requests related to the Leaderboard Building Block

Method  | Request URI
------- | -----------
GET     | `/api/leaderboard/{leaderboardname}/{startposition}/{maxresults}/{timeframe}/{location}`

### Request Parameters

Name        | Required |   Type   | Description
------------|----------|----------|------------
leaderboardname|yes|string|Name of the leaderboard
startposition|yes|int|Where to start the leaderboard (rank)
maxresults|yes|int|Maximium number of scores to result
timeframe|yes|enumeration|The timeframe to return, this can be 'day', 'week', 'month' or 'year'
location|no|string|Country code, if empty the country is not taking in consideration

### Request Body

Empty body

## Response

| Status Code | Description |
|-------------|-------------|
|200|Success|
|403|You dont' have permissions to sumbit the score|

### Response Body

#### Example

```json
{
    "entries": [
        {
        "gamertag": "krist00fer",
        "score": 900    
    },
    {
        "gamertag": "anko",
        "score": 500    
    },
    {
        "gamertag": "vito",
        "score": 100    
    }]
}
```

Element name        | Required  | Type       | Description
------------------- | --------- | ---------- | -----------
entries         | Yes       | json array | A list of gamertags and their highest score
