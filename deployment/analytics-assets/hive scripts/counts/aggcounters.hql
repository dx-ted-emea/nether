DROP TABLE IF EXISTS DEFAULT.agghourlycounts;
DROP TABLE IF EXISTS DEFAULT.aggdailycounts;
DROP TABLE IF EXISTS DEFAULT.aggmonthlycounts;
DROP TABLE IF EXISTS DEFAULT.aggyearlycounts;


CREATE TABLE IF NOT EXISTS agghourlycounts(
    hour INT,
    displayName STRING,
    sumcount BIGINT
)
COMMENT 'total count per display name per game session per hour'
PARTITIONED BY (year INT, month INT, day INT)
ROW FORMAT DELIMITED
    FIELDS TERMINATED BY '|'
    LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://intermediate@netstuff.blob.core.windows.net/aggcounts/hourly/';


CREATE TABLE IF NOT EXISTS aggdailycounts(
    day INT,
    displayName STRING,
    sumcount BIGINT
)
COMMENT 'total count per display name per game session per day'
PARTITIONED BY (year INT, month INT)
ROW FORMAT DELIMITED
    FIELDS TERMINATED BY '|'
    LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://intermediate@netstuff.blob.core.windows.net/aggcounts/daily/';


CREATE TABLE IF NOT EXISTS aggmonthlycounts(
    month INT,
    displayName STRING,
    sumcount BIGINT
)
COMMENT 'total count per display name per game session per month'
PARTITIONED BY (year INT)
ROW FORMAT DELIMITED
    FIELDS TERMINATED BY '|'
    LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://intermediate@netstuff.blob.core.windows.net/aggcounts/monthly/';


CREATE TABLE IF NOT EXISTS aggyearlycounts(
    year INT,
    displayName STRING,
    sumcount BIGINT
)
COMMENT 'total count per display name per game session per year'
ROW FORMAT DELIMITED
    FIELDS TERMINATED BY '|'
    LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://intermediate@netstuff.blob.core.windows.net/aggcounts/yearly/';


INSERT INTO TABLE agghourlycounts
PARTITION (year, month, day)
SELECT
    hour,
    displayName,
    sum(value),
    year,
    month,
    day
FROM
    strippedcounts
GROUP BY
    year, month, day, hour, displayName;


INSERT INTO TABLE aggdailycounts
PARTITION (year, month)
SELECT
    day,
    displayName,
    sum(value),
    year,
    month
FROM
    strippedcounts
GROUP BY
    year, month, day, displayName;


INSERT INTO TABLE aggmonthlycounts
PARTITION (year)
SELECT
    month,
    displayName,
    sum(value),
    year
FROM
    strippedcounts
GROUP BY
    year, month, displayName;


INSERT INTO TABLE aggyearlycounts
SELECT
    year,
    displayName,
    sum(value)
FROM
    strippedcounts
GROUP BY
    year, displayName;