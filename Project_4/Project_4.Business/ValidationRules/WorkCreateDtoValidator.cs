using FluentValidation;
using Project_4.Dtos.WorkDtos;

namespace Project_4.Business.ValidationRules
{
    public class WorkCreateDtoValidator : AbstractValidator<WorkCreateDto>
    {
        public WorkCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Definition is required");
            
            //When with can added
        }
    }
}