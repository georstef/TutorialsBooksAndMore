/*
EXAMPLE
SubjectID       StudentName
----------      -------------
1               Mary
1               John
1               Sam
2               Alaina
2               Edward

Results expected:
SubjectID       StudentName
----------      -------------
1               Mary, John, Sam
2               Alaina, Edward               



NOTE: in the following queries the fields are a little bit mixed up
  SubjectID = apoMastBarcodeTemaxio
  StudentName = ApomastID
*/

-- -------------------------------------------------------------

-- taken from => http://stackoverflow.com/questions/21760969/multiple-rows-to-one-comma-separated-value
-- 1a. with STUFF and easy fieldnames (this is fast)
SELECT  ID
       ,STUFF((SELECT ', ' + CAST(Value AS VARCHAR(10)) [text()]
         FROM @Table1 
         WHERE ID = t.ID
         FOR XML PATH(''), TYPE)
        .value('.','NVARCHAR(MAX)'),1,2,' ') List_Output
FROM @Table1 t
GROUP BY ID

-- 1b. with STUFF and actually used tablenames and fieldnames (this is fast)
with t1 as (
SELECT  
  apoMastBarcodeTemaxio,
  STUFF((SELECT ', ' + CAST(apoMastID AS VARCHAR(50)) [text()]
         FROM apomast
         WHERE apoMastBarcodeTemaxio = t.apoMastBarcodeTemaxio
         FOR XML PATH(''), TYPE).value('.','NVARCHAR(MAX)'),1,2,' ') as Eidi
FROM apomast t
where apoMastBarcodeTemaxio <> '' -- this is only used to filter out null Barcodes
GROUP BY apoMastBarcodeTemaxio
)
select * from t1 where Eidi like '%,%' -- this is only used to filter multiple data from single ones

-- -------------------------------------------------------------

-- taken from => http://stackoverflow.com/questions/194852/concatenate-many-rows-into-a-single-text-string
-- 2. another way (this is slower)
Select apoMastBarcodeTemaxio,
       Left(Eidi,Len(Eidi)-1) As Eidi
From
    (
        Select distinct apoMastBarcodeTemaxio, 
            (
                Select CAST(apoMastID AS VARCHAR(50)) + ',' AS [text()]
                From apomast ST1
                Where ST1.apoMastBarcodeTemaxio = ST2.apoMastBarcodeTemaxio
                ORDER BY ST1.apoMastBarcodeTemaxio
                For XML PATH ('')
            ) as [Eidi]
        From dbo.apoMast ST2
    ) as T
    
    
 -- 3. the second way more compact (still slow)
 Select distinct ST2.apoMastBarcodeTemaxio, 
    substring(
        (
            Select ','+ST1.ApomastID  AS [text()]
            From Apomast as  ST1
            Where ST1.apoMastBarcodeTemaxio = ST2.apoMastBarcodeTemaxio
                and ST1.apoMastBarcodeTemaxio <> '' 
            ORDER BY ST1.apoMastBarcodeTemaxio
            For XML PATH ('')
        ), 2, 1000) as [Eidi]
From Apomast ST2


 -- 4. concatenation in SQL Server 2000 (http://stackoverflow.com/questions/8228832/sql-server-2000-xml-path-error/8229258#8229258)
declare @s varchar(8000);

select @s = ISNULL(@s, '') + ISNULL(field1, '') + ISNULL(field2, '')... + ','
from SomeTable
where ...
order by ...;

if len(@s) > 1 begin
  set @s = SUBSTRING(@s, 1, len(@s)-1) -- remove last comma (,)
end

select @s;
