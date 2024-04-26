using MediatR;
using CleanArchitecture.Domain.Repositories;

namespace VerticalSlice.Application.Features.Queries.GetGamesByName;

public class GetGamesByNameHandler : IRequestHandler<GetGamesByNameQuery, GetGamesByNameResponse>
{
    private readonly IGameRepository _gameRepository;

    public GetGamesByNameHandler(
        IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<GetGamesByNameResponse> Handle(GetGamesByNameQuery request, CancellationToken cancellationToken)
    {
        var games = await _gameRepository.GetGamesByName(request.GameName);

        return new GetGamesByNameResponse(games);
    }
}
