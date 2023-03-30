using System;
using FluentValidation;
using Permission.Services.Dtos;

namespace Permission.Services.Validators
{
    public class PermissionTypeValidator : AbstractValidator<PermissionTypeDto>
    {
        public PermissionTypeValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                    .WithMessage("Description is required");
        }
    }
}

