using FluentValidation;
using VillaApplication.Model.Bo;

namespace VillaApplication.Model.Validator
{
    public class VillaValidator : AbstractValidator<VillaBO>
    {
        public VillaValidator()
        {
            RuleFor(v => v.Id)
                .Empty();

            RuleFor(v => v.OwnerId)
                .NotEmpty();

            RuleFor(v => v.Name)
                .NotEmpty();
        }
    }
}
