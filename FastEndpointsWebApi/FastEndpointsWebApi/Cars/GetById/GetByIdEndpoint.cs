using FastEndpoints;
using FastEndpointsWebApi.Database;

namespace FastEndpointsWebApi.Cars.GetById;

public class GetByIdEndpoint : Endpoint<int, GetByIdResponse>
{
    private readonly AppDbContext dbContext;

    public GetByIdEndpoint(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }


    public override void Configure()
    {
        Get("/cars/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(int id, CancellationToken ct)
    {
        var car = await dbContext.Cars.FindAsync(new object[] { id }, ct);
        if (car == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        var response = new GetByIdResponse
        {
            Id = car.Id,
            Make = car.Make,
            Model = car.Model,
            Year = car.Year
        };

        await SendOkAsync(response, ct);
    }

}
