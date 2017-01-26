SELECT
    Event,
    Version,
    ClientUtc,
    GameSessionId,
    GamerTag
INTO
    startOutput
FROM
    Input
WHERE
    Event = 'game-start'


SELECT
    Event,
    Version,
    ClientUtc,
    GameSessionId
INTO
    stopOutput
FROM
    Input
WHERE
    Event = 'game-stop'


SELECT
    Event,
    Version,
    ClientUtc,
    GameSessionId
INTO
    heartbeatOutput
FROM
    Input
WHERE
    Event = 'game-heartbeat'