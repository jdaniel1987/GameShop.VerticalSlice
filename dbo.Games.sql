﻿CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(MAX) NOT NULL, 
    [Publisher] NCHAR(10) NOT NULL, 
    [Price] DECIMAL(18, 2) NOT NULL
)