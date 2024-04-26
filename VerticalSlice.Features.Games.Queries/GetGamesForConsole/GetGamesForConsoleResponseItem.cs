namespace VerticalSlice.Features.GamesConsoles.Queries.GetGamesForConsole;

public record GetGamesForConsoleResponseItem(
    int Id,
    string Name,
    string Publisher,
    decimal Price);
