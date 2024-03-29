-- Running totals

-- table and data needed for the example
SET NOCOUNT ON;

IF OBJECT_ID('dbo.Transactions', 'U') IS NOT NULL DROP TABLE dbo.Transactions;
CREATE TABLE dbo.Transactions
(
  actid INT NOT NULL, -- partitioning column
  tranid INT NOT NULL, -- ordering column
  val MONEY NOT NULL, -- measure
  CONSTRAINT PK_Transactions PRIMARY KEY(actid, tranid)
);

-- small set of sample data
INSERT INTO dbo.Transactions(actid, tranid, val) VALUES
(1, 1, 4.00),
(1, 2, -2.00),
(1, 3, 5.00),
(1, 4, 2.00),
(1, 5, 1.00),
(1, 6, 3.00),
(1, 7, -4.00),
(1, 8, -1.00),
(1, 9, -2.00),
(1, 10, -3.00),
(2, 1, 2.00),
(2, 2, 1.00),
(2, 3, 5.00),
(2, 4, 1.00),
(2, 5, -5.00),
(2, 6, 4.00),
(2, 7, 2.00),
(2, 8, -4.00),
(2, 9, -5.00),
(2, 10, 4.00),
(3, 1, -3.00),
(3, 2, 3.00),
(3, 3, -2.00),
(3, 4, 1.00),
(3, 5, 4.00),
(3, 6, -1.00),
(3, 7, 5.00),
(3, 8, 3.00),
(3, 9, 5.00),
(3, 10, -3.00);

/*
-- large set of data
DECLARE
  @num_partitions AS INT = 3, -- max number of Accounts
  @rows_per_partition AS INT = 1000; -- max number of Transactions per Account

TRUNCATE TABLE dbo.Transactions;

INSERT INTO dbo.Transactions WITH (TABLOCK) (actid, tranid, val)
SELECT
  NP.n,
  RPP.n,
  (ABS(CHECKSUM(NEWID())%2)*2-1) * (1 + ABS(CHECKSUM(NEWID())%5))
FROM
  dbo.GetNums(1, @num_partitions) AS NP
CROSS JOIN dbo.GetNums(1, @rows_per_partition) AS RPP;
*/
-- -----------------------------------------------------------------------------
-- NEW WAY (after SQL Server 2012)
-- -----------------------------------------------------------------------------

select
  actid, -- partitioning column
  tranid, -- ordering column
  val, -- measure
  sum(val) over(partition by actid order by tranid) as balance
from
  Transactions


-- or with Row Between for when the Order By field is not a tie breaker (not unique)
SELECT
  actid,
  tranid,
  val,
  SUM(val) OVER(PARTITION BY actid ORDER BY tranid ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS balance
FROM dbo.Transactions;

-- -----------------------------------------------------------------------------
-- OLD WAYS (prior to SQL Server 2012)
-- -----------------------------------------------------------------------------

-- with subquery (by subquerying the same table and summing previous rows) => really really slow
SELECT
  actid,
  tranid,
  val,
  (SELECT SUM(T2.val) FROM dbo.Transactions AS T2 WHERE T2.actid = T1.actid AND T2.tranid <= T1.tranid) AS balance
FROM
  dbo.Transactions AS T1;

-- with inner join (by joining the same table and summing previous rows) => really really slow
SELECT
  T1.actid,
  T1.tranid,
  T1.val,
  SUM(T2.val) AS balance
FROM
  dbo.Transactions AS T1
INNER JOIN
  dbo.Transactions AS T2 ON T2.actid = T1.actid
                        AND T2.tranid <= T1.tranid
GROUP BY
  T1.actid,
  T1.tranid,
  T1.val;

-- with cursor (faster than previous solutions after a few hundred rows per partition) => slow
DECLARE @Result AS TABLE
(
  actid INT,
  tranid INT,
  val MONEY,
  balance MONEY
);
DECLARE
  @actid AS INT,
  @prvactid AS INT,
  @tranid AS INT,
  @val AS MONEY,
  @balance AS MONEY;

DECLARE C CURSOR FAST_FORWARD FOR
    SELECT actid, tranid, val
    FROM dbo.Transactions
    ORDER BY actid, tranid;
OPEN C

FETCH NEXT FROM C INTO @actid, @tranid, @val;

SELECT
  @prvactid = @actid,
  @balance = 0;

WHILE @@fetch_status = 0 BEGIN
  IF @actid <> @prvactid BEGIN
    SELECT
      @prvactid = @actid,
      @balance = 0;
  END
  SET @balance = @balance + @val;

  INSERT INTO @Result VALUES(@actid, @tranid, @val, @balance);

  FETCH NEXT FROM C INTO @actid, @tranid, @val;
END
CLOSE C;
DEALLOCATE C;
SELECT * FROM @Result

-- all techniques based on speed are (fast to slow):
-- window functions                 [example above]
-- Multirow UPDATE with Variables   [no example]     <= not guaranteed to be fast
-- CLR-Based Solution               [no example]
-- cursor                           [example above]
-- Nested Iterations                [no example]
-- subquery/join                    [example above]

