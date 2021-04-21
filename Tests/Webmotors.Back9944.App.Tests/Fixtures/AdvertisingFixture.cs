using Bogus;
using System;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.App.Tests.Fixtures
{
    public class AdvertisingFixture
    {
        public Advertising GetInvalidAdvertising()
        {
            var faker = new Faker<Advertising>();

            faker.RuleFor(a => a.Id, b => b.Vehicle.Random.Number(-1000, -1));
            faker.RuleFor(a => a.Marca, b => null);
            faker.RuleFor(a => a.Modelo, b => null);
            faker.RuleFor(a => a.Observacao, b => null);
            faker.RuleFor(a => a.Versao, b => null);

            return faker;
        }

        public Advertising GetValidAdvertising()
        {
            var faker = new Faker<Advertising>("pt_BR");

            faker.RuleFor(a => a.Id, b => b.Vehicle.Random.Number(0, int.MaxValue));
            faker.RuleFor(a => a.Marca, b => b.Vehicle.Manufacturer());
            faker.RuleFor(a => a.Modelo, b => b.Vehicle.Model());
            faker.RuleFor(a => a.Observacao, b => b.Vehicle.Random.String());
            faker.RuleFor(a => a.Versao, b => b.Vehicle.Type());
            faker.RuleFor(a => a.Ano, b => b.Vehicle.Random.Number(1949, DateTime.Now.Year));

            return faker;
        }
    }
}
