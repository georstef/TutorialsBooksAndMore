-- 1
-- Write a query that generates a virtual auxiliary table of 10 numbers
-- in the range 1 through 10
-- Tables involved: no table
select 1 as num
union
select 2
union
select 3
union
select 4
union
select 5
union
select 6
union
select 7
union
select 8
union
select 9
union
select 10

-- Solution using the VALUES clause
SELECT n
FROM (VALUES(1),(2),(3),(4),(5),(6),(7),(8),(9),(10)) AS T1(n);


-- 2
-- Write a query that returns customer and employee pairs 
-- that had order activity in January 2008 but not in February 2008
-- Tables involved: TSQL2012 database, Orders table
select 
  custid, 
  empid
from 
  Sales.Orders
where
  Sales.Orders.orderdate >= '01/01/2008' and 
  Sales.Orders.orderdate <= '01/31/2008'
except
select 
  custid, 
  empid
from 
  Sales.Orders
where
  Sales.Orders.orderdate >= '02/01/2008' and 
  Sales.Orders.orderdate <= '02/29/2008'

  
-- 3
-- Write a query that returns customer and employee pairs 
-- that had order activity in both January 2008 and February 2008
-- Tables involved: TSQL2012 database, Orders table

--Desired output
select 
  custid, 
  empid
from 
  Sales.Orders
where
  Sales.Orders.orderdate >= '01/01/2008' and 
  Sales.Orders.orderdate <= '01/31/2008'
intersect
select 
  custid, 
  empid
from 
  Sales.Orders
where
  Sales.Orders.orderdate >= '02/01/2008' and 
  Sales.Orders.orderdate <= '02/29/2008'


-- 4
-- Write a query that returns customer and employee pairs 
-- that had order activity in both January 2008 and February 2008 but not in 2007
-- Tables involved: TSQL2012 database, Orders table
select 
  custid, 
  empid
from 
  Sales.Orders
where
  Sales.Orders.orderdate >= '01/01/2008' and 
  Sales.Orders.orderdate <= '01/31/2008'
intersect -- this takes precedence
select 
  custid, 
  empid
from 
  Sales.Orders
where
  Sales.Orders.orderdate >= '02/01/2008' and 
  Sales.Orders.orderdate <= '02/29/2008'
except -- this is secondary
select 
  custid, 
  empid
from 
  Sales.Orders
where
  Year(Sales.Orders.orderdate) = 2007


-- 5
-- You are given the following query:
SELECT country, region, city FROM HR.Employees
UNION ALL
SELECT country, region, city FROM Production.Suppliers;

-- You are asked to add logic to the query 
-- such that it would guarantee that the rows from Employees
-- would be returned in the output before the rows from Suppliers,
-- and within each segment, the rows should be sorted by country, region, city
-- Tables involved: TSQL2012 database, Employees and Suppliers tables
WITH OrderedUnion AS
(
SELECT 1 as aa, country, region, city FROM HR.Employees
UNION ALL
SELECT 2, country, region, city FROM Production.Suppliers
)
select
  country, 
  region, 
  city
from 
  OrderedUnion
order by
  aa, country, region, city
