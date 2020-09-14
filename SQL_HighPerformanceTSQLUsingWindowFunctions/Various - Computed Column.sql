*** computed column ***
computed column:  is a virtual column that is not physically stored in the table, (unless the column is marked PERSISTED). 
                  A computed column expression can use data from other columns to calculate a value for the column to which it belongs

1. CANNOT be used as a DEFAULT or FOREIGN KEY constraint definition or with a NOT NULL constraint definition
2. CANNOT be the target of an INSERT or UPDATE statement.
3. if the computed column value is defined by a deterministic expression and the data type of the result is allowed in index columns, a computed column CAN be used as a key column in an index or as part of any PRIMARY KEY or UNIQUE constraint

ALTER TABLE [schema].[table] ADD [FieldName] AS ([FieldName1]*[FieldName2]*[]

examples:
ALTER TABLE Pelmast ADD PelatisOnoma AS (cast(Pelatis as varchar) + ' - ' + Onoma);

-- add the PERSISTED argument to physically store the computed values in the table
ALTER TABLE Pelmast ADD PelatisOnoma AS (cast(Pelatis as varchar) + ' - ' + Onoma) PERSISTED;

-- drop like any other column
ALTER TABLE Pelmast DROP COLUMN PelatisOnoma;
