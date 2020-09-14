*** Synonym ***
Synonym: is an alias or alternative name for a database object (table, view, stored procedure, user-defined function, and sequence)

CREATE SYNONYM [schema_name_1].[synonym_name] FOR [object];

The object is in the following form:
[server_name].[database_name].[schema_name_2].[object_name]

example:
CREATE SYNONYM fakeApomast FOR BLEU.Vita.dbo.Apomast;
