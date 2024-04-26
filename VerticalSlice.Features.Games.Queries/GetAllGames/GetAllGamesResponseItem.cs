namespace VerticalSlice.Features.Games.Queries.GetAllGames;

public record GetAllGamesResponseItem(
    int Id,
    string Name,
    string Publisher,
    decimal Price,
    int GamesConsoleId,
    string GamesConsoleName);
