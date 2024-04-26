namespace VerticalSlice.Features.GamesConsoles.Queries.GetGamesByName;

public record GetGamesByNameResponseItem(
    int Id,
    string Name,
    string Publisher,
    decimal Price,
    int GamesConsoleId,
    string GamesConsoleName);
