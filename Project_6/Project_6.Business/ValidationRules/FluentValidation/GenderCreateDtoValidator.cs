using FluentValidation;
using Project_6.Dtos.GenderDtos;

namespace Project_6.Business.ValidationRules.FluentValidation
{
    public class GenderCreateDtoValidator : AbstractValidator<GenderCreateDto>
    {
        public GenderCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotNull();
        }
    }
}