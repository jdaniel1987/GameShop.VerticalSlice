using MediatR;

namespace VerticalSlice.Features.GamesConsoles.Queries.GetGamesForConsole;

public record GetGamesForConsoleQuery(int GamesConsoleId) : IRequest<GetGamesForConsoleResponse>;
