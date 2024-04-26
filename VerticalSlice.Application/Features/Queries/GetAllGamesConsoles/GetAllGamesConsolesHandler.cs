using MediatR;
using CleanArchitecture.Domain.Repositories;

namespace VerticalSlice.Application.Features.Queries.GetAllGamesConsoles;

public class GetAllGamesConsolesHandler : IRequestHandler<GetAllGamesConsolesQuery, GetAllGamesConsolesResponse>
{
    private readonly IGamesConsoleRepository _gamesConsoleRepository;

    public GetAllGamesConsolesHandler(
        IGamesConsoleRepository gamesConsoleRepository)
    {
        _gamesConsoleRepository = gamesConsoleRepository;
    }

    public async Task<GetAllGamesConsolesResponse> Handle(GetAllGamesConsolesQuery request, CancellationToken cancellationToken)
    {
        var gamesConsoles = await _gamesConsoleRepository.GetAllGamesConsoles();

        return new GetAllGamesConsolesResponse(gamesConsoles);
    }
}
