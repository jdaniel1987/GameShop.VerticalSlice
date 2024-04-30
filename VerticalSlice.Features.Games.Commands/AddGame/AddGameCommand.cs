using MediatR;
using Microsoft.AspNetCore.Http;

namespace VerticalSlice.Features.Games.Commands.AddGame;

public record AddGameCommand(
    string Name,
    string Publisher,
    int GamesConsoleId,
    double Price) : IRequest<IResult>;
