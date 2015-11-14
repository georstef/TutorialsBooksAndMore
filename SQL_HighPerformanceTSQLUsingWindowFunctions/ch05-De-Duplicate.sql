-- 1) get row_number partition by ID (not order by) and then delete
WITH T1 AS
(
    SELECT id,
    ROW_NUMBER() OVER(PARTITION BY id ORDER BY (SELECT NULL)) AS n
    FROM Sales.MyOrders
)
DELETE FROM T1 WHERE n > 1;
/*
id       n
-------- --------------------
10248    1  <- keep (r=1)
10248    2  <- delete (r>1)
10248    3
10249    1  <- keep
10249    2
10249    3
10250    1  <- keep
10250    2
10250    3
*/
-- 1) get unique row_number and rank and then delete non matching
WITH T1 AS
(
    SELECT id,
    ROW_NUMBER() OVER(ORDER BY id) AS rn
    RANK() OVER(ORDER BY id) AS r
    FROM Sales.MyOrders
)
DELETE FROM T1 WHERE rn <> r;
/*
orderid  rownum  rnk
-------- ------- ------------
10248    1       1  <- keep (rn=r)
10248    2       1  <- delete (rn<>r)
10248    3       1
10249    4       4  <- keep
10249    5       4
10249    6       4
10250    7       7  <- keep
10250    8       7
10250    9       7
*/