using CleanArchitecture.Domain.Entities;

namespace VerticalSlice.Application.Features.Queries.GetAllGamesConsoles;

public record GetAllGamesConsolesResponse(IReadOnlyCollection<GamesConsole> GamesConsoles);
