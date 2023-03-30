using System;
using FluentValidation;
using Permission.Services.Dtos;

namespace Permission.Services.Validators
{
    public class PermissionValidator : AbstractValidator<PermissionDto>
    {
        public PermissionValidator()
        {
            RuleFor(x => x.EmployeeFirstName)
                .NotEmpty()
                    .WithMessage("The name is required");

            RuleFor(x => x.EmployeeLastName)
               .NotEmpty()
                   .WithMessage("The lastname is required");

            RuleFor(x => x.PermissionTypeId)
               .NotEmpty()
                   .WithMessage("The Permission type is required");

            RuleFor(x => x.PermissionDate)
               .NotEmpty()
                   .WithMessage("The Permission date is required");

        }
    }
}