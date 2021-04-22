using Bogus;
using System;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.App.Tests.Fixtures
{
    public class AdvertisingFixture
    {
        public Advertising GetInvalidAdvertising()
        {
            var advertising = new Faker<Advertising>("pt_BR");

            advertising.RuleFor(a => a.Id, b => b.Vehicle.Random.Number(-1000, -1));
            advertising.RuleFor(a => a.Marca, b => null);
            advertising.RuleFor(a => a.Modelo, b => null);
            advertising.RuleFor(a => a.Observacao, b => null);
            advertising.RuleFor(a => a.Versao, b => null);

            return advertising;
        }

        public Advertising GetValidAdvertising()
        {
            var advertising = new Faker<Advertising>("pt_BR");

            advertising.RuleFor(a => a.Id, b => b.Vehicle.Random.Number(0, int.MaxValue));
            advertising.RuleFor(a => a.Marca, b => b.Vehicle.Manufacturer());
            advertising.RuleFor(a => a.Modelo, b => b.Vehicle.Model());
            advertising.RuleFor(a => a.Observacao, b => b.Vehicle.Random.String());
            advertising.RuleFor(a => a.Versao, b => b.Vehicle.Type());
            advertising.RuleFor(a => a.Ano, b => b.Vehicle.Random.Number(1949, DateTime.Now.Year));

            return advertising;
        }
    }
}
