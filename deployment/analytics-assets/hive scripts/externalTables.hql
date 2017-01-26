DROP TABLE IF EXISTS starts;
DROP TABLE IF EXISTS stops;
DROP TABLE IF EXISTS counts;
DROP TABLE IF EXISTS gamestart;
DROP TABLE IF EXISTS gamestop;
DROP TABLE IF EXISTS gameheartbeat;


CREATE EXTERNAL TABLE IF NOT EXISTS starts(event string COMMENT 'event type',
       version string,
       clientutc timestamp,
       eventCorrelationId string,
       displayName string,
       gameSessionId string,
       tags ARRAY<STRING>)
COMMENT 'generic start events'
ROW FORMAT DELIMITED
        FIELDS TERMINATED BY '|'
        COLLECTION ITEMS TERMINATED BY '\073'
        LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://gameevents@netstuff.blob.core.windows.net/gameevents/startevents/';


CREATE EXTERNAL TABLE IF NOT EXISTS stops(event string COMMENT 'event type',
       version string,
       clientutc timestamp,
       eventCorrelationId string,
       gameSessionId string,
       tags ARRAY<STRING>)
COMMENT 'generic start events'
ROW FORMAT DELIMITED
        FIELDS TERMINATED BY '|'
        COLLECTION ITEMS TERMINATED BY '\073'
        LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://gameevents@netstuff.blob.core.windows.net/gameevents/stopevents/';


CREATE EXTERNAL TABLE IF NOT EXISTS counts(event string COMMENT 'event type',
       version string,
       clientutc timestamp,
       displayName string,
       value BIGINT,
       gameSessionId string,
       tags ARRAY<STRING>)
COMMENT 'generic count events'
ROW FORMAT DELIMITED
        FIELDS TERMINATED BY '|'
        COLLECTION ITEMS TERMINATED BY '\073'
        LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://gameevents@netstuff.blob.core.windows.net/gameevents/countevents/';


CREATE EXTERNAL TABLE IF NOT EXISTS storecounts(event string COMMENT 'event type',
       version string,
       clientutc timestamp,
       itemBought string,
       amount BIGINT,
       gameSessionId string,
       tags ARRAY<STRING>)
COMMENT 'generic store count events'
ROW FORMAT DELIMITED
        FIELDS TERMINATED BY '|'
        COLLECTION ITEMS TERMINATED BY '\073'
        LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://gameevents@netstuff.blob.core.windows.net/gameevents/storecountevents/';


CREATE EXTERNAL TABLE IF NOT EXISTS gamestart(
    event STRING,
    version STRING,
    clientUtc TIMESTAMP,
    gameSessionId STRING,
    gamerTag STRING
)
COMMENT 'Game session start events'
ROW FORMAT DELIMITED
    FIELDS TERMINATED BY '|'
    COLLECTION ITEMS TERMINATED BY '\073'
    LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://rawdata@netstuff.blob.core.windows.net/gamestartevents/';


CREATE EXTERNAL TABLE IF NOT EXISTS gamestop(
    event STRING,
    version STRING,
    clientUtc TIMESTAMP,
    gameSessionId STRING
)
COMMENT 'Game session stop events'
ROW FORMAT DELIMITED
    FIELDS TERMINATED BY '|'
    COLLECTION ITEMS TERMINATED BY '\073'
    LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://rawdata@netstuff.blob.core.windows.net/gamestopevents/';


CREATE EXTERNAL TABLE IF NOT EXISTS gameheartbeat(
    event STRING,
    version STRING,
    clientUtc TIMESTAMP,
    gameSessionId STRING
)
COMMENT 'Game session heartbeat events'
ROW FORMAT DELIMITED
    FIELDS TERMINATED BY '|'
    COLLECTION ITEMS TERMINATED BY '\073'
    LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://rawdata@netstuff.blob.core.windows.net/gameheartbeatevents/';
