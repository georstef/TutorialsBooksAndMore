CREATE TABLE CustomerProducts
([CustomerName] varchar(20), [ProductName] varchar(20), [Ammount] int)

INSERT INTO CustomerProducts
(CustomerName, ProductName, Ammount)
VALUES
('Customer1', 'Product1', 10),
('Customer1', 'Product1', 100),
('Customer2', 'Product2', 20),
('Customer2', 'Product2', 200),
('Customer1', 'Product2', 30),
('Customer1', 'Product2', 300),
('Customer2', 'Product1', 40),
('Customer2', 'Product1', 400);

-------------------------------------------------------------------------

DECLARE @products AS varchar(MAX)
declare @query  AS NVARCHAR(MAX)
set @products = STUFF((SELECT distinct ',' + ProductName
                       FROM CustomerProducts
                       FOR XML PATH('')
                      ), 1, 1, '')

set @query = 'select * from CustomerProducts
              pivot (sum(Ammount)                  -- data to pivot
                for ProductName in ('+@products+') -- column name
               ) as C'

execute(@query)