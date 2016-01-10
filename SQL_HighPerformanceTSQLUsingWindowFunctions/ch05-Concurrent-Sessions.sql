-- concurrent sessions  (Max Concurrent Intervals)
-- μέγιστο πλήθος ταυτόχρονων sessions

IF OBJECT_ID('dbo.Sessions', 'U') IS NOT NULL DROP TABLE dbo.Sessions;
CREATE TABLE dbo.Sessions
(
  keycol INT NOT NULL,
  app VARCHAR(10) NOT NULL,
  usr VARCHAR(10) NOT NULL,
  host VARCHAR(10) NOT NULL,
  starttime DATETIME NOT NULL,
  endtime DATETIME NOT NULL,
  CONSTRAINT pk_Sessions PRIMARY KEY(keycol),
  CHECK(endtime > starttime)
);
GO
CREATE UNIQUE INDEX idx_nc_app_st_et ON dbo.Sessions(app, starttime, keycol) INCLUDE(endtime);
CREATE UNIQUE INDEX idx_nc_app_et_st ON dbo.Sessions(app, endtime, keycol) INCLUDE(starttime);

TRUNCATE TABLE dbo.Sessions;

INSERT INTO dbo.Sessions(keycol, app, usr, host, starttime, endtime) VALUES
(2, 'app1', 'user1', 'host1', '20120212 08:30', '20120212 10:30'),
(3, 'app1', 'user2', 'host1', '20120212 08:30', '20120212 08:45'),
(5, 'app1', 'user3', 'host2', '20120212 09:00', '20120212 09:30'),
(7, 'app1', 'user4', 'host2', '20120212 09:15', '20120212 10:30'),
(11, 'app1', 'user5', 'host3', '20120212 09:15', '20120212 09:30'),
(13, 'app1', 'user6', 'host3', '20120212 10:30', '20120212 14:30'),
(17, 'app1', 'user7', 'host4', '20120212 10:45', '20120212 11:30'),
(19, 'app1', 'user8', 'host4', '20120212 11:00', '20120212 12:30'),
(23, 'app2', 'user8', 'host1', '20120212 08:30', '20120212 08:45'),
(29, 'app2', 'user7', 'host1', '20120212 09:00', '20120212 09:30'),
(31, 'app2', 'user6', 'host2', '20120212 11:45', '20120212 12:00'),
(37, 'app2', 'user5', 'host2', '20120212 12:30', '20120212 14:00'),
(41, 'app2', 'user4', 'host3', '20120212 12:45', '20120212 13:30'),
(43, 'app2', 'user3', 'host3', '20120212 13:00', '20120212 14:00'),
(47, 'app2', 'user2', 'host4', '20120212 14:00', '20120212 16:30'),
(53, 'app2', 'user1', 'host4', '20120212 15:30', '20120212 17:00');

/* desired result:
app   mx
----- ----
app1   3
app2   4
*/

-- -----------------------------------------------------------------------------
-- 1. Traditional Set-Based Solution (slow when each app partition has a lot of data)
-- -----------------------------------------------------------------------------
WITH TimePoints AS
(
  SELECT app, starttime AS ts FROM dbo.Sessions  -- για κάθε session παίρνουμε την έναρξη
),
Counts AS
(
  SELECT
    app,
    ts,
    (
     SELECT COUNT(*)
     FROM dbo.Sessions AS S           -- πλήθος session που αφορούν:
     WHERE S.app = P.app AND          -- το ίδιο app και
           S.starttime <= P.ts AND    -- έχουν αρχίσει πρίν από την έναρξη του τρέχοντος session
           S.endtime > P.ts           -- και έχουν τελειώσει μετά την έναρξη του τρέχοντος session
    ) AS concurrent
  FROM
    TimePoints AS P
)
SELECT
  app,
  MAX(concurrent) AS mx               -- το μέγιστο πλήθος ταυτόχρονων sessions
FROM
  Counts
GROUP BY
  app;


-- -----------------------------------------------------------------------------
-- 2. Cursor Based Solution (create a list of starts and ends with +1 and -1 accordingly) (faster than solution 1)
-- -----------------------------------------------------------------------------
DECLARE
  @app AS varchar(10),
  @prevapp AS varchar (10),
  @ts AS datetime,
  @type AS int,
  @concurrent AS int,
  @mx AS int;
DECLARE @AppsMx TABLE
(
  app varchar (10) NOT NULL PRIMARY KEY,
  mx int NOT NULL
);
DECLARE sessions_cur CURSOR FAST_FORWARD FOR
  SELECT app, starttime AS ts, +1 AS type FROM dbo.Sessions
  UNION ALL
  SELECT app, endtime, -1 FROM dbo.Sessions
  ORDER BY app, ts, type;
OPEN sessions_cur;
FETCH NEXT FROM sessions_cur INTO @app, @ts, @type;

SET @prevapp = @app;
SET @concurrent = 0;
SET @mx = 0;

WHILE @@FETCH_STATUS = 0
BEGIN
  IF @app <> @prevapp
  BEGIN
    INSERT INTO @AppsMx VALUES(@prevapp, @mx);
    SET @concurrent = 0;
    SET @mx = 0;
    SET @prevapp = @app;
  END

  SET @concurrent = @concurrent + @type;
  IF @concurrent > @mx BEGIN
    SET @mx = @concurrent;
  END
  FETCH NEXT FROM sessions_cur INTO @app, @ts, @type;
END
CLOSE sessions_cur;
DEALLOCATE sessions_cur;

IF @prevapp IS NOT NULL
BEGIN
  INSERT INTO @AppsMx VALUES(@prevapp, @mx);
END
SELECT * FROM @AppsMx;

-- -----------------------------------------------------------------------------
-- 3. Window Functions Based Solution (both are the fastest but A solution faster than B solution)
-- -----------------------------------------------------------------------------

-- A. solution sql server 2012 (running totals based on a list of starts and ends with +1 and -1 accordingly)
WITH C1 AS
(
  SELECT app, starttime AS ts, +1 AS type FROM dbo.Sessions
  UNION ALL
  SELECT app, endtime, -1 FROM dbo.Sessions
),
C2 AS
(
  SELECT
    *,
    SUM(type) OVER(PARTITION BY app ORDER BY ts, type ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS cnt
  FROM C1
)
SELECT app, MAX(cnt) AS mx
FROM C2
GROUP BY app;

-- B. magic solution sql server 2005-2008 (running totals based on a list of starts and ends with +1 and -1 accordingly)
WITH C1 AS
(
  SELECT app, starttime AS ts, +1 AS type, keycol,
  ROW_NUMBER() OVER(PARTITION BY app ORDER BY starttime, keycol) AS start_ordinal -- number only the start events
  FROM dbo.Sessions
  UNION ALL
  SELECT app, endtime, -1, keycol, NULL
  FROM dbo.Sessions
)
C2 AS(
  SELECT *,
  ROW_NUMBER() OVER(PARTITION BY app ORDER BY ts, type, keycol) AS start_or_end_ordinal -- number Start and End events
  FROM C1
)
SELECT
  app,
  MAX(start_ordinal - (start_or_end_ordinal - start_ordinal)) AS mx  -- calculate the max based on Start and End events numbering
FROM
  C2
GROUP BY
  app;

