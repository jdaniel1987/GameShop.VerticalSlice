namespace VerticalSlice.Application.Features.Queries.GetAllGamesConsoles;

public record GetAllGamesConsolesResponseItem(
    int Id,
    string Name,
    string Manufacturer,
    decimal Price);
