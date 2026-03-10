using FluentValidation;
using VehicleWebApi.Application.DTOs;

namespace VehicleWebApi.Application.Validators
{
    public class CreateMotorcycleValidator : AbstractValidator<CreateMotorcycleDto>
    {
        public CreateMotorcycleValidator()
        {
            RuleFor(x => x.Color)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.ModelVersionId)
                .GreaterThan(0);

            RuleFor(x => x.EngineDisplacement)
                .GreaterThan(0)
                .WithMessage("Engine displacement must be greater than zero.");

            RuleFor(x => x.HandlebarType)
                .IsInEnum()
                .WithMessage("Invalid handlebar type.");
        }
    }
}
