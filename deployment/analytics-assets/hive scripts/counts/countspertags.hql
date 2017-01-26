-- STILL FAILING

DROP TABLE IF EXISTS default.countspertags;

CREATE TABLE IF NOT EXISTS countspertags(
    displayName STRING,
    tag STRING,
    gameSessionId STRING,
    value BIGINT
)
COMMENT 'counts of displayName per tag'
PARTITIONED BY (year INT, month INT, day INT)
ROW FORMAT DELIMITED
        FIELDS TERMINATED BY '|'
        LINES TERMINATED BY '\n'
STORED AS TEXTFILE
LOCATION 'wasbs://intermediate@netstuff.blob.core.windows.net/tagsexploded/';

INSERT INTO TABLE countspertags
PARTITION (year, month, day)
SELECT
    displayName,
    explode(tags) as tag,
    gameSessionId,
    value,
    year,
    month,
    day
FROM
    strippedcounts
GROUP BY
    year, month, day, displayName, tags;




17/01/19 11:03:31 WARN conf.HiveConf: HiveConf of name hive.scratchdir.lock does not exist

Logging initialized using configuration in jar:file:/usr/hdp/2.2.9.1-19/hive/lib/hive-common-0.14.0.2.2.9.1-19.jar!/hive-log4j.properties
OK
Time taken: 1.412 seconds
OK
Time taken: 0.469 seconds
FAILED: SemanticException [Error 10081]: UDTF's are not supported outside the SELECT clause, nor nested in expressions
