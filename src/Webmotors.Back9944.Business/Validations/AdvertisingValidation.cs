using FluentValidation;
using System;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Business.Validations
{
    public class AdvertisingValidation : AbstractValidator<Advertising>
    {
        public AdvertisingValidation()
        {
            RuleFor(a => a.Id)
                .ExclusiveBetween(0, int.MaxValue).WithMessage("A propriedade {PropertyName} é inválida!")
                .NotNull().WithMessage("A propriedade {PropertyName} não pode ser nula!");

            RuleFor(a => a.Marca)
                .MaximumLength(45).WithMessage("O campo {PropertyName} não pode ser maior do que 45 caracteres!")
                .NotEmpty().WithMessage("O valor informado para {PropertyName} é inválido!")
                .NotNull().WithMessage("O campo {PropertyName} não pode ser nulo!");

            RuleFor(a => a.Modelo)
                .MaximumLength(45).WithMessage("O campo {PropertyName} não pode ser maior do que 45 caracteres!")
                .NotEmpty().WithMessage("O valor informado para {PropertyName} é inválido!")
                .NotNull().WithMessage("O campo {PropertyName} não pode ser nulo!");

            RuleFor(a => a.Versao)
                .MaximumLength(45).WithMessage("O campo {PropertyName} não pode ser maior do que 45 caracteres!")
                .NotEmpty().WithMessage("O valor informado para {PropertyName} é inválido!")
                .NotNull().WithMessage("O campo {PropertyName} não pode ser nulo!");

            RuleFor(a => a.Ano)
                .ExclusiveBetween(1950, DateTime.Now.Year).WithMessage("A propriedade {PropertyName} é inválida!")
                .NotNull().WithMessage("O campo {PropertyName} não pode ser nulo!");

            RuleFor(a => a.Quilometragem)
                .ExclusiveBetween(0, int.MaxValue).WithMessage("A propriedade {PropertyName} é inválida!")
                .NotNull().WithMessage("O campo {PropertyName} não pode ser nulo!");

            RuleFor(a => a.Observacao)
                .NotEmpty().WithMessage("O valor informado para {PropertyName} é inválido!")
                .NotNull().WithMessage("O campo {PropertyName} não pode ser nulo!");
        }
    }
}
