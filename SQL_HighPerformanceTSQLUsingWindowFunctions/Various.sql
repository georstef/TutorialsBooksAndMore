-- -----------------------------------------------
-- code to create a helper function called GetNums which generates a sequence of integers in the requested range
-- -----------------------------------------------
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
Nums AS (SELECT ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS rownum
FROM L5)
SELECT @low + rownum - 1 AS n -- name of field
FROM Nums
ORDER BY rownum
OFFSET 0 ROWS FETCH FIRST @high - @low + 1 ROWS ONLY;
GO

-- use of dbo.GetNums (for master table)
TRUNCATE TABLE dbo.master;
INSERT INTO dbo.master WITH (TABLOCK) (masterid)
SELECT n AS masterid FROM dbo.GetNums(1, 100) AS P;

-- (for detail table)
INSERT INTO dbo.detail WITH (TABLOCK) (masterid, childid)
SELECT MA.n as masterid, CH.n as childid
FROM dbo.GetNums(1, 100) AS MA
CROSS JOIN dbo.GetNums(1, 1000) AS CH;
