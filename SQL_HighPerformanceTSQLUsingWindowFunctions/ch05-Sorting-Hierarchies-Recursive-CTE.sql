-- --------------------------------------------------------------------
-- Sorting Hierarchies - Recursive CTE
-- (present information from some hierarchy in a sorted fashion)
-- --------------------------------------------------------------------
IF OBJECT_ID('dbo.Employees') IS NOT NULL DROP TABLE dbo.Employees;
GO

CREATE TABLE dbo.Employees
(
empid INT NOT NULL PRIMARY KEY,
mgrid INT NULL REFERENCES dbo.Employees,
empname VARCHAR(25) NOT NULL,
salary MONEY NOT NULL,
CHECK (empid <> mgrid)
);

CREATE UNIQUE INDEX idx_unc_mgrid_empid ON dbo.Employees(mgrid, empid);

INSERT INTO dbo.Employees(empid, mgrid, empname, salary) VALUES
(1, NULL, 'David' , $10000.00),
(2, 1, 'Eitan' , $7000.00),
(3, 1, 'Ina' , $7500.00),
(4, 2, 'Seraph' , $5000.00),
(5, 2, 'Jiru' , $5500.00),
(6, 2, 'Steve' , $4500.00),
(7, 3, 'Aaron' , $5000.00),
(8, 5, 'Lilach' , $3500.00),
(9, 7, 'Rita' , $3000.00),
(10, 5, 'Sean' , $3000.00),
(11, 7, 'Gabriel', $3000.00),
(12, 9, 'Emilia' , $2000.00),
(13, 9, 'Michael', $2000.00),
(14, 9, 'Didi' , $1500.00);

-- regular CTE that computes an attribute called n representing a row number partitioned by mgrid and ordered by empname, empid
WITH EmpsRN AS
(
SELECT *,
ROW_NUMBER() OVER(PARTITION BY mgrid ORDER BY empname, empid) AS n
FROM dbo.Employees
)
SELECT * FROM EmpsRN;
/* returns:
empid   mgrid  empname   salary   n
------ ------ -------- --------- ---
1       NULL    David   10000.00  1
2       1       Eitan   7000.00   1
3       1       Ina     7500.00   2
5       2       Jiru    5500.00   1
4       2       Seraph  5000.00   2
6       2       Steve   4500.00   3
7       3       Aaron   5000.00   1
8       5       Lilach  3500.00   1
10      5       Sean    3000.00   2
11      7       Gabriel 3000.00   1
9       7       Rita    3000.00   2
14      9       Didi    1500.00   1
12      9       Emilia  2000.00   2
13      9       Michael 2000.00   3
*/

-- recursive CTE that iterates through the employees one level at a time,
-- starting with the root (CEO), then to direct subordinates, then to subordinates of subordinates, and so on
WITH EmpsRN AS
(
    SELECT
      *,
      ROW_NUMBER() OVER(PARTITION BY mgrid ORDER BY empname, empid) AS n
      -- if siblings need to be sorted differently (eg. by salary)simply change the ROW_NUMBER ordering clause accordingly
      -- ROW_NUMBER() OVER(PARTITION BY mgrid ORDER BY salary, empid) AS n
    FROM
      dbo.Employees
),
EmpsPath AS
(
    SELECT
      empid,
      empname,
      salary,
      0 AS lvl,
      CAST(0x AS VARBINARY(MAX)) AS sortpath
    FROM
      dbo.Employees
    WHERE
      mgrid IS NULL

    UNION ALL

    SELECT
      C.empid,
      C.empname,
      C.salary,
      P.lvl + 1,
      P.sortpath + CAST(n AS BINARY(2))
    FROM
      EmpsPath AS P
    INNER JOIN
      EmpsRN AS C ON C.mgrid = P.empid
    )
SELECT
  *,
  REPLICATE(' | ', lvl) + empname AS empname
FROM
  EmpsPath
ORDER BY
  sortpath;

