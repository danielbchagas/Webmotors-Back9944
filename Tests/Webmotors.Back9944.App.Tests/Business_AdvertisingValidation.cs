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

        [Theory]
        [InlineData(-1, null, null, null, null, 1949)]
        [InlineData(-10, "", null, "", null, 1500)]
        [InlineData(-90, null, "", null, null, 1900)]
        public void Create_ThrowValidationException(int id, string marca, string modelo, string observacao, string versao, int date)
        {
            // Arrange
            var advertising = new Advertising
            {
                Id = id,
                Marca = marca,
                Modelo = modelo,
                Observacao = observacao,
                Versao = versao,
                Ano = date
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
