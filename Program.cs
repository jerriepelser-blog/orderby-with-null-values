using System.Linq;
using Bogus;
using Bogus.Extensions;
using ConsoleTables;

namespace OrderByWithNull
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var installations = new Faker<Installation>()
                .UseSeed(1)
                .RuleFor(o => o.Id, faker => faker.IndexFaker)
                .RuleFor(o => o.InstallationDate, faker => faker.Date.Future().OrNull(faker))
                .RuleFor(o => o.Customer, faker => faker.Person.FullName)
                .Generate(10);

            var orderedInstallations = installations
                .OrderByDescending(i => i.InstallationDate.HasValue)
                .ThenBy(i => i.InstallationDate);
            
            ConsoleTable.From(orderedInstallations)
                .Write(Format.Alternative);
        }
    }
}