-- 1 
-- Write a query that generates 5 copies out of each employee row
-- Tables involved: TSQL2012 database, Employees and Nums tables
select
  HR.Employees.empid, HR.Employees.firstname, HR.Employees.lastname, dbo.Nums.n
from
  HR.Employees
cross join
  dbo.Nums
where 
  dbo.Nums.n <= 5
  

-- 1++
-- Write a query that returns a row for each employee and day 
-- in the range June 12, 2009 – June 16 2009.
-- Tables involved: TSQL2012 database, Employees and Nums tables
select
  HR.Employees.empid, HR.Employees.firstname, HR.Employees.lastname,
  DATEADD(day, n-1, '20090612') as hmerominia
from
  HR.Employees
cross join
  dbo.Nums
where 
  dbo.Nums.n <= 5 -- DATEADD(day, n-1, '20090612') < '20090617'
order by HR.Employees.empid, n


-- 2
-- Return US customers, and for each customer the total number of orders and total quantities.
-- Tables involved: TSQL2012 database, Customers, Orders and OrderDetails tables
select
  Sales.Customers.custid,
  count(DISTINCT Sales.Orders.orderid) as TotalOrders,
  sum(Sales.OrderDetails.qty) as TotalQTY
from
  Sales.Customers
inner join
  Sales.Orders on Sales.Orders.custid = Sales.Customers.custid
inner join
  Sales.OrderDetails on Sales.OrderDetails.orderid = Sales.Orders.orderid  
where
  Sales.Customers.country = 'USA'
group by
  Sales.Customers.custid
  

-- 3
-- Return customers and their orders including customers who placed no orders
-- Tables involved: TSQL2012 database, Customers and Orders tables
select
  Sales.Customers.custid,
  Sales.Orders.orderid
from
  Sales.Customers
left join
  Sales.Orders on Sales.Orders.custid = Sales.Customers.custid


-- 4
-- Return customers who placed no orders
-- Tables involved: TSQL2012 database, Customers and Orders tables
select
  Sales.Customers.custid,
  Sales.Orders.orderid
from
  Sales.Customers
left join
  Sales.Orders on Sales.Orders.custid = Sales.Customers.custid
where
  Sales.Orders.orderid is null


-- 5
-- Return customers with orders placed on Feb 12, 2007 along with their orders
-- Tables involved: TSQL2012 database, Customers and Orders tables
select
  Sales.Customers.custid,
  Sales.Orders.orderid
from
  Sales.Customers
inner join
  Sales.Orders on Sales.Orders.custid = Sales.Customers.custid
where
  Sales.Orders.orderdate = '20070212'


-- 6
-- Return customers with orders placed on Feb 12, 2007 along with their orders
-- Also return customers who didn't place orders on Feb 12, 2007 
-- Tables involved: TSQL2012 database, Customers and Orders tables
select
  Sales.Customers.custid,
  Sales.Orders.orderid
from
  Sales.Customers
left join
  Sales.Orders on Sales.Orders.custid = Sales.Customers.custid
              and Sales.Orders.orderdate = '20070212'


-- 7
-- Return all customers, and for each return a Yes/No value
-- depending on whether the customer placed an order on Feb 12, 2007
-- Tables involved: TSQL2012 database, Customers and Orders tables
select
  Sales.Customers.custid,
  CASE WHEN Sales.Orders.orderid IS NULL 
    THEN 'No'
    ELSE 'Yes'
  END as YesNo
from
  Sales.Customers
left join
  Sales.Orders on Sales.Orders.custid = Sales.Customers.custid
              and Sales.Orders.orderdate = '20070212'
