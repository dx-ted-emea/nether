# Nether Leaderboard

Leaderboard provides a simple way to manage players scores and keep track of who is best based on different criterias.

## Common Parameters and Headers

The following information is common to all tasks that you might do related to leaderboards:

* Replace `{api-version}` with 2016-09-01 in the URI.
* Set the Content-Type header to application/json.
* Set the Authorization header to a JSON Web Token that you obtained from ... TODO

## API Overview

Method  | Request URI                   | Description |
------- | ------------------------------|-------------|
GET|[`/api/leaderboard/{leaderboardname}/{startposition}/{maxresults}/{timeframe}/{location}`](leaderboard-get.md)|Query leaderboard of a specific name, timeframe and location|
POST|[`/api/scores`](updateplayerscore.md)|Post new score for the current user|
DELETE|[`/api/scores`](leaderboard-delete.md)|Delete all scores for the current user|
