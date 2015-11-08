-- assumes dbo.GetNums exists
-- for 1 day interval
DECLARE
  @start AS DATE = '20150101',
  @end AS DATE = '20151231';

SELECT 
  DATEADD(day, n, @start) AS dt
FROM 
  dbo.GetNums(0, DATEDIFF(day, @start, @end)) AS Nums;

-- for 6 hours interval
DECLARE
  @start AS DATETIME2 = '2015-01-01 00:00:00.0000000',
  @end AS DATETIME2 = '2015-01-02 12:00:00.0000000';
SELECT 
  DATEADD(hour, n*6, @start) AS dt
FROM 
  dbo.GetNums(0, DATEDIFF(hour, @start, @end)/6) AS Nums;