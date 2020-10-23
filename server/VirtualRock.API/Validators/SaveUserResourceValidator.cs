using FluentValidation;
using VirtualRock.API.Resources;

namespace VirtualRock.API.Validators
{
    public class SaveUserResourceValidator: AbstractValidator<SaveUserResource>
    {
        public SaveUserResourceValidator()
        {
            RuleFor(x => x.SlackId)
                .NotEmpty();
        }
    }
}
