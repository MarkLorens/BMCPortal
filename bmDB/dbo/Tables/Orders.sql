CREATE TABLE [dbo].[Orders]
(
	[order_ref] NVARCHAR(50) NOT NULL PRIMARY KEY, 
	[uraian] NVARCHAR(240) NOT NULL, 
	[tgl_masuk] DATE NOT NULL, 
	[tgl_selesai] DATE NOT NULL, 
	[dp] FLOAT NOT NULL, 
	[sisa] FLOAT NOT NULL, 
	[total] FLOAT NOT NULL, 
	[pj] NVARCHAR(50) NOT NULL
)
