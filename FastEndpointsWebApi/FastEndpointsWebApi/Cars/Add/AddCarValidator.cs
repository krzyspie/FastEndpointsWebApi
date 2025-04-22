using FastEndpoints;
using FastEndpointsWebApi.Cars.Entities;
using FluentValidation;

namespace FastEndpointsWebApi.Cars.Add;

public class AddCarValidator : Validator<AddCarRequest>
{
    public AddCarValidator()
    {
        RuleFor(x => x.Make)
            .NotEmpty()
            .WithMessage("Make is required.");

        RuleFor(x => x.Model)
            .NotEmpty()
            .WithMessage("Model is required.");

        RuleFor(x => x.Year)
            .InclusiveBetween(1886, DateTime.Now.Year)
            .WithMessage($"Year must be between 1886 and {DateTime.Now.Year}.");
                
        RuleFor(x => x.EngineType)
            .NotEmpty()
            .WithMessage("EngineType is required.")
            .Must(x => Enum.TryParse(typeof(EngineType), x, out _))
            .WithMessage("Invalid EngineType value.");
        
        RuleFor(x => x.Transmission)
            .NotEmpty()
            .WithMessage("Transmission is required.")
            .Must(x => Enum.TryParse(typeof(Transmission), x, out _))
            .WithMessage("Invalid Transmission value.");
    }
}