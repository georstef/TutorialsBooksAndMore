-- 1
-- Write a query against the dbo.Orders table that computes for each
-- customer order, both a rank and a dense rank,
-- partitioned by custid, ordered by qty 
select 
  custid, orderid, qty,
  RANK() OVER(/*partitioned by custid*/ORDER BY qty) AS rank,
  DENSE_RANK() OVER(/*partitioned by custid*/ORDER BY qty) AS dense_rank,

  ROW_NUMBER() OVER(/*partitioned by custid*/ORDER BY qty) AS rownum,
  NTILE(5) OVER(/*partitioned by custid*/ORDER BY qty) AS ntile
from
  dbo.Orders
  
  
-- 2
-- Write a query against the dbo.Orders table that computes for each
-- customer order:
-- * the difference between the current order quantity
--   and the customer's previous order quantity
-- * the difference between the current order quantity
--   and the customer's next order quantity.
select 
  custid, 
  orderid, 
  qty,
  qty - LAG(qty) OVER(PARTITION BY custid ORDER BY orderid) AS qty_previous_difference,
  qty - LEAD(qty) OVER(PARTITION BY custid ORDER BY orderid) AS qty_next_difference
from
  dbo.Orders
  

-- 3
-- Write a query against the dbo.Orders table that returns a row for each
-- employee, a column for each order year, and the count of orders
-- for each employee and order year

-- solution 1
with T1 as (
select
  empid,
  Year(orderdate) AS y
from
  dbo.Orders
group by
  empid,
  Year(orderdate)
)
select 
  empid, 
  [2007] AS cnt2007, 
  [2008] AS cnt2008, 
  [2009] AS cnt2009
from
  T1
PIVOT(count(y) FOR y IN ([2007], [2008], [2009])) AS T2

-- solution 2
SELECT empid,
  COUNT(CASE WHEN YEAR(orderdate) = 2007 THEN YEAR(orderdate) END) AS cnt2007,
  COUNT(CASE WHEN YEAR(orderdate) = 2008 THEN YEAR(orderdate) END) AS cnt2008,
  COUNT(CASE WHEN YEAR(orderdate) = 2009 THEN YEAR(orderdate) END) AS cnt2009  
FROM 
  dbo.Orders
GROUP BY empid;


-- 4
-- Run the following code to create and populate the EmpYearOrders table:
IF OBJECT_ID('dbo.EmpYearOrders', 'U') IS NOT NULL DROP TABLE dbo.EmpYearOrders;

CREATE TABLE dbo.EmpYearOrders
(
  empid INT NOT NULL
    CONSTRAINT PK_EmpYearOrders PRIMARY KEY,
  cnt2007 INT NULL,
  cnt2008 INT NULL,
  cnt2009 INT NULL
);

INSERT INTO dbo.EmpYearOrders(empid, cnt2007, cnt2008, cnt2009)
  SELECT empid, [2007] AS cnt2007, [2008] AS cnt2008, [2009] AS cnt2009
  FROM (SELECT empid, YEAR(orderdate) AS orderyear
        FROM dbo.Orders) AS D
    PIVOT(COUNT(orderyear)
          FOR orderyear IN([2007], [2008], [2009])) AS P;

SELECT * FROM dbo.EmpYearOrders;

-- Output:
empid       cnt2007     cnt2008     cnt2009
----------- ----------- ----------- -----------
1           1           1           1
2           1           2           1
3           2           0           2

-- Write a query against the EmpYearOrders table that unpivots
-- the data, returning a row for each employee and order year
-- with the number of orders
-- Exclude rows where the number of orders is 0
-- (in our example, employee 3 in year 2008)

-- solution 1
select 
  T.empid, 
  T.numorders,
  CAST(RIGHT(T.y, 4) as int) AS orderyear
from 
  dbo.EmpYearOrders
UNPIVOT (numorders FOR y IN([cnt2007], [cnt2008], [cnt2009])) AS T
where
  T.numorders <> 0
  
-- solution 2
SELECT *
FROM (
  SELECT 
    empid, 
    Years.orderyear,
    CASE Years.orderyear
      WHEN 2007 THEN cnt2007
      WHEN 2008 THEN cnt2008
      WHEN 2009 THEN cnt2009
    END AS numorders
  FROM dbo.EmpYearOrders
    CROSS JOIN (VALUES(2007),(2008),(2009)) AS Years (orderyear)
) AS D
WHERE numorders <> 0;


-- 5
-- Write a query against the dbo.Orders table that returns the 
-- total quantities for each:
-- employee, customer, and order year
-- employee and order year
-- customer and order year
-- Include a result column in the output that uniquely identifies 
-- the grouping set with which the current row is associated
select
  /*  GROUPING_ID(empid, custid, year(orderdate)) AS groupingset, */
  empid,
  custid,
  year(orderdate) as orderyear,
  sum(qty) as summary
from
  dbo.Orders
GROUP BY
  GROUPING SETS
  (
  (empid, custid, year(orderdate)),
  (empid, year(orderdate)),
  (custid, year(orderdate))
  )
