﻿namespace VerticalSlice.Features.GamesConsoles.Queries.GetGamesForConsole;

public record GetGamesForConsoleResponse(IReadOnlyCollection<GetGamesForConsoleResponseItem> Games);
