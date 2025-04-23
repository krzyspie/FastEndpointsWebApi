using System;

namespace FastEndpointsWebApi.Cars.Entities;

public class Car
{
    public int Id { get; set; }
    public CarMake Make { get; set; }
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Color { get; set; } = string.Empty;
    public EngineType EngineType { get; set; }
    public Transmission Transmission { get; set; }
    public int Horsepower { get; set; }
}
