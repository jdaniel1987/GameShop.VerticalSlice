CREATE TABLE [dbo].[Games] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (MAX)   NOT NULL,
    [Publisher]      VARCHAR (MAX)   NOT NULL,
    [Price]          DECIMAL (18, 2) NOT NULL,
    [GamesConsoleId] INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Games_ToGamesConsole] FOREIGN KEY ([GamesConsoleId]) REFERENCES [dbo].[GamesConsoles] ([Id])
);

