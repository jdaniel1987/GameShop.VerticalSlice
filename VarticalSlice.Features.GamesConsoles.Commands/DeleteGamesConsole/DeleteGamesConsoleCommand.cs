using MediatR;
using Microsoft.AspNetCore.Http;

namespace VerticalSlice.Features.GamesConsoles.DeleteGamesConsole;

public record DeleteGamesConsoleCommand(int GamesConsoleId) : IRequest<IResult>;
