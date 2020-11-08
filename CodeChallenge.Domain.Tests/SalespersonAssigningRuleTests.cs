using FluentAssertions;
using System;
using System.Linq;
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
                salesPeople => salesPeople.FirstOrDefault(sp => sp.HasSkills(Skill.SpeakGreek, Skill.GoodWithSportsCars)),
                salesPeople => salesPeople.FirstOrDefault(sp => sp.HasSkills(Skill.GoodWithSportsCars)),
                salesPeople => salesPeople.FirstOrDefault());

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
                salesPeople => salesPeople.FirstOrDefault(sp => sp.HasSkills(Skill.SpeakGreek, Skill.GoodWithSportsCars)),
                salesPeople => salesPeople.FirstOrDefault(sp => sp.HasSkills(Skill.GoodWithSportsCars)),
                salesPeople => salesPeople.FirstOrDefault());

            var customer = new Customer("Alice Abrahams", false, CarType.SportsCar);

            // Act
            var isMatch = sut.MatchesCustomer(customer);

            // Assert
            isMatch.Should().BeFalse();
        }
    }
}
