using MediatR;
using Microsoft.AspNetCore.Http;

namespace VerticalSlice.Features.Games.Commands.UpdateGame;

public record UpdateGameCommand(
    int Id,
    string Name,
    string Publisher,
    int GamesConsoleId,
    double Price) : IRequest<IResult>;
