using MediatR;

namespace VerticalSlice.Application.Features.Queries.GetAllGames;

public record GetAllGamesQuery() : IRequest<GetAllGamesResponse>;
