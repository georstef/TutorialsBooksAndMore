-- LAG(<field>, <Nth>, <default value>) : returns the previous <Nth> value in current window
-- LEAD(<field>, <Nth>, <default value>)  : returns the next <Nth> value in current window
-- FIRST_VALUE(<field>) :  returns the first value in current window based on the default frame (see NOTE)
-- LAG(<field>) : returns the last value in current window based on the default frame (see NOTE) 
--                so it always returns the current value, to get the last value we frame it with: ROWS BETWEEN CURRENT ROW AND UNBOUNDED FOLLOWING
--
-- NOTE: if framing is applicable and we don’t indicate a window frame clause, the default is RANGE BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW

SELECT 
  custid, 
  orderdate, 
  orderid, 
  val,
  LAG(val,1, 0) OVER(PARTITION BY custid ORDER BY orderdate, orderid) AS prevval,
  LEAD(val,1, 0) OVER(PARTITION BY custid ORDER BY orderdate, orderid) AS nextval,
  FIRST_VALUE(val) OVER(PARTITION BY custid ORDER BY orderdate, orderid) AS firstval,
  LAST_VALUE(val) OVER(PARTITION BY custid ORDER BY orderdate, orderid ROWS BETWEEN CURRENT ROW AND UNBOUNDED FOLLOWING) AS lastval
FROM 
  Sales.OrderValues
order by
  custid, 
  orderdate, 
  orderid
