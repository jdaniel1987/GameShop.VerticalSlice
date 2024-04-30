using MediatR;
using Microsoft.AspNetCore.Http;

namespace VerticalSlice.Features.GamesConsoles.Commands.AddGamesConsole;

public record AddGamesConsoleCommand(
    string Name,
    string Manufacturer,
    double Price) : IRequest<IResult>;
