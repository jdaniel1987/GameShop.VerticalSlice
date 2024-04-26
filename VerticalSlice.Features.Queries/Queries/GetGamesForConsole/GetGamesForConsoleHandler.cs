using MediatR;
using CleanArchitecture.Domain.Repositories;

namespace VerticalSlice.Application.Features.Queries.GetGamesForConsole;

public class GetGamesForConsoleHandler : IRequestHandler<GetGamesForConsoleQuery, GetGamesForConsoleResponse>
{
    private readonly IGameRepository _gameRepository;
    private readonly IGamesConsoleRepository _consoleRepository;

    public GetGamesForConsoleHandler(
        IGameRepository gameRepository,
        IGamesConsoleRepository consoleRepository)
    {
        _gameRepository = gameRepository;
        _consoleRepository = consoleRepository;
    }

    public async Task<GetGamesForConsoleResponse> Handle(GetGamesForConsoleQuery request, CancellationToken cancellationToken)
    {
        var console = await _consoleRepository.GetGamesConsole(request.GamesConsoleId);

        if (console is null)
        {
            throw new ArgumentException($"Console with ID {request.GamesConsoleId} does not exist");
        }

        var games = await _gameRepository.GetAllGamesForConsole(request.GamesConsoleId);

        return new GetGamesForConsoleResponse(games);
    }
}
