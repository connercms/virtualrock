using System;
using FluentValidation;
using VirtualRock.API.Resources;

namespace VirtualRock.API.Validators
{
    public class SaveNominationResourceValidator: AbstractValidator<SaveNominationResource>
    {
        public SaveNominationResourceValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
