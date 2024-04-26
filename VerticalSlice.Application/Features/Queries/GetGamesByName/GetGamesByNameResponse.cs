using CleanArchitecture.Domain.Entities.Aggregates;

namespace VerticalSlice.Application.Features.Queries.GetGamesByName;

public record GetGamesByNameResponse(IReadOnlyCollection<GameWithConsole> Games);
