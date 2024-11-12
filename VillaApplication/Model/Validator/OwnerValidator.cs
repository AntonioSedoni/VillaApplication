using FluentValidation;
using VillaApplication.Model.Bo;

namespace VillaApplication.Model.Validator
{
    public class OwnerValidator : AbstractValidator<OwnerBO>
    {
        public OwnerValidator() {

            RuleFor(o => o.Id)
                .Empty();

            RuleFor(o => o.FirstName)
                .NotEmpty();
            
            RuleFor(o => o.LastName)
                .NotEmpty();
        }
    }
}
