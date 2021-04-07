using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Webmotors.Back9944.App.Tests.Factories;
using Webmotors.Back9944.Business.Interfaces.Repositories;
using Xunit;

namespace Webmotors.Back9944.App.Tests
{
    public class Data_AdvertisingRepository : IClassFixture<DataFactory<Startup>>
    {
        private readonly DataFactory<Startup> _factory;
        private readonly IAdvertisingRepository _repository;

        public Data_AdvertisingRepository(DataFactory<Startup> factory)
        {
            _factory = factory;
            var scope = _factory.Services.CreateScope();
            _repository = scope.ServiceProvider.GetRequiredService<IAdvertisingRepository>();
        }

        [Theory]
        [InlineData(-1)]
        public async Task Get(int id)
        {
            // Arrange

            // Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(async () => 
            {
                // Act
                var result = await _repository.Get(id);
            });
        }
    }
}
