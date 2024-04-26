using CleanArchitecture.Domain.Entities;

namespace VerticalSlice.Application.Features.Queries.GetGamesForConsole;

public record GetGamesForConsoleResponse(IReadOnlyCollection<Game> Games);
