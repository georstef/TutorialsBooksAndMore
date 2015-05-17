 -- first day of the month
select DATEADD(month, DATEDIFF(month, '19990101', current_timestamp), '19990101');

-- last day of the month
select DATEADD(month, DATEDIFF(month, '19991231', current_timestamp), '19991231');

-- get last identity value
SELECT
  SCOPE_IDENTITY() AS [SCOPE_IDENTITY],        -- current session, current scope
  @@identity AS [@@identity],                  -- current session, regardless scope
  IDENT_CURRENT('dbo.table_name') AS [IDENT_CURRENT];  -- regardless session, regardless scope
