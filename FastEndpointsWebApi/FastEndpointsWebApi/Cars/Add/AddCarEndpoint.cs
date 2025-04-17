using FastEndpoints;
using FastEndpointsWebApi.Cars.Entities;
using FastEndpointsWebApi.Cars.GetAll;
using FastEndpointsWebApi.Database;

namespace FastEndpointsWebApi.Cars.Add;

public class AddCarEndpoint : Endpoint<AddCarRequest, int>
{
    private readonly AppDbContext dbContext;

    public AddCarEndpoint(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public override void Configure()
    {
        Post("/cars/add");
        AllowAnonymous();
    }

    public override async Task HandleAsync(AddCarRequest req, CancellationToken ct)
    {
        var car = new Car
        {
            Make = req.Make,
            Model = req.Model,
            Year = req.Year
        };

        await dbContext.Cars.AddAsync(car, ct);
        await dbContext.SaveChangesAsync(ct);

        await SendCreatedAtAsync<GetAllCarsEndpoint>(new { id = car.Id }, car.Id, cancellation: ct);
    }
}
