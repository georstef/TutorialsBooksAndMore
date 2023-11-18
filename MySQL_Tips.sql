-- ΠΑΡΑΔΕΙΓΜΑ ΑΝΤΙΓΡΑΦΗΣ ΠΙΝΑΚΑ ΑΠΟ ΜΙΑ ΒΑΣΗ ΣΕ ΑΛΛΗ, ΜΑΖΙ ΜΕ ΤΑ FOREIGN KEYS

CREATE TABLE &MACRO_TABLE LIKE &MACRO_SOURCE_DB.&MACRO_TABLE;
-- Retrieve foreign key statements for the source table
SET @fk_statements = (
    SELECT CONCAT('ALTER TABLE ',&MACRO_TABLE_QUOTED,' ADD CONSTRAINT ', 
                  GROUP_CONCAT(CONCAT(CONSTRAINT_NAME, ' FOREIGN KEY (', COLUMN_NAME, ') REFERENCES ', REFERENCED_TABLE_NAME, '(', REFERENCED_COLUMN_NAME, ')') SEPARATOR ', ADD CONSTRAINT '))
    FROM information_schema.KEY_COLUMN_USAGE
    WHERE TABLE_SCHEMA = &MACRO_SOURCE_DB_QUOTED
      AND TABLE_NAME = &MACRO_TABLE_QUOTED
      AND REFERENCED_TABLE_NAME IS NOT NULL
);
-- MAKE SURE IT DOES NOT CRASHES IF THERE ARE NOT ANY FOREIGN KEYS
SET @fk_statements = (select case when @fk_statements is null then 'select 0' else @fk_statements end);
-- Execute foreign key statements on the target table
PREPARE fk_stmt FROM @fk_statements;
EXECUTE fk_stmt;
DEALLOCATE PREPARE fk_stmt;

/*
Question:
so can you tell me what does the  CREATE TABLE ... LIKE statement actually create? please double check your response.

ChatGPT Answer:

The CREATE TABLE ... LIKE statement creates a new table with a structure that mirrors the structure of an existing table (the source table). 

Here's a summary of what is and isn't created:

What is created:

Table Structure:
- Column names.
- Data types.
- Nullability (whether a column allows NULL values).
- Default values.
- Any column attributes, such as AUTO_INCREMENT.
- Indexes:
- Primary key.
- Unique keys.
- Non-unique keys.

What is not created:

Data:
The actual data in the source table is not copied to the new table.

Triggers:
Triggers associated with the source table are not copied to the new table.

Foreign Keys:
Foreign keys and their relationships with other tables are not copied.

Partitioning:
If the source table is partitioned, the new table won't inherit the partitioning scheme.

Stored Procedures and Functions:
Any stored procedures or functions associated with the source table are not copied.

Views:
Views that reference the source table are not automatically recreated.

Comments and Table Options:
Comments associated with the source table and table options (e.g., storage engine, character set) are not copied.

Auto-increment Attributes:
While the column structure is copied, the auto-increment status may need to be explicitly set if desired.

It's important to note that the CREATE TABLE ... LIKE statement is primarily focused on replicating the structure and indexes of the source table, 
and additional steps or statements may be needed to handle data, foreign keys, and other elements not covered by the basic structure.
*/
