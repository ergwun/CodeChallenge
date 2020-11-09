using CodeChallenge.Domain.Model;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace CodeChallenge.Domain.Tests
{
    public class SalesRosterIntegrationTests : IClassFixture<SalespersonDataFixture>
    {
        private readonly SalespersonDataFixture fixture;

        public SalesRosterIntegrationTests(SalespersonDataFixture fixture)
        {
            this.fixture = fixture;
        }

        [Theory]
        [InlineData(true, CarType.FamilyCar, new[] { "Kierra Gentry", "Alvaro Mcgee" })]
        [InlineData(true, CarType.SportsCar, new[] { "Thomas Crane" })]
        [InlineData(false, CarType.SportsCar, new[] { "Alden Cantrell", "Thomas Crane", "Miranda Shaffer" })]
        public void DefaultRuleset_PicksCorrectSalesperson_AccordingToProvidedTestCases(
            bool speaksGreek, CarType? soughtCarType, string[] acceptableNames)
        {
            // Arrange
            var salespeople = JsonConvert.DeserializeObject<IEnumerable<Salesperson>>(this.fixture.SalespersonJson);
            var sut = new SalesRoster(salespeople);
            var customer = new Customer("Bob", speaksGreek, soughtCarType);

            // Act
            var salesperson = sut.TryAssignCustomer(customer, SalespersonAssigningRuleset.Default);

            // Assert
            salesperson.Should().NotBeNull();
            acceptableNames.Should().Contain(salesperson!.Name);
        }
    }
}
