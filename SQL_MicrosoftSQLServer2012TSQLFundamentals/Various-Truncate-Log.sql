USE [DatabaseName]
BACKUP LOG [DatabaseName] WITH TRUNCATE_ONLY

DECLARE @InternalLogName VARCHAR(64)
SELECT TOP 1 @InternalLogName = RTRIM(LTRIM(name)) FROM sysfiles WHERE groupid = 0
DBCC SHRINKFILE (@InternalLogName)

