-- TOP-N-PER-GROUP

-- Get the 3 most recent orders per customer

-- -----------------------------------------------------

-- first create an index following the POC concept.
-- P =Partition fields
-- O = Order fields
-- C = Cover fields (include)
CREATE NONCLUSTERED INDEX idx_cid_odD_oidD_i_empid ON Sales.Orders
  (custid, orderdate DESC, orderid DESC)
INCLUDE (empid)
WITH (
  PAD_INDEX = OFF,
  DROP_EXISTING = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  SORT_IN_TEMPDB = OFF,
  ONLINE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

-- -----------------------------------------------------

-- simple way with Row_Number
with T1 as (
  SELECT
    custid, 
    orderdate, 
    orderid, 
    empid,
    ROW_NUMBER() OVER(PARTITION BY custid ORDER BY orderdate DESC, orderid DESC) as rn
  FROM Sales.Orders
)
select * from T1 where rn <= 3

-- -----------------------------------------------------

-- slightly smarter way with Cross Apply (parallelism)
SELECT 
  C.custid, 
  T1.*
FROM 
  Sales.Customers AS C
CROSS APPLY 
  (SELECT 
     orderdate, orderid, empid
   FROM 
     Sales.Orders AS O
   WHERE 
     O.custid = C.custid
   ORDER BY 
     orderdate DESC, orderid DESC
   OFFSET 0 ROWS FETCH FIRST 3 ROWS ONLY -- or use top 3
  ) AS T1;
    
-- -----------------------------------------------------
    
-- fast way for no index (really ugly) but only 1 top value is returned
-- also know as the carry-along sort (technique/concept)
-- pack/concatenate all the fields in a string grouped by custid in a CTE
-- and finally unpack them with substring
WITH T1 AS
(
SELECT 
  custid,
  MAX(
    CONVERT(CHAR(8), orderdate, 112) + 
    STR(orderid, 10) + 
    STR(empid, 10) COLLATE Latin1_General_BIN2
  ) AS mx
FROM 
  Sales.Orders
GROUP BY 
  custid
)
SELECT 
  custid,
  CAST(SUBSTRING(mx, 1, 8) AS DATETIME) AS orderdate,
  CAST(SUBSTRING(mx, 9, 10) AS INT) AS custid,
  CAST(SUBSTRING(mx, 19, 10) AS INT) AS empid
FROM 
  T1;    