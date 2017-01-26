DROP TABLE IF EXISTS DEFAULT.aggregatedcounters;

CREATE TABLE IF NOT EXISTS aggregatedcounters(
    displayName STRING,
    sumcount BIGINT
)
COMMENT 'total count per display name per game session per day'
PARTITIONED BY (year INT, month INT, day INT)
ROW FORMAT DELIMITED
    FIELDS TERMINATED BY '|'
    LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://intermediate@netstuff.blob.core.windows.net/counts/session/';


INSERT INTO TABLE aggregatedcounters
PARTITION (year, month, day)
SELECT
    displayName,
    sum(value),
    year(clientUtc) as year,
    month(clientUtc) as month,
    day(clientUtc) as day
FROM
    counts
GROUP BY
    clientUtc, displayName;



DROP TABLE IF EXISTS DEFAULT.aggregatedcounters;

CREATE TABLE IF NOT EXISTS aggregatedcounters(
    year INT,
    month INT,
    day INT,
    displayName STRING,
    sumcount BIGINT
)
COMMENT 'total count per display name per game session per day'
ROW FORMAT DELIMITED
    FIELDS TERMINATED BY '|'
    LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://intermediate@netstuff.blob.core.windows.net/aggcounts/';


INSERT INTO TABLE aggregatedcounters
SELECT
    year(clientUtc) as year,
    month(clientUtc) as month,
    day(clientUtc) as day,
    displayName,
    sum(value)
FROM
    counts
GROUP BY
    clientUtc, displayName;