-- create a Sequence object
CREATE SEQUENCE dbo.Seq1 AS INT START WITH 1 INCREMENT BY 1;

-- obtain new values from the sequence with [NEXT VALUE FOR] function
SELECT NEXT VALUE FOR dbo.Seq1;

-- use [NEXT VALUE FOR] function in queries
SELECT 
  orderid, 
  orderdate, 
  NEXT VALUE FOR dbo.Seq1 AS seqval 
FROM 
  Sales.OrderValues;

-- use [NEXT VALUE FOR] function in queries as WINDOW FUNCTION
SELECT 
  orderid, 
  orderdate, 
  NEXT VALUE FOR dbo.Seq1 OVER(ORDER BY orderdate, orderid) AS seqval
FROM 
  Sales.OrderValues;  
