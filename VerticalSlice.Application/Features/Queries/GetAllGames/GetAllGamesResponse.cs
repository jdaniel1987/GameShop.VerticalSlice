namespace VerticalSlice.Application.Features.Queries.GetAllGames;

public record GetAllGamesResponse(IReadOnlyCollection<GameWithConsole> GamesWithConsole);

pri