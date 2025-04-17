namespace FastEndpointsWebApi.Cars.Add;

public class AddCarRequest
{
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
}