using FluentValidation;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Business.Validations.AdvertisingRules
{
    public class AdvertisingCreateValidation : AbstractValidator<Advertising>
    {
        public AdvertisingCreateValidation()
        {
            RuleFor(a => a.Id)
                .ExclusiveBetween(-1, 1).WithMessage("A propriedade {PropertyName} é inválida!")
                .NotNull().WithMessage("A propriedade {PropertyName} não pode ser nula!");
        }
    }
}
