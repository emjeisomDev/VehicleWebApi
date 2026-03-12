using FluentValidation;
using VehicleWebApi.Application.DTOs.CreatesDTOs;

namespace VehicleWebApi.Application.Validators
{
    public class CreateTruckValidator : AbstractValidator<CreateTruckDto>
    {
        public CreateTruckValidator()
        {
            RuleFor(x => x.Color)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.ModelVersionId)
                .GreaterThan(0);

            RuleFor(x => x.LoadCapacityInTons)
                .GreaterThan(0)
                .WithMessage("Load capacity must be greater than zero.");

            RuleFor(x => x.AxlesQuantity)
                .GreaterThan(0)
                .When(x => x.AxlesQuantity.HasValue)
                .WithMessage("Axles quantity must be greater than zero.");
        }
    }
}
