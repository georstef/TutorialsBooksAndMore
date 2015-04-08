-- 1-1
-- Write a query that returns the maximum order date for each employee
-- Tables involved: TSQL2012 database, Sales.Orders table
select 
  empid, 
  max(orderdate) as maxorderdate
from
  Sales.Orders
group by
  empid

  
-- 1-2
-- Encapsulate the query from exercise 1-1 in a derived table
-- Write a join query between the derived table and the Sales.Orders
-- table to return the Sales.Orders with the maximum order date for 
-- each employee
-- Tables involved: Sales.Orders
select 
  Sales.Orders.empid,
  Sales.Orders.orderdate,
  Sales.Orders.orderid, 
  Sales.Orders.custid
from
  Sales.Orders
inner join
  (select empid, max(orderdate) as maxorderdate from Sales.Orders group by empid) as T1
  on T1.empid = Sales.Orders.empid and T1.maxorderdate = Sales.Orders.orderdate


-- 2-1
-- Write a query that calculates a row number for each order
-- based on orderdate, orderid ordering
-- Tables involved: Sales.Orders
select 
  orderid, orderdate, custid, empid, row_number() OVER (order by orderdate, orderid ) as rownum
from
  Sales.Orders
  
  
-- 2-2
-- Write a query that returns rows with row numbers 11 through 20
-- based on the row number definition in exercise 2-1
-- Use a CTE to encapsulate the code from exercise 2-1
-- Tables involved: Sales.Orders
WITH OrderedSales AS
(
select 
  orderid, orderdate, custid, empid, row_number() OVER (order by orderdate, orderid ) as rownum
from
  Sales.Orders
)
select 
  *
from
  OrderedSales
where
  rownum >= 11 and
  rownum <= 20
  
  
-- 3
-- Write a solution using a recursive CTE that returns the 
-- management chain leading to Zoya Dolgopyatova (employee ID 9)
-- Tables involved: HR.Employees  
WITH EmpsCTE AS
(
  -- get first employee
  SELECT empid, mgrid, firstname, lastname
  FROM HR.Employees
  WHERE empid = 9
  UNION ALL
  -- get the manager of the previous employee
  SELECT Manager.empid, Manager.mgrid, Manager.firstname, Manager.lastname
  FROM HR.Employees AS Manager
  JOIN EmpsCTE AS Employee ON Employee.mgrid = Manager.empid
)
SELECT empid, mgrid, firstname, lastname
FROM EmpsCTE;


-- 4-1
-- Create a view [Sales.VEmpOrders] that returns the total qty
-- for each employee and year
-- Tables involved: Sales.Orders and Sales.OrderDetails
IF OBJECT_ID('Sales.VEmpOrders') IS NOT NULL DROP VIEW Sales.VEmpOrders;
GO
CREATE VIEW Sales.VEmpOrders
AS
select 
  empid, Year(Sales.Orders.orderdate) as orderyear, SUM(qty) as qty
from Sales.Orders 
inner join Sales.OrderDetails on Sales.OrderDetails.orderid = Sales.Orders.orderid
group by
  empid, 
  Year(Sales.Orders.orderdate)
GO
SELECT * FROM Sales.VEmpOrders ORDER BY empid, orderyear;


-- 4-2
-- Write a query against Sales.VEmpOrders
-- that returns the running qty for each employee and year using subqueries
-- Tables involved: TSQL2012 database, Sales.VEmpOrders view
SELECT 
  T1.*,
  (
    select 
      SUM(qty)
    from Sales.Orders
    inner join Sales.OrderDetails on Sales.OrderDetails.orderid = Sales.Orders.orderid
    where 
      Sales.Orders.empid = T1.empid and
      Year(Sales.Orders.orderdate) <= T1.orderyear
  ) as runqty
FROM Sales.VEmpOrders as T1 ORDER BY empid, orderyear;

-- clean up
IF OBJECT_ID('Sales.VEmpOrders') IS NOT NULL DROP VIEW Sales.VEmpOrders;


-- 5-1
-- Create an inline function [Production.TopProducts] that accepts as inputs
-- a supplier id (@supid AS INT), 
-- and a requested number of products (@n AS INT)
-- The function should return @n products with the highest unit prices
-- that are supplied by the given supplier id
-- Tables involved: Production.Products
IF OBJECT_ID('Production.TopProducts') IS NOT NULL DROP FUNCTION Production.TopProducts;
GO
CREATE FUNCTION Production.TopProducts (@supid AS INT, @n AS INT)
RETURNS TABLE
AS
RETURN
select top (@n) productid, productname, unitprice
from Production.Products
where
  supplierid = @supid
order by unitprice desc
GO
SELECT * FROM Production.TopProducts(5, 2)
GO


-- 5-2
-- Using the CROSS APPLY operator
-- and the function you created in exercise 5-1,
-- return, for each supplier, the two most expensive products
select
  supplierid, companyname, productid, productname, unitprice
from
  Production.Suppliers
cross apply Production.TopProducts(Production.Suppliers.supplierid, 2)

-- clean up
IF OBJECT_ID('Production.TopProducts') IS NOT NULL DROP FUNCTION Production.TopProducts;  
