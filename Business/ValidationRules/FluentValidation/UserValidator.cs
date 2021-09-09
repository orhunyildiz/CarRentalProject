using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().MaximumLength(30);
            RuleFor(u => u.LastName).NotEmpty().MaximumLength(30);
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
        }
    }
}
