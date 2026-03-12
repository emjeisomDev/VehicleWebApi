using FluentValidation;
using VehicleWebApi.Application.DTOs.CreatesDTOs;

namespace VehicleWebApi.Application.Validators
{
    public class CreateCarValidator : AbstractValidator<CreateCarDto>
    {
        public CreateCarValidator()
        {
            RuleFor(x => x.Color)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.DoorsQuantity)
                .GreaterThan(0);

            RuleFor(x => x.ModelVersionId)
                .GreaterThan(0);
        }
    }
}
