namespace VerticalSlice.Application.Features.Queries.GetAllGamesConsoles;

public record GetAllGamesConsolesResponse(
    IReadOnlyCollection<GetAllGamesConsolesResponseItem> GamesConsoles);
