using System;
using System.Linq;
using System.Xml.Linq;
using FluentValidation;
using Project_6.UI.Models;

namespace Project_6.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        // [Obsolete("Obsolete")]
        public UserCreateModelValidator()
        {
            // CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Password).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Passwords not match.");
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            
            RuleFor(x => x.FirstName).Must(CannotContainsNumber).WithMessage("FirstName not contains number.").When(x=>x.FirstName!=null);
            RuleFor(x => x.LastName).Must(CannotContainsNumber).WithMessage("LastName not contains number.").When(x=>x.LastName!=null);
            RuleFor(x => new
            {
                x.FirstName,
                x.UserName,
            }).NotNull().Must(x=>Contains(x.FirstName,x.UserName)).WithMessage("UserName contains to FirstName").When(x=>x.UserName!=null && x.FirstName!=null);

            RuleFor(x => x.GenderId).NotEmpty();
       
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