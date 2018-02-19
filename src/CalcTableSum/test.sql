use testdb

-- Create a new table called 'Numbers' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Numbers', 'U') IS NOT NULL
DROP TABLE dbo.Numbers
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Numbers
(
  Name [NVARCHAR](50) NOT NULL,
  Value int NOT NULL
  -- specify more columns here
);
GO

                insert into numbers values ('c', 2)
                insert into numbers values ('d', 3)
                update numbers set value=4 where name='d'

