using FastEndpoints;

namespace FastEndpointsWebApi.Cars.GetAll;

public class GetAllCarsEndpoint : EndpointWithoutRequest<GetAllCarsResponse>
{
    public override void Configure()
    {
        Get("/cars");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        // Simulate some async work
        await Task.Delay(1000, ct);

        Response.Cars = new List<CarResponse>
        {
            new CarResponse { Id = 1, Make = "Toyota", Model = "Camry", Year = 2020 },
            new CarResponse { Id = 2, Make = "Honda", Model = "Civic", Year = 2019 },
            new CarResponse { Id = 3, Make = "Ford", Model = "Mustang", Year = 2021 }
        };

        await SendAsync(Response, cancellation: ct);
    }
}

public class CarResponse
{
    public int Id { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Color { get; set; } = string.Empty;
    public string EngineType { get; set; } = string.Empty;
    public string Transmission { get; set; } = string.Empty;
    public int Horsepower { get; set; }
}