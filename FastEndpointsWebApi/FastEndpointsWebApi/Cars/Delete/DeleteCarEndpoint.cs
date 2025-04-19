using FastEndpoints;
using FastEndpointsWebApi.Database;

namespace FastEndpointsWebApi.Cars.Delete;

public class DeleteCarEndpoint : Endpoint<int, bool>
{
    private readonly AppDbContext dbContext;

    public DeleteCarEndpoint(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public override void Configure()
    {
        Delete("/cars/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(int id, CancellationToken ct)
    {
        var car = await dbContext.Cars.FindAsync([id], ct);
        if (car == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        dbContext.Cars.Remove(car);
        await dbContext.SaveChangesAsync(ct);

        await SendNoContentAsync(ct);
    }
}