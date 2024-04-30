using MediatR;
using Microsoft.AspNetCore.Http;

namespace VerticalSlice.Features.Games.Commands.DeleteGame;

public record DeleteGameCommand(int GameId) : IRequest<IResult>;
