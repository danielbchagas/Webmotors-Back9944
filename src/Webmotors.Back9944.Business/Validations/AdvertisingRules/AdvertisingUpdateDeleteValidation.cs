using FluentValidation;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Business.Validations.AdvertisingRules
{
    public class AdvertisingUpdateDeleteValidation : AbstractValidator<Advertising>
    {
        public AdvertisingUpdateDeleteValidation()
        {
            RuleFor(a => a.Id)
                .ExclusiveBetween(0, int.MaxValue).WithMessage("A propriedade {PropertyName} é inválida!")
                .NotNull().WithMessage("A propriedade {PropertyName} não pode ser nula!");
        }
    }
}
