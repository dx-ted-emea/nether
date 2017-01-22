DROP TABLE IF EXISTS DEFAULT.starts;
DROP TABLE IF EXISTS DEFAULT.stops;
DROP TABLE IF EXISTS DEFAULT.counts;
DROP TABLE IF EXISTS DEFAULT.gamestarts;


CREATE EXTERNAL TABLE IF NOT EXISTS default.starts(event string COMMENT 'event type',
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


CREATE EXTERNAL TABLE IF NOT EXISTS default.stops(event string COMMENT 'event type',
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


CREATE EXTERNAL TABLE IF NOT EXISTS default.counts(event string COMMENT 'event type',
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


CREATE EXTERNAL TABLE IF NOT EXISTS default.storecounts(event string COMMENT 'event type',
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


CREATE EXTERNAL TABLE IF NOT EXISTS default.gamestarts(event string COMMENT 'event type',
       version string,
       clientutc timestamp,
       gameSessionId string,
       gamerTag string,
       tags ARRAY<STRING>)
COMMENT 'game start events'
ROW FORMAT DELIMITED
        FIELDS TERMINATED BY '|'
        COLLECTION ITEMS TERMINATED BY '\073'
        LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://gameevents@netstuff.blob.core.windows.net/gameevents/game-start/';


CREATE EXTERNAL TABLE IF NOT EXISTS default.gamestops(event string COMMENT 'event type',
       version string,
       clientutc timestamp,
       gameSessionId string,
       tags ARRAY<STRING>)
COMMENT 'game stop events'
ROW FORMAT DELIMITED
        FIELDS TERMINATED BY '|'
        COLLECTION ITEMS TERMINATED BY '\073'
        LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://gameevents@netstuff.blob.core.windows.net/gameevents/game-stop/';


CREATE EXTERNAL TABLE IF NOT EXISTS default.gameheartbeats(event string COMMENT 'event type',
       version string,
       clientutc timestamp,
       gameSessionId string,
       tags ARRAY<STRING>)
COMMENT 'game start events'
ROW FORMAT DELIMITED
        FIELDS TERMINATED BY '|'
        COLLECTION ITEMS TERMINATED BY '\073'
        LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://gameevents@netstuff.blob.core.windows.net/gameevents/game-heartbeat/';