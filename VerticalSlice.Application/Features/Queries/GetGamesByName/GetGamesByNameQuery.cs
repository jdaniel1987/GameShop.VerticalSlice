using MediatR;

namespace VerticalSlice.Application.Features.Queries.GetGamesByName;

public record GetGamesByNameQuery(string GameName) : IRequest<GetGamesByNameResponse>;
