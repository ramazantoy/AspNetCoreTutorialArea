using FluentValidation;
using Project_4.Dtos.WorkDtos;

namespace Project_4.Business.ValidationRules
{
    public class WorkUpdateDtoValidator : AbstractValidator<WorkUpdateDto>
    {
        public WorkUpdateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Definition must be not empty");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id must be not empty");
        }
    }
}