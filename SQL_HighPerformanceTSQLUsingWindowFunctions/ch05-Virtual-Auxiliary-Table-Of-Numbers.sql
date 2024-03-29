-- cross join to square the number of rows
WITH
  L0 AS (SELECT c FROM (VALUES(1),(1)) AS D(c)), -- 2 rows
  L1 AS (SELECT 1 AS c FROM L0 AS A CROSS JOIN L0 AS B) -- 2*2=4 rows
SELECT 1 AS c FROM L1 AS A CROSS JOIN L1 AS B; -- 4*4 = 16 rows

-- use ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) to generate the actual numbers
WITH
  L0 AS (SELECT c FROM (VALUES(1),(1)) AS D(c)),
  L1 AS (SELECT 1 AS c FROM L0 AS A CROSS JOIN L0 AS B),
  L2 AS (SELECT 1 AS c FROM L1 AS A CROSS JOIN L1 AS B),
  L3 AS (SELECT 1 AS c FROM L2 AS A CROSS JOIN L2 AS B),
  L4 AS (SELECT 1 AS c FROM L3 AS A CROSS JOIN L3 AS B),
  L5 AS (SELECT 1 AS c FROM L4 AS A CROSS JOIN L4 AS B),
  Nums AS (SELECT ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS rownum FROM L5)
SELECT 
  rownum
FROM 
  Nums
ORDER BY rownum

-- create UDF to get a table with "low" to "high" sequence of numbers (records)
IF OBJECT_ID('dbo.GetNums', 'IF') IS NOT NULL DROP FUNCTION dbo.GetNums;
GO
CREATE FUNCTION dbo.GetNums(@low AS BIGINT, @high AS BIGINT) RETURNS TABLE
AS
RETURN
  WITH
	L0 AS (SELECT c FROM (VALUES(1),(1)) AS D(c)),
	L1 AS (SELECT 1 AS c FROM L0 AS A CROSS JOIN L0 AS B),
	L2 AS (SELECT 1 AS c FROM L1 AS A CROSS JOIN L1 AS B),
	L3 AS (SELECT 1 AS c FROM L2 AS A CROSS JOIN L2 AS B),
	L4 AS (SELECT 1 AS c FROM L3 AS A CROSS JOIN L3 AS B),
	L5 AS (SELECT 1 AS c FROM L4 AS A CROSS JOIN L4 AS B),
	Nums AS (SELECT ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS rownum FROM L5)
SELECT 
  @low + rownum - 1 AS n
FROM 
  Nums
ORDER BY 
  rownum
OFFSET 0 ROWS FETCH FIRST @high - @low + 1 ROWS ONLY;
GO