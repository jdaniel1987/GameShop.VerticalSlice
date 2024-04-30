using MediatR;
using Microsoft.AspNetCore.Http;

namespace VerticalSlice.Features.GamesConsoles.Commands.UpdateGamesConsole;

public record UpdateGamesConsoleCommand(
    int Id,
    string Name,
    string Manufacturer,
    double Price) : IRequest<IResult>;
