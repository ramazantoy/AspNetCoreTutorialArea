using FluentValidation;
using Project_6.Dtos.AdvertisementDtos;

namespace Project_6.Business.ValidationRules.FluentValidation
{
    public class AdvertisementCreateDtoValidator : AbstractValidator<AdvertisementCreateDto>
    {
        public AdvertisementCreateDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }
     
      
    }
}