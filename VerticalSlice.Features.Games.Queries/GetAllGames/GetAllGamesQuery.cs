using MediatR;

namespace VerticalSlice.Features.Games.Queries.GetAllGames;

public record GetAllGamesQuery() : IRequest<GetAllGamesResponse>;
