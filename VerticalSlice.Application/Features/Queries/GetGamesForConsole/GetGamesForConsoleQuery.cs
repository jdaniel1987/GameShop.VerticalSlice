using MediatR;

namespace VerticalSlice.Application.Features.Queries.GetGamesForConsole;

public record GetGamesForConsoleQuery(int GamesConsoleId) : IRequest<GetGamesForConsoleResponse>;
