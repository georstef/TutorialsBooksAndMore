-- ----------------------------------
-- function to DATEADD only weekdays (and not weekends)
-- ----------------------------------
CREATE FUNCTION [dbo].[DateAddWeekdays] 
(
   @FromDate datetime,
   @DaysToAdd int
)
RETURNS datetime
AS
BEGIN
   DECLARE @Result datetime

   SET @Result = DATEADD(day, (@DaysToAdd % 5) + CASE ((@@DATEFIRST + DATEPART(weekday, @FromDate) + (@DaysToAdd % 5)) % 7)
                                                 WHEN 0 THEN 2
                                                 WHEN 1 THEN 1
                                                 ELSE 0 END, DATEADD(week, (@DaysToAdd / 5), @FromDate))

   RETURN @Result
END


/*
  Takes an e-Invoicing filename and returns the datetimeoffset that it has 
  (or it calculates the offset for a given TimeZone)

   e.g.
  'Voxel_20241130_1000_0100_E123654789_KP553.xml'  =>  2024-11-30 10:00 +01:00
   SELECT sd_einvoicing.GetDateTimeOffsetFromFilename('Voxel_20241216_120845_0100_216110845001.xml');
*/
CREATE FUNCTION sd_einvoicing.GetDateTimeOffsetFromFilename
(
  @filename NVARCHAR(MAX)
)
RETURNS DATETIMEOFFSET(0)
AS
BEGIN
  DECLARE @datePart NVARCHAR(10);
  DECLARE @timePart NVARCHAR(5);
  DECLARE @offsetPart NVARCHAR(6);
  DECLARE @Time_Zone NVARCHAR(500);
  DECLARE @result DATETIMEOFFSET(0);

  -- Extract the date part (YYYYMMDD)
  SET @datePart = SUBSTRING(@filename, CHARINDEX('_', @filename) + 1, 8);
  SET @datePart = STUFF(STUFF(@datePart, 5, 0, '-'), 8, 0, '-');

  -- Extract the time part (HHMM)
  SET @timePart = SUBSTRING(@filename, CHARINDEX('_', @filename, CHARINDEX('_', @filename) + 1) + 1, 4);
  SET @timePart = STUFF(@timePart, 3, 0, ':');

  -- if offset needs fixing then Fix_Offset=1 and Time_Zone<>null
  set @Time_Zone = (select Time_Zone from sd_einvoicing.Company where ID = sd_einvoicing.GetCompanyIDFromFilename(@filename) and Fix_Offset = 1);
  if (@Time_Zone is null) or (@Time_Zone = '')
  begin
    -- OFFSET DOES NOT NEED FIXING
    -- Extract the offset part (+HHMM or -HHMM) from the filename
    SET @offsetPart = SUBSTRING(@filename, CHARINDEX('_', @filename, CHARINDEX('_', @filename, CHARINDEX('_', @filename) + 1) + 1) + 1, 5);

-- Check if the offset sign is negative (explicitly includes '-')
    SET @offsetPart = REPLACE(@offsetPart, '_', '');
    IF LEN(@offsetPart) = 4 BEGIN
      SET @offsetPart = '+' + @offsetPart;
    END
    SET @offsetPart = STUFF(@offsetPart, 4, 0, ':');
  end
  else begin
    -- OFFSET NEEDS FIXING
    -- Calculate the offset based on the @Time_Zone field
	 -- 1. find the offset AT TIME ZONE given the date and time from the filename
	 -- 2. get the DATENAME of the calculated timestamp
    SET @offsetPart = DATENAME(TZOFFSET, CONVERT(DATETIME, CONCAT_WS(' ', @datePart, @timePart)) AT TIME ZONE @Time_Zone);
  end

  -- Construct the datetimeoffset string
  SET @result = CONVERT(DATETIMEOFFSET(0),
                  CONCAT_WS(' ', @datePart, @timePart, @offsetPart)
                );

  RETURN @result;
END;
GO
