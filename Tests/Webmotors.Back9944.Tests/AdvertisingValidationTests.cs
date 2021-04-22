using Webmotors.Back9944.App.Tests.Fixtures;
using Webmotors.Back9944.Business.Validations;
using Xunit;

namespace Webmotors.Back9944.Tests
{
    [Collection(nameof(AdvertisingCollection))]
    public class AdvertisingValidationTests
    {
        private readonly AdvertisingFixture _fixture;
        private readonly AdvertisingValidation _validations;

        public AdvertisingValidationTests()
        {
            _fixture = new AdvertisingFixture();
            _validations = new AdvertisingValidation();
        }

        [Fact]
        public void Validation_Fail()
        {
            // Arrange
            var advertising = _fixture.GetInvalidAdvertising();
            
            // Act
            var result = _validations.Validate(advertising);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Validation_Success()
        {
            // Arrange
            var advertising = _fixture.GetValidAdvertising();

            // Act
            var result = _validations.Validate(advertising);

            // Assert
            Assert.True(result.IsValid);
        }
    }
}
