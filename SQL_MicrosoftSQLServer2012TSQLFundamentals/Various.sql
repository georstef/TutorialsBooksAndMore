 -- first day of the month
select DATEADD(month, DATEDIFF(month, '19990101', current_timestamp), '19990101');

-- last day of the month
select DATEADD(month, DATEDIFF(month, '19991231', current_timestamp), '19991231');
