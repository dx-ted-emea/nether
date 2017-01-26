DROP TABLE IF EXISTS default.monthlydurations;

CREATE TABLE IF NOT EXISTS DEFAULT.monthlydurations(
    year INT,
    month INT,
    displayName STRING,
    avgduration BIGINT
)
COMMENT 'average durations per display name per month'
ROW FORMAT DELIMITED
    FIELDS TERMINATED BY '|'
    LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://intermediate@netstuff.blob.core.windows.net/durations/monthly/';


INSERT INTO TABLE monthlydurations
SELECT
    year,
    month,
    displayName,
    avg(timeSpanSeconds) as avgduration
FROM
    durations
GROUP BY
    year, month, displayName;