DROP TABLE IF EXISTS default.storecountspersession;

CREATE TABLE IF NOT EXISTS storecountspersession(
    gameSessionId STRING,
    itemBought STRING,
    sumAmount BIGINT,
    tags ARRAY<STRING>
)
COMMENT 'counts of itemBought per game session'
PARTITIONED BY (year INT, month INT, day INT)
ROW FORMAT DELIMITED
        FIELDS TERMINATED BY '|'
        COLLECTION ITEMS TERMINATED BY '\073'
        LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://immediate@netstuff.blob.core.windows.net/aggstorecounts/session/';

INSERT INTO TABLE storecountspersession
PARTITION (year, month, day)
SELECT
    gameSessionId,
    itemBought,
    sum(value),
    tags,
    year,
    month,
    day
FROM
    strippedstorecounts
WHERE
    (length(gameSessionId) > 0)
GROUP BY
    year, month, day, gameSessionId, itemBought, tags;