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

-- -----------------------------------------------
-- code to create a random number (1..10)
-- -----------------------------------------------
select NEWID()                                                  -- get new GUID
select CHECKSUM(NEWID())                                        -- get the checksum of a GUID (returns int - or +)
select CHECKSUM(NEWID()) % 10                                   -- mod 10 the checksum of a GUID to return values (-9..9)
select ABS(CHECKSUM(NEWID()) % 10)                              -- returns absolute values (0..9)
select CAST(ABS(CHECKSUM(NEWID())) % 10 AS VARCHAR(10))         -- convert to string ('0'..'9')
select CAST(1 + ABS(CHECKSUM(NEWID())) % 10 AS VARCHAR(10))     -- add 1 to eliminate zero values ('1'..'10')

-- -----------------------------------------------
-- code to create 10 random dates (with time)
-- -----------------------------------------------
SELECT
  DATEADD(
    second,
    1 + ABS(CHECKSUM(NEWID())) % (30*24*60*60), -- 30 days * 24 hours * 60 minutes * 60 seconds
    '20120101'                                  -- starting date
  ) AS starttime
FROM 
  dbo.GetNums(1, 10) AS Nums
  
-- -----------------------------------------------
-- Simple and Forced Parameterization
-- -----------------------------------------------
https://www.mssqltips.com/sqlservertip/2935/sql-server-simple-and-forced-parameterization/

--Forced
ALTER DATABASE AdventureWorks2012 SET PARAMETERIZATION FORCED

--Simple
ALTER DATABASE AdventureWorks2012 SET PARAMETERIZATION SIMPLE

-- determine the current setting of parameterization
SELECT name, is_parameterization_forced FROM sys.databases
-- 1 indicates Forced
-- 0 indicates Simple
-- Setting parameterization to FORCED flushes all query plan from cache except for those that are currently running, compiling, or recompiling
