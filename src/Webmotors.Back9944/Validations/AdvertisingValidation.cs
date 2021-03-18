using FluentValidation;
using Webmotors.Back9944.Models;

namespace Webmotors.Back9944.Validations
{
    public class AdvertisingValidation : AbstractValidator<Advertising>
    {
        public AdvertisingValidation()
        {
            RuleFor(a => a.Marca)
                .MaximumLength(45)
                .WithMessage("O campo {PropertyName} não pode ser maior do que 45 caracteres!")
                .NotEmpty()
                .WithMessage("O valor informado para {PropertyName} é inválido!")
                .NotNull()
                .WithMessage("O campo {PropertyName} não pode ser nulo!");

            RuleFor(a => a.Modelo)
                .MaximumLength(45)
                .WithMessage("O campo {PropertyName} não pode ser maior do que 45 caracteres!")
                .NotEmpty()
                .WithMessage("O valor informado para {PropertyName} é inválido!")
                .NotNull()
                .WithMessage("O campo {PropertyName} não pode ser nulo!");

            RuleFor(a => a.Versao)
                .MaximumLength(45)
                .WithMessage("O campo {PropertyName} não pode ser maior do que 45 caracteres!")
                .NotEmpty()
                .WithMessage("O valor informado para {PropertyName} é inválido!")
                .NotNull()
                .WithMessage("O campo {PropertyName} não pode ser nulo!");

            RuleFor(a => a.Ano)
                .NotNull()
                .WithMessage("O campo {PropertyName} não pode ser nulo!");

            RuleFor(a => a.Quilometragem)
                .NotNull()
                .WithMessage("O campo {PropertyName} não pode ser nulo!");

            RuleFor(a => a.Observacao)
                .NotEmpty()
                .WithMessage("O valor informado para {PropertyName} é inválido!")
                .NotNull()
                .WithMessage("O campo {PropertyName} não pode ser nulo!");
        }
    }
}
