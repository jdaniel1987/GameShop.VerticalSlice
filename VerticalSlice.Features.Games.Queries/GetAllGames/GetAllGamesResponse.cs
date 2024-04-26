namespace VerticalSlice.Features.Games.Queries.GetAllGames;

public record GetAllGamesResponse(IReadOnlyCollection<GetAllGamesResponseItem> GamesWithConsole);
