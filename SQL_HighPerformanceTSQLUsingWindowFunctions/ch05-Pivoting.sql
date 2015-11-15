-- for PIVOT first prepare a CTE with all the fields
-- a) grouping elements
-- b) spreading elements
-- c) aggregate elements

-- ------------------------------------------------------------------------------

-- most recent 5 order values
WITH C AS
(
  SELECT 
    custid,  -- grouping element
    ROW_NUMBER() OVER(PARTITION BY custid ORDER BY orderdate DESC, orderid DESC) AS rownum,  -- spreading element
    val  -- aggregate element
  FROM Sales.OrderValues
)
SELECT *
FROM C
PIVOT(MAX(val) FOR rownum IN ([1],[2],[3],[4],[5])) AS P;

-- ------------------------------------------------------------------------------

-- most recent 5 orders (concatenated)
WITH C AS
(
  SELECT custid, cast(orderid as varchar) as sorderid,
  ROW_NUMBER() OVER(PARTITION BY custid ORDER BY orderdate DESC, orderid DESC) AS rownum
  FROM Sales.OrderValues
)
SELECT custid, CONCAT([1], ','+[2], ','+[3], ','+[4], ','+[5]) AS orderids -- [1] [2] [3] etc. are field names
FROM C
PIVOT(MAX(sorderid) FOR rownum IN ([1],[2],[3],[4],[5])) AS P; -- here data [1] becomes a field name
