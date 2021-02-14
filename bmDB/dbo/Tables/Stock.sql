CREATE TABLE [dbo].[Stock]
(
	[id] INT NOT NULL PRIMARY KEY, 
	[item] NVARCHAR(200) NOT NULL, 
	[stock] INT NOT NULL, 
	[amt_modified] INT NULL, 
	[last_modified] DATETIME NOT NULL, 
	[modified_by] NVARCHAR(200) NOT NULL, 
	[brand] NVARCHAR(200) NOT NULL
)
