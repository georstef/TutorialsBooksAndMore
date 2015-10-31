 -- first day of the month
select DATEADD(month, DATEDIFF(month, '19990101', current_timestamp), '19990101');

-- last day of the month
select DATEADD(month, DATEDIFF(month, '19991231', current_timestamp), '19991231');


-- get last identity value
SELECT
  SCOPE_IDENTITY() AS [SCOPE_IDENTITY],        -- current session, current scope
  @@identity AS [@@identity],                  -- current session, regardless scope
  IDENT_CURRENT('dbo.table_name') AS [IDENT_CURRENT];  -- regardless session, regardless scope


/*
  Calculates the FullYearsBetween, between the birth year and the event year, 
  minus 1 year in cases for which the year, the event month, and the day are smaller than the birth month and day. 
  The expression 100 * month + day is a trick to concatenate the month and day. 
  For example, for the twelfth (12) in the month of February (2), the expression yields the integer 212.
*/
DECLARE @birthdate AS datetime;
DECLARE @eventdate AS datetime;
SET @birthdate = '20100131'; -- 31/1/2010
SET @eventdate = '20110130'; -- 30/1/2011
select
  DATEDIFF(year, @birthdate, @eventdate)
  - CASE 
      WHEN (100 * MONTH(@eventdate) + DAY(@eventdate)) < (100 * MONTH(@birthdate) + DAY(@birthdate))
      THEN 1 
      ELSE 0
    END
  as FullYearsBetween
  

-- for getting server version
SELECT 
  SERVERPROPERTY('productversion'), 
  CHARINDEX('.', CAST(SERVERPROPERTY('productversion') as varchar)),
  left(CAST(SERVERPROPERTY('productversion') as varchar), CHARINDEX('.', CAST(SERVERPROPERTY('productversion') as varchar))-1)


-- gaps and islands
if OBJECT_ID('dbo.t1') is not null drop table t1;
create table t1 (col1 int not null, CONSTRAINT PK_t1 PRIMARY KEY CLUSTERED (col1));
insert into t1 (col1) values (2),(3),(11),(12),(13),(27),(33),(34),(35),(42);

with cte as (
  select
    col1,
    col1-ROW_NUMBER() OVER(order by col1) as col2 -- gap?
  from t1
)
select min(col1), max(col1) from cte group by col2 -- islands
 
