using MediatR;

namespace VerticalSlice.Application.Features.Queries.GetAllGamesConsoles;

public record GetAllGamesConsolesQuery() : IRequest<GetAllGamesConsolesResponse>;
