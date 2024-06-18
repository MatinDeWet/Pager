using Bogus;
using Pager.UnitTests.Context;
using Pager.UnitTests.Models;

namespace Pager.UnitTests.MockData.DataSeed
{
    public class ClientData : IMockData
    {
        public void Seed(TestContext db)
        {
            int clientIds = 1;
            var Clients = new Faker<Client>()
            .RuleFor(c => c.Id, f => clientIds++)
            .RuleFor(c => c.FirstName, f => f.Person.FirstName)
            .RuleFor(c => c.LastName, f => f.Person.LastName)
            .RuleFor(c => c.Email, f => f.Person.Email)
            .Generate(100);

            db.Clients.AddRange(Clients);
        }
    }
}
