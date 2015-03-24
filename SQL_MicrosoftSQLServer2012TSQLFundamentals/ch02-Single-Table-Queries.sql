-- 2
-- Return orders placed on the last day of the month
-- Tables involved: Sales.Orders table
SELECT orderid, orderdate, custid, empid
FROM Sales.Orders
WHERE orderdate = EOMONTH(orderdate); -- sql server 2012

-- pre-SQL Server 2012 (advanced)
SELECT orderid, orderdate, custid, empid
FROM Sales.Orders
WHERE orderdate = DATEADD(month, DATEDIFF(month, '19991231', orderdate), '19991231');


-- 4
-- Return orders with total value(qty*unitprice) greater than 10000
-- sorted by total value
-- Tables involved: Sales.OrderDetails table
select 
orderid,
sum(qty * unitprice) as total
from Sales.OrderDetails
group by orderid
having sum(qty * unitprice) > 10000
order by total desc


-- 5
-- Return the three ship countries with the highest average freight in 2007
-- Tables involved: Sales.Orders table
select 
top 3
Sales.Orders.shipcountry,
avg(freight) as total
from Sales.Orders
where year(Sales.Orders.orderdate) = 2007
group by Sales.Orders.shipcountry
order by total desc

-- in SQL Server 2012
SELECT shipcountry, AVG(freight) AS avgfreight
FROM Sales.Orders
WHERE orderdate >= '20070101' AND orderdate < '20080101'
GROUP BY shipcountry
ORDER BY avgfreight DESC
OFFSET 0 ROWS FETCH FIRST 3 ROWS ONLY;


-- 6 
-- Calculate row numbers for orders
-- based on order date ordering (using order id as tiebreaker)
-- for each customer separately
-- Tables involved: Sales.Orders table
select custid, orderdate, orderid, 
  ROW_NUMBER () OVER (PARTITION BY custid order by custid, orderdate, orderid ) as rownum
from Sales.Orders
order by custid, orderdate, orderid


-- 7
-- Figure out and return for each employee the gender based on the title of courtesy
-- Ms., Mrs. - Female, Mr. - Male, Dr. - Unknown
-- Tables involved: HR.Employees table
select empid, firstname, lastname, titleofcourtesy,
CASE 
  WHEN titleofcourtesy='Ms.' or titleofcourtesy='Mrs.' THEN 'Female'
  WHEN titleofcourtesy='Mr.' THEN 'Male'
  ELSE 'Unknown'
END as gender
from HR.Employees

-- 8 (order with null values first)
-- Return for each customer the customer ID and region
-- sort the rows in the output by region
-- having NULLs sort last (after non-NULL values)
-- Note that the default in T-SQL is that NULL sort first
-- Tables involved: Sales.Customers table
select custid, region
from Sales.Customers
order by 
  CASE WHEN region IS NULL THEN 1 ELSE 0 END, region;
