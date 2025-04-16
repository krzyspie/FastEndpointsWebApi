using FastEndpointsWebApi.Cars.Entities;

namespace FastEndpointsWebApi.Cars.Search;

public class SearchCarsResponse
{
    public List<Car> Cars { get; set; } = new List<Car>();
}

