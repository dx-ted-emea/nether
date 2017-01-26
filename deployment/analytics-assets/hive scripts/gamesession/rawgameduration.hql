DROP TABLE IF EXISTS rawgamedurations;


CREATE TABLE IF NOT EXISTS rawgamedurations(
    startTime TIMESTAMP,
    stopTime TIMESTAMP,
    timeSpanSeconds BIGINT,
    gameSessionId STRING,
    gamerTag STRING
)
COMMENT 'raw game session durations'
PARTITIONED BY (year INT, month INT, day INT)
ROW FORMAT DELIMITED
    FIELDS TERMINATED BY '|'
    COLLECTION ITEMS TERMINATED BY '\073'
    LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://intermediate@netstuff.blob.core.windows.net/rawgamedurations/';


INSERT INTO TABLE rawgamedurations
PARTITION (year, month, day)
SELECT
    gamestart.clientUtc as startTime,
    gamestop.clientUtc as stopTime,
    unix_timestamp(gamestop.clientUtc) - unix_timestamp(gamestart.clientUtc) AS timeSpanSeconds,
    gamestart.gameSessionId AS gameSessionId,
    gamestart.gamerTag AS gamerTag,
    year(gamestart.clientUtc) as year,
    month(gamestart.clientUtc) as month,
    day(gamestart.clientUtc) as day
FROM
    gamestart LEFT JOIN gamestop
ON
    gamestart.eventcorrelationid = gamestop.eventcorrelationid;