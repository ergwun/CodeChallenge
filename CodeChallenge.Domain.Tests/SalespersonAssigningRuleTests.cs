using CodeChallenge.Domain.Model;
using FluentAssertions;
using Xunit;

namespace CodeChallenge.Domain.Tests
{
    public class SalespersonAssigningRuleTests
    {
        [Fact]
        public void MatchesCustomer_ReturnsTrue_WhenMatchSucceeds()
        {
            // Arrange
            var sut = new SalespersonAssigningRule(
                customer => customer.SpeaksGreek && customer.CarTypePreference == CarType.SportsCar,
                sp => sp.HasSkills(Skill.SpeakGreek, Skill.GoodWithSportsCars),
                sp => sp.HasSkills(Skill.GoodWithSportsCars),
                sp => true);

            var customer = new Customer("Alice Abrahams", true, CarType.SportsCar);

            // Act
            var isMatch = sut.MatchesCustomer(customer);

            // Assert
            isMatch.Should().BeTrue();
        }

        [Fact]
        public void MatchesCustomer_ReturnsFalse_WhenMatchDoesNotSucceed()
        {
            // Arrange
            var sut = new SalespersonAssigningRule(
                customer => customer.SpeaksGreek && customer.CarTypePreference == CarType.SportsCar,
                salesperson => salesperson.HasSkills(Skill.SpeakGreek, Skill.GoodWithSportsCars),
                salesperson => salesperson.HasSkills(Skill.GoodWithSportsCars),
                salesperson => true);

            var customer = new Customer("Alice Abrahams", false, CarType.SportsCar);

            // Act
            var isMatch = sut.MatchesCustomer(customer);

            // Assert
            isMatch.Should().BeFalse();
        }
    }
}
