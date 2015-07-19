/*
The order in which the various query clauses are conceptually evaluated:
1. FROM
2. WHERE
3. GROUP BY
4. HAVING        -- grouped aggregates are allowed from phase 4 and on
5. SELECT        -- window aggregates are allowed from phase 5 and on
6. ORDER BY
*/

SELECT 
  empid,
  SUM(val) AS emptotal,
  SUM(SUM(val)) OVER() as total,  -- SUM(val) = grouped aggregate
  SUM(val) / SUM(SUM(val)) OVER() * 100. AS pct
FROM 
  Sales.OrderValues
GROUP BY 
  empid
  
-- same with CTE  
WITH C AS
(
  SELECT 
    empid,
    SUM(val) AS emptotal
  FROM 
    Sales.OrderValues
  GROUP BY 
    empid
)
SELECT 
  empid, 
  emptotal,
  SUM(emptotal) OVER() AS total,
  emptotal / SUM(emptotal) OVER() * 100. AS pct
FROM 
  C;  
  