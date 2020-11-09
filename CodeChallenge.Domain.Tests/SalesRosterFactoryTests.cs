using CodeChallenge.Domain.Model;
using CodeChallenge.Domain.Services;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace CodeChallenge.Domain.Tests
{
    public class SalesRosterFactoryTests
    {
        [Fact]
        public void Build_SuccessfullyCreatesRoster_WhenJsonIsValid()
        {
            // Arrange
            var sut = new SalesRosterFactory();
            var json = @"[
  {
    ""Name"":""Cierra Vega"",
    ""Groups"": [""A""]
  },
  {
    ""Name"":""Alden Cantrell"",
    ""Groups"": [""B"", ""D""]
  }
]";

            // Act
            var roster = sut.Build(json);

            // Assert
            roster.Salespeople.Should().NotBeNull()
                .And.HaveCount(2)
                .And.Contain(sp => sp.Name == "Cierra Vega" && sp.Groups.Contains(Group.A))
                .And.Contain(sp => sp.Name == "Alden Cantrell" && sp.Groups.Contains(Group.B) && sp.Groups.Contains(Group.D));
        }
    }
}
