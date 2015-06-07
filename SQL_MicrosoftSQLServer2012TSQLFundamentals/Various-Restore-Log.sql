-- Take initial backups
BACKUP DATABASE [TSQL2012] TO DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER2012\MSSQL\Backup\TSQL2012.bak' WITH INIT;
GO
BACKUP LOG [TSQL2012] TO DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER2012\MSSQL\Backup\TSQL2012.trn' WITH INIT;
GO

-- stuff
delete from dbo.Orders;

SELECT
    [Current LSN],
    [Transaction ID],
    [Operation],
    [Context],
    [AllocUnitName]
FROM fn_dblog(NULL, NULL)
WHERE [Operation] = 'LOP_DELETE_ROWS'
    AND [AllocUnitName] = 'dbo.Orders'
    

    
SELECT
    [Current LSN],
    [Operation],
    [Transaction ID],
    [Begin Time],
    [Transaction Name],
    [Transaction SID]
FROM fn_dblog(NULL, NULL)
WHERE [Transaction ID] = '0000:00001679'
    AND [Operation] = 'LOP_BEGIN_XACT'    


-- 0000006f:00000024:0001

BACKUP LOG [TSQL2012] TO DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER2012\MSSQL\Backup\TSQL2012_1.trn' WITH INIT;
GO


RESTORE DATABASE TSQL2012_COPY
    FROM DISK = 'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER2012\MSSQL\Backup\TSQL2012.bak'
WITH
    MOVE 'TSQL2012' TO 'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER2012\MSSQL\DATA\TSQL2012_COPY.mdf',
    MOVE 'TSQL2012_log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER2012\MSSQL\DATA\TSQL2012_COPY.ldf',
    NORECOVERY;

RESTORE LOG TSQL2012_COPY
FROM
    DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER2012\MSSQL\Backup\TSQL2012.trn'
WITH
	NORECOVERY;

RESTORE LOG TSQL2012_COPY
FROM
    DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER2012\MSSQL\Backup\TSQL2012_1.trn'
WITH
    STOPBEFOREMARK = 'lsn:0x0000006f:00000024:0001',
	NORECOVERY;

RESTORE DATABASE [TSQL2012_COPY] WITH RECOVERY;
GO

