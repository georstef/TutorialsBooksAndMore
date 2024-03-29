/*
Mode is a statistical calculation that returns the most frequently occurring value in the population.
Consider, for example, the Sales.Orders table, which holds order information. Each order was placed
by some customer and handled by some employee. Suppose you want to know, for each customer,
which employee handled the most orders.
That employee is the MODE because he appears most frequently in the customer’s orders.
*/

-- 1. solution with tie breaker (the lowest employeeID)
with T1 as (
  SELECT
    custid,
    empid,
    COUNT(*) AS cnt,
    ROW_NUMBER() OVER(PARTITION BY custid ORDER BY COUNT(*) DESC, empid DESC) AS rn -- get the position within the window
  FROM
    Sales.Orders
  GROUP BY
    custid, empid
)
SELECT custid, empid, cnt
FROM T1
WHERE rn = 1; -- show only position number 1 ()

-- 2. solution without tie breaker, returns all values that are equal
with T1 as (
  SELECT
    custid,
    empid,
    COUNT(*) AS cnt,
    RANK() OVER(PARTITION BY custid ORDER BY COUNT(*) DESC) AS rn -- get the position within the window
  FROM
    Sales.Orders
  GROUP BY
    custid, empid
)
SELECT custid, empid, cnt
FROM T1
WHERE rn = 1; -- show positions numbered 1

-- 3. solution with carry-along-sort concept (works fast enough when there is no index)
WITH T1 AS
(
  SELECT
    custid,
    STR(COUNT(*), 10) + STR(empid, 10) COLLATE Latin1_General_BIN2 AS cntemp -- create a concatenated string
  FROM Sales.Orders
  GROUP BY custid, empid
)
SELECT
  custid,
  CAST(SUBSTRING(MAX(cntemp), 11, 10) AS INT) AS empid, -- parse the highest concatenated string to get the employee
  CAST(SUBSTRING(MAX(cntemp), 1, 10) AS INT) AS cnt     -- parse the highest concatenated string to get the count(*)
FROM T1
GROUP BY custid;