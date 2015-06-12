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
  
