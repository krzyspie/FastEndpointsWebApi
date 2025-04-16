namespace FastEndpointsWebApi.Cars.Search;

public class SearchCarsRequest
{
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int? FromYear { get; set; } = 0;
    public int? ToYear { get; set; } = 0;
}

