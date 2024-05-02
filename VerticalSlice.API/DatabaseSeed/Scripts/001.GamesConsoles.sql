CREATE TABLE [dbo].[GamesConsoles] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (MAX)   NOT NULL,
    [Manufacturer] VARCHAR (MAX)   NOT NULL,
    [Price]        NUMERIC (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

