-- -------------------------------------------------
-- 1. Dynamic SQL Pivot with STUFF -----------------
-- -------------------------------------------------
IF OBJECT_ID('tempdb.dbo.#CustomerProducts') IS NOT NULL
DROP TABLE dbo.#CustomerProducts;
GO

CREATE TABLE #CustomerProducts 
([CustomerName] varchar(20), [ProductName] varchar(20), [Amount] int) 
 
INSERT INTO #CustomerProducts 
 (CustomerName, ProductName, Amount) 
VALUES 
 ('Customer1', 'Product1', 10), 
 ('Customer1', 'Product1', 100), 
 ('Customer2', 'Product2', 20), 
 ('Customer2', 'Product2', 200), 
 ('Customer1', 'Product2', 30), 
 ('Customer1', 'Product2', 300), 
 ('Customer2', 'Product1', 40), 
 ('Customer2', 'Product1', 400); 
 
-- --------------------------------- 
 
DECLARE @products AS varchar(MAX) 
declare @query  AS NVARCHAR(MAX) 
set @products = STUFF((SELECT distinct ',' + ProductName 
                        FROM #CustomerProducts 
                        FOR XML PATH('') 
                       ), 1, 1, '') 
 
 
set @query = 'select * from #CustomerProducts 
               pivot (sum(Amount)                  -- data to pivot 
                 for ProductName in ('+@products+') -- column name 
                ) as C' 
 
 
execute(@query) 

-- -------------------------------------------------
-- 2. Dynamic SQL Pivot with Cursor ----------------
-- -------------------------------------------------
SET NOCOUNT ON

DECLARE 
  @orderyear int,
  @pivotfields nvarchar(200),
  @sql AS nVARCHAR(200);
  
DECLARE C CURSOR FOR
  SELECT distinct YEAR(orderdate) AS orderyear FROM Sales.Orders;
  
OPEN C;

FETCH NEXT FROM C INTO @orderyear;
SET @pivotfields = ''

while @@fetch_status = 0 BEGIN
  set @pivotfields = @pivotfields + QUOTENAME(@orderyear)+N',';
  
  FETCH NEXT FROM C INTO @orderyear;
END

DEALLOCATE C;

set @pivotfields = left(@pivotfields, len(@pivotfields)-1); -- last comma

set @sql = 'SELECT *
FROM 
  (SELECT shipperid, YEAR(orderdate) AS orderyear, freight FROM Sales.Orders) AS D
PIVOT
  (
   SUM(freight) FOR orderyear IN('+@pivotfields+')) AS P
   order by shipperid'

EXEC sp_executesql
  @stmt = @sql;

-- -------------------------------------------------
-- 3. Dynamic SQL Pivot with STUFF -----------------
-- the same data as the 2nd example ----------------
-- -------------------------------------------------
SET NOCOUNT ON

DECLARE 
  @orderyear int,
  @pivotfields nvarchar(200),
  @sql AS nVARCHAR(200);
  
set @pivotfields = STUFF((SELECT distinct ',' + quotename(cast(YEAR(orderdate) as varchar))
                        FROM Sales.Orders
                        FOR XML PATH('') 
                       ), 1, 1, '') 
set @sql = 'SELECT *
FROM 
  (SELECT shipperid, YEAR(orderdate) AS orderyear, freight FROM Sales.Orders) AS D
PIVOT
  (
   SUM(freight) FOR orderyear IN('+@pivotfields+')) AS P
   order by shipperid'

EXEC sp_executesql
  @stmt = @sql;
