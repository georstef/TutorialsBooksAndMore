-- --------------------------------------------------------------------
-- Conditional Aggregate
-- (computing a running total that always returns a non-negative value)
-- --------------------------------------------------------------------
IF OBJECT_ID('dbo.T1') IS NOT NULL DROP TABLE dbo.T1;
GO
CREATE TABLE dbo.T1
(
ordcol INT NOT NULL PRIMARY KEY,
datacol INT NOT NULL
);
INSERT INTO dbo.T1 VALUES
(1, 10),
(4, -15),
(5, 5),
(6, -10),
(8, -15),
(10, 20),
(17, 10),
(18, -10),
(20, -30),
(31, 20);

/* example of 
ordcol        datacol   nonnegativesum
----------- ----------- --------------
1               10          10
4              -15           0
5                5           5
6              -10           0
8              -15           0
10              20          20
17              10          30
18             -10          20
20             -30           0
31              20          20
*/
WITH C1 AS
(
  SELECT ordcol, datacol, SUM(datacol) OVER (ORDER BY ordcol ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS partsum
  FROM dbo.T1
),
C2 AS
(
  SELECT *, MIN(partsum) OVER (ORDER BY ordcol ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) as adjust
  FROM C1
)
SELECT *,
  partsum - CASE WHEN adjust < 0 THEN adjust ELSE 0 END -- note that:  X-(-Y) = X+Y
  AS nonnegativesum
FROM C2;


-- it can be written without the Framing part
WITH C1 AS
(
  SELECT ordcol, datacol, SUM(datacol) OVER (ORDER BY ordcol) AS partsum
  FROM dbo.T1
),
C2 AS
(
  SELECT *, MIN(partsum) OVER (ORDER BY ordcol) as adjust
  FROM C1
)
SELECT *,
  partsum - CASE WHEN adjust < 0 THEN adjust ELSE 0 END -- note that:  X-(-Y) = X+Y
  AS nonnegativesum
FROM C2;
