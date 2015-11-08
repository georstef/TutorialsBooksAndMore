-- Paging (return only rows 51..75)

-- with row_number (the hard way)
DECLARE
  @pagenum AS INT = 3,
  @pagesize AS INT = 25;

WITH C AS
( -- actual query
  SELECT ROW_NUMBER() OVER( ORDER BY orderdate, orderid ) AS rownum,
  orderid, orderdate, custid, empid
  FROM Sales.Orders
)
SELECT 
  orderid, orderdate, custid, empid, rownum
FROM 
  C
WHERE 
  rownum BETWEEN (@pagenum - 1) * @pagesize + 1 AND @pagenum * @pagesize
ORDER BY rownum;

-- -------------------------------------------------------------------------

-- with OFFSET..FETCH (the easy way)
DECLARE
  @pagenum AS INT = 3,
  @pagesize AS INT = 25;

SELECT 
  orderid, orderdate, custid, empid,
  ROW_NUMBER() OVER( ORDER BY orderdate, orderid ) AS rownum -- not needed
FROM 
  Sales.Orders
ORDER BY 
  orderdate, orderid
OFFSET (@pagenum - 1) * @pagesize ROWS FETCH NEXT @pagesize ROWS ONLY;

