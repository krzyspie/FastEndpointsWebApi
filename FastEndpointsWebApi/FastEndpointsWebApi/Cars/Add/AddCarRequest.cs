namespace FastEndpointsWebApi.Cars.Add;

public class AddCarRequest
{
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Color { get; set; } = string.Empty;
    public string EngineType { get; set; } = string.Empty;
    public string Transmission { get; set; } = string.Empty;
    public int Horsepower { get; set; }
}