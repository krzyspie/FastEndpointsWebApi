using FastEndpoints;
using FastEndpointsWebApi.Database;
using Microsoft.EntityFrameworkCore;

namespace FastEndpointsWebApi.Cars.Search;

public class SearchCarsEndpoint :Endpoint<SearchCarsRequest, SearchCarsResponse>
{
    private readonly AppDbContext dbContext;

    public SearchCarsEndpoint(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public override void Configure()
    {
        Get("/cars/search");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SearchCarsRequest req, CancellationToken ct)
    {
        var cars = await dbContext.Cars.ToListAsync();

        var filteredCars = cars.Where(c => c.Make.Contains(req.Make, StringComparison.OrdinalIgnoreCase)).ToList();

        await SendOkAsync(new SearchCarsResponse { Cars = filteredCars }, ct);
    }
}