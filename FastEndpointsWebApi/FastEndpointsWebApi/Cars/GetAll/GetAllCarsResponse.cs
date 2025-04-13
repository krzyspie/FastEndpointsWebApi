using System;

namespace FastEndpointsWebApi.Cars.GetAll;

public class GetAllCarsResponse
{
    public List<CarResponse> Cars { get; set; } = new List<CarResponse>();
}
