using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpointsWebApi.Cars.Entities;
using FastEndpointsWebApi.Database;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints(o =>
{
    o.DisableAutoDiscovery = true;
    o.Assemblies = [typeof(Program).Assembly];
})
.SwaggerDocument();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.UseFastEndpoints().UseSwaggerGen();

app.UseHttpsRedirection();

SeedDatabase(app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>());

app.Run();

void SeedDatabase(AppDbContext appDbContext)
{
    appDbContext.Database.EnsureCreated();
    appDbContext.Cars.AddRange(new List<Car>
    {
        new() { Id = 1, Make = "Toyota", Model = "Camry", Year = 2020 },
        new() { Id = 2, Make = "Honda", Model = "Civic", Year = 2019 },
        new() { Id = 3, Make = "Ford", Model = "Mustang", Year = 2021 }
    });
    appDbContext.SaveChanges();
}