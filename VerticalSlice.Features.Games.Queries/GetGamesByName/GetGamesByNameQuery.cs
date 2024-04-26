using MediatR;

namespace VerticalSlice.Features.GamesConsoles.Queries.GetGamesByName;

public record GetGamesByNameQuery(string GameName) : IRequest<GetGamesByNameResponse>;
