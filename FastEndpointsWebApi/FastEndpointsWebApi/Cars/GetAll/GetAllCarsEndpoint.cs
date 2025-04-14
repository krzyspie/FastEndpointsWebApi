using FastEndpoints;
using FastEndpointsWebApi.Cars.Entities;

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

        GetAllCarsResponse carsResponse = new()
        {
            Cars = new List<Car>
            {
                new() { Id = 1, Make = "Toyota", Model = "Camry", Year = 2020 },
                new() { Id = 2, Make = "Honda", Model = "Civic", Year = 2019 },
                new() { Id = 3, Make = "Ford", Model = "Mustang", Year = 2021 }
            }
        };

        await SendOkAsync(carsResponse, ct);
    }
}