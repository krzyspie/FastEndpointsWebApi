using FastEndpoints;
using FastEndpointsWebApi.Cars.Entities;
using FastEndpointsWebApi.Database;
using Microsoft.EntityFrameworkCore;

namespace FastEndpointsWebApi.Cars.GetAll;

public class GetAllCarsEndpoint : EndpointWithoutRequest<GetAllCarsResponse>
{
    public GetAllCarsEndpoint(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }
    private readonly AppDbContext DbContext;
    public override void Configure()
    {
        Get("/cars");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        // Simulate some async work
        await Task.Delay(1000, ct);

        var cars = await DbContext.Cars.ToListAsync();
        GetAllCarsResponse carsResponse = new()
        {
            Cars = cars
        };

        await SendOkAsync(carsResponse, ct);
    }
}