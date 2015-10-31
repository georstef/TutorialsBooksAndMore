-- tables needed for this chapter
SET NOCOUNT ON;
USE TSQL2012;
IF OBJECT_ID('dbo.Transactions', 'U') IS NOT NULL DROP TABLE dbo.Transactions;
IF OBJECT_ID('dbo.Accounts', 'U') IS NOT NULL DROP TABLE dbo.Accounts;
CREATE TABLE dbo.Accounts
(
    actid INT NOT NULL,
    actname VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Accounts PRIMARY KEY(actid)
);
CREATE TABLE dbo.Transactions
(
    actid INT NOT NULL,
    tranid INT NOT NULL,
    val MONEY NOT NULL,
    CONSTRAINT PK_Transactions PRIMARY KEY(actid, tranid),
    CONSTRAINT FK_Transactions_Accounts
    FOREIGN KEY(actid)
    REFERENCES dbo.Accounts(actid)
);
INSERT INTO dbo.Accounts(actid, actname) VALUES
    (1, 'account 1'),
    (2, 'account 2'),
    (3, 'account 3');
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
    
-- to optimize window functions create POC indexes
-- POC = Partitioning - Ordering - Covering
-- first all the PartitionBy fields, 
-- followed by all the OrderBy fields and 
-- just include all the rest of the columns to Cover
-- eg. for the following query 
SELECT actid, tranid, val,
ROW_NUMBER() OVER(PARTITION BY actid ORDER BY val) AS rownum
FROM dbo.Transactions;

-- the following index will minimize/optimize the time needed to run
CREATE NONCLUSTERED INDEX Transactions_idx ON dbo.Transactions
  (actid /*PartitionBy fields*/, val /*OrderBy fields*/)
INCLUDE (tranid/*Cover Columns*/)
GO    