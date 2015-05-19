- 1
-- Run the following code to create the dbo.Customers table
-- in the TSQL2012 database
IF OBJECT_ID('dbo.Customers', 'U') IS NOT NULL DROP TABLE dbo.Customers;

CREATE TABLE dbo.Customers
(
  custid      INT          NOT NULL PRIMARY KEY,
  companyname NVARCHAR(40) NOT NULL,
  country     NVARCHAR(15) NOT NULL,
  region      NVARCHAR(15) NULL,
  city        NVARCHAR(15) NOT NULL
);
GO

-- 1-1
-- Insert into the dbo.Customers table a row with:
-- custid:  100
-- companyname: Coho Winery
-- country:     USA
-- region:      WA
-- city:        Redmond
insert into dbo.Customers (custid, companyname, country, region, city)
values (100, 'Coho Winery', 'USA', 'WA', 'Redmond')

-- 1-2
-- Insert into the dbo.Customers table
-- all customers from Sales.Customers
-- who placed orders
insert into dbo.Customers (custid, companyname, country, region, city)
select
  distinct
  Sales.Customers.custid, Sales.Customers.companyname, Sales.Customers.country, Sales.Customers.region, Sales.Customers.city
from
  Sales.Customers
inner join
  Sales.Orders on Sales.Customers.custid = Sales.Orders.custid


-- 1-3
-- Use a SELECT INTO statement to create and populate the dbo.Orders table
-- with orders from the Sales.Orders
-- that were placed in the years 2006 through 2008
IF OBJECT_ID('dbo.Orders', 'U') IS NOT NULL DROP TABLE dbo.Orders;
select
  *
into dbo.Orders -- in SQL Azure the table must be created and populated separately
from
  Sales.Orders
where
  year(Sales.Orders.orderdate) between 2006 and 2008


-- 2
-- Delete from the dbo.Orders table
-- orders that were placed before August 2006
-- Use the OUTPUT clause to return the orderid and orderdate
-- of the deleted orders
delete from dbo.Orders
output deleted.orderid, deleted.orderdate
where dbo.Orders.orderdate < '08/01/2006'


-- 3
-- Delete from the dbo.Orders table orders placed by customers from Brazil
delete dbo.Orders
from dbo.Orders
inner join
  dbo.Customers on dbo.Customers.custid = dbo.Orders.custid
where dbo.Customers.country = 'Brazil'

-- or
MERGE INTO dbo.Orders AS O
USING dbo.Customers AS C ON O.custid = C.custid AND country = N'Brazil'
WHEN MATCHED THEN DELETE;

-- or
DELETE FROM dbo.Orders
WHERE EXISTS
  (SELECT *  FROM dbo.Customers AS C  WHERE dbo.Orders.custid = C.custid AND C.country = N'Brazil');


-- 4
-- Run the following query against dbo.Customers,
-- and notice that some rows have a NULL in the region column
SELECT * FROM dbo.Customers;

-- Update the dbo.Customers table and change all NULL region values to '<None>'
-- Use the OUTPUT clause to show the custid, old region and new region
update
  dbo.Customers
set
  dbo.Customers.region = '<None>'
output inserted.custid, deleted.region as oldregion, inserted.region as newregion
where dbo.Customers.region is null


-- 5
-- Update in the dbo.Orders table all orders placed by UK customers
-- and set their shipcountry, shipregion, shipcity values
-- to the country, region, city values of the corresponding customers from dbo.Customers
update 
  dbo.Orders
set 
  dbo.Orders.shipcountry = dbo.Customers.country,
  dbo.Orders.shipregion = dbo.Customers.region,
  dbo.Orders.shipcity = dbo.Customers.city
from
  dbo.Orders
inner join
  dbo.Customers on dbo.Customers.custid = dbo.Orders.custid
where
  dbo.Customers.country = 'UK'

-- or  
WITH CTE_UPD AS
(
  SELECT
    O.shipcountry AS ocountry, C.country AS ccountry,
    O.shipregion  AS oregion,  C.region  AS cregion,
    O.shipcity    AS ocity,    C.city    AS ccity
  FROM dbo.Orders AS O
    JOIN dbo.Customers AS C
      ON O.custid = C.custid
  WHERE C.country = 'UK'
)
UPDATE CTE_UPD
  SET ocountry = ccountry, oregion = cregion, ocity = ccity;
  
-- or
MERGE INTO dbo.Orders AS O
USING dbo.Customers AS C ON O.custid = C.custid AND C.country = 'UK'
WHEN MATCHED THEN
  UPDATE SET shipcountry = C.country,
             shipregion = C.region,
             shipcity = C.city;

-- clean up
IF OBJECT_ID('dbo.Orders', 'U') IS NOT NULL DROP TABLE dbo.Orders;
IF OBJECT_ID('dbo.Customers', 'U') IS NOT NULL DROP TABLE dbo.Customers ;
