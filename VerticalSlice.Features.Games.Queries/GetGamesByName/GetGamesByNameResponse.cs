namespace VerticalSlice.Features.GamesConsoles.Queries.GetGamesByName;

public record GetGamesByNameResponse(IReadOnlyCollection<GetGamesByNameResponseItem> Games);
