using FluentValidation;
using System.Linq;
using Webmotors.Back9944.Business.Models;
using Webmotors.Back9944.Business.Validations;
using Xunit;

namespace Webmotors.Back9944.App.Tests
{
    public class Business_AdvertisingValidation
    {
        private readonly AdvertisingValidation _validation;

        public Business_AdvertisingValidation()
        {
            _validation = new AdvertisingValidation();
        }

        [Fact]
        public void Create_ThrowValidationException()
        {
            // Arrange
            var advertising = new Advertising
            {
                Id = -1,
                Marca = null,
                Modelo = null,
                Observacao = null,
                Versao = null,
                Ano = 1949
            };

            // Assert
            var exception = Assert.Throws<ValidationException>(() => 
            {
                // Act
                _validation.ValidateAndThrow(advertising);
            });

            Assert.True(exception.Errors.Where(_ => _.ErrorMessage.Contains("Id")).Count() > 0);
            Assert.True(exception.Errors.Where(_ => _.ErrorMessage.Contains("Marca")).Count() > 0);
            Assert.True(exception.Errors.Where(_ => _.ErrorMessage.Contains("Modelo")).Count() > 0);
            Assert.True(exception.Errors.Where(_ => _.ErrorMessage.Contains("Observacao")).Count() > 0);
            Assert.True(exception.Errors.Where(_ => _.ErrorMessage.Contains("Versao")).Count() > 0);
            Assert.True(exception.Errors.Where(_ => _.ErrorMessage.Contains("Ano")).Count() > 0);
        }
    }
}
