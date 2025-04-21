using CA_InterfaceAdapters_Mappers.Dtos.Requests;
using FluentValidation;

namespace CL_FrameworksDrivers_API.Validators
{
    public class BeerValidator :AbstractValidator<BeerRequestDTO>
    {
        public BeerValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().WithMessage("La cerveza debe tener nombre");
            RuleFor(dto => dto.Style).NotEmpty().WithMessage("La cerveza debe tener un estilo");
            RuleFor(dto => dto.Alcohol).GreaterThan(0).WithMessage("La cerveza debe tener alcohol");
        }
    }
}
