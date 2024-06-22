using FluentValidation;
using Project_6.Dtos.GenderDtos;

namespace Project_6.Business.ValidationRules.FluentValidation
{
    public class GenderUpdateDtoValidator : AbstractValidator<GenderUpdateDto>
    {
        public GenderUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}