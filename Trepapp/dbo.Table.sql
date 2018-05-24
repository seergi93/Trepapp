CREATE TABLE [dbo].[Table]
(
	[Id] INT  PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [nomILlinages] NCHAR(50) NOT NULL, 
    [nick] NCHAR(10) NOT NULL, 
    [dataNeixament] DATETIME NOT NULL, 
    [contrasenya] NCHAR(20) NOT NULL
)
