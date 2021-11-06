*** sql server log ***
Write to sql server log:
  SQL SERVER 2000+ 
  EXEC master.dbo.xp_logevent 1234, @Message, @Severity;
  
  SQL SERVER 2005+
  EXEC xp_logevent 1234, @Message, @Severity; 
  
Read from sql server log:
Παλιά εντολή:
master.dbo.sp_readerrorlog
με παραμέτρους:
  1. To read a file other than the error log: non-zero parameter (1-99)
  2. Full filename path other than the error log: valid full path filename
  3. The line into the filename to read: line number (if line does not exists returns empty)
  4. Search string: returns the previous line only if it contains the search string 

  Note:
  If you do not pass any parameters this will return the contents of the current error log.
  eg. => exec master.dbo.sp_readerrorlog


Νέα εντολή:
sys.xp_readerrorlog
με παραμέτρους:
  1. Value of error log file you want to read: 0 = current, 1 = Archive #1, 2 = Archive #2, etc...
  2. Log file type: 1 or NULL = error log, 2 = SQL Agent log
  3. Search string 1: String one you want to search for
  4. Search string 2: String two you want to search for to further refine the results
  5. Search from start time
  6. Search to end time
  7. Sort order for results: N'asc' = ascending, N'desc' = descending

  eg. => exec master.dbo.xp_readerrorlog 0, 1, N'prat |', null, null, null, N'desc'

  Note:
  1. for later versions of SQL Server you may need to use double quotes or you might get this error (eg. "prat | ")
  2. or try this, putting N before each parameter (eg. N'prat | ')


Stored procedure for SQL SERVER logging 
/*
  simple SQL SERVER logging procedure,
  mostly for debugging other stored procedures
  
  @Author George S. (in memoriam Zaf Keramidas)
  @Version 31 Μαρ 2020 | 14:53, initial version

  usage:
  informational msg: exec StPr_WriteSQLServerLog 'rock out with your cock out'
  warning msg: exec StPr_WriteSQLServerLog 'rock out with your cock out', warning
  error msg: exec StPr_WriteSQLServerLog 'rock out with your cock out', error
  msg can be viewed with (sql server 2000): exec master.dbo.xp_readerrorlog 0, 1, N'prat |', null, null, null, N'desc'
  msg can be viewed with (sql server 2008+): exec sys.xp_readerrorlog 0, 1, N'prat |', null, null, null, N'desc'

*/
CREATE PROCEDURE StPr_WriteSQLServerLog
  @Message varchar(2000),
  @Severity varchar(15) = 'informational' 
AS
BEGIN
  set @Message = 'prat | ' + @Message; -- βάζουμε πρόθεμα για να μπορούμε να ξεχωρίσουμε τις εγγραφές που βάλαμε εμείς (από τις εγγραφές του SQL Server)
  -- EXEC xp_logevent 9999, @Message, @Severity; SQL SERVER 2005+
  EXEC master.dbo.xp_logevent 9999, @Message, @Severity; -- SQL SERVER 2000+
END
