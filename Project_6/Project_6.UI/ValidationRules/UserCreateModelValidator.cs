using System.Linq;
using FluentValidation;
using Project_6.UI.Models;

namespace Project_6.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidator()
        {
            RuleFor(x => x.Password).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Passwords not match.");
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.FirstName).Must(CannotContainsNumber).WithMessage("FirstName not contains number.");
            RuleFor(x => x.LastName).Must(CannotContainsNumber).WithMessage("LastName not contains number.");
            RuleFor(x => new
            {
                x.FirstName,
                x.UserName,
            }).Must(x=>Contains(x.FirstName,x.UserName)).WithMessage("UserName contains to FirstName");

            RuleFor(x => x.GenderId).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }

        private bool Contains(string firstName,string userName)
        {
            return !firstName.Contains(userName);
        }

        private bool CannotContainsNumber(string arg)
        {
            return arg.All(c => !char.IsDigit(c));
        }
    }
}