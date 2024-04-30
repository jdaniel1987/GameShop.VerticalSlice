using MediatR;
using Microsoft.AspNetCore.Http;

namespace VerticalSlice.Features.GamesConsoles.UpdateGamesConsole;

public record UpdateGamesConsoleCommand(
    int Id,
    string Name,
    string Manufacturer,
    double Price) : IRequest<IResult>;
