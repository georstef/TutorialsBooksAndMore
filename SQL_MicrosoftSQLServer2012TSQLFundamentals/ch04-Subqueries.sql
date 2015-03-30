-- 1 
-- Write a query that returns all orders placed on the last day of
-- activity that can be found in the Orders table
-- Tables involved: TSQL2012 database, Orders table
select 
  orderid, orderdate, custid, empid  
from
  Sales.Orders
where
  orderdate = (select max(orderdate) from Sales.Orders)

  
-- 2 
-- Write a query that returns all orders placed
-- by the customer(s) who placed the highest number of orders
-- * Note: there may be more than one customer
--   with the same number of orders
-- Tables involved: TSQL2012 database, Orders table
select 
  orderid, orderdate, custid, empid  
from
  Sales.Orders
where
  custid in (
  select custid 
  from Sales.Orders 
  group by custid
  having count(*) = (select top 1 count(*) as cnt from Sales.Orders group by custid order by cnt desc)
)

-- a better solution
SELECT 
  custid, orderid, orderdate, empid
FROM 
  Sales.Orders
WHERE 
  custid IN
  (SELECT TOP (1) WITH TIES O.custid
   FROM Sales.Orders AS O
   GROUP BY O.custid
   ORDER BY COUNT(*) DESC)
   

-- 3
-- Write a query that returns employees
-- who did not place orders on or after May 1st, 2008
-- Tables involved: TSQL2012 database, Employees and Orders tables
select 
  empid, firstname, lastname
from
  hr.employees
where
  not exists
  (
  select * from Sales.Orders
  where Sales.orders.empid = hr.employees.empid
    and orderdate >= '05/01/2008'
  )


-- 4
-- Write a query that returns
-- countries where there are customers but not employees
-- Tables involved: TSQL2012 database, Customers and Employees tables
select
  distinct
  Sales.customers.country
from
  Sales.customers
where
  not exists (select * from hr.employees where hr.employees.country = Sales.customers.country)
  

-- 5
-- Write a query that returns for each customer
-- all orders placed on the customer's last day of activity
-- Tables involved: TSQL2012 database, Orders 
select 
  custid, orderid, orderdate, empid  
from
  Sales.Orders as o1
where
  orderdate = (select max(orderdate) from Sales.Orders as o2 where o1.custid = o2.custid)
order by
  custid
  
  
-- 6
-- Write a query that returns customers
-- who placed orders in 2007 but not in 2008
-- Tables involved: TSQL2012 database, Customers and Orders 
select 
  Sales.Customers.custid, Sales.Customers.companyname
from
  Sales.Customers
where
  exists (select * from Sales.Orders where Sales.Orders.custid = Sales.Customers.custid and orderdate >= '01/01/2007' and orderdate <= '12/31/2007')
  and
  not exists (select * from Sales.Orders where Sales.Orders.custid = Sales.Customers.custid and orderdate >= '01/01/2008' and orderdate <= '12/31/2008')
order by
  custid


-- 7
-- Write a query that returns customers
-- who ordered product 12
-- Tables involved: TSQL2012 database, Customers, Orders and OrderDetails 
select 
  distinct
  Sales.Customers.custid, Sales.Customers.companyname
from
  Sales.Customers
inner join
  Sales.Orders on Sales.Orders.custid = Sales.Customers.custid   
inner join
  Sales.OrderDetails on Sales.OrderDetails.orderid = Sales.Orders.orderid   
where
  Sales.OrderDetails.productid = 12


-- 8
-- Write a query that calculates a running total qty
-- for each customer and month using subqueries
-- Tables involved: TSQL2012 database, Sales.CustOrders view
select
  *,
  (select sum(qty) 
   from Sales.CustOrders  as co2 
   where co2.custid = co1.custid and 
         co2.ordermonth <= co1.ordermonth) as runningtotalqty
from
  Sales.CustOrders as co1
order by
  custid, 
  ordermonth
