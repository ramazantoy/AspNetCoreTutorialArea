using FluentValidation;
using Project_4.Dtos.WorkDtos;

namespace Project_4.Business.ValidationRules
{
    public class WorkUpdateDtoValidator : AbstractValidator<WorkUpdateDto>
    {
        public WorkUpdateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty(); 
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}