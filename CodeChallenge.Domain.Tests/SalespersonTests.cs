using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Xunit;

namespace CodeChallenge.Domain.Tests
{
    public class SalespersonTests
    {
        [Fact]
        public void HasSkill_ReturnsTrue_WhenMembershipGroupHasSingleEnquiredSkill()
        {
            // Arrange
            var sut = new Salesperson("Alice Abraham", Group.A);

            // Act
            var result = sut.HasSkills(Skill.SpeakGreek);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void HasSkill_ReturnsTrue_WhenMembershipGroupsHaveAllEnquiredSkills()
        {
            // Arrange
            var sut = new Salesperson("Alice Abraham", Group.A, Group.B);

            // Act
            var result = sut.HasSkills(Skill.SpeakGreek, Skill.GoodWithSportsCars);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void HasSkill_ReturnsFalse_WhenMembershipGroupsHaveOnlySomeEnquiredSkills()
        {
            // Arrange
            var sut = new Salesperson("Alice Abraham", Group.A, Group.B);

            // Act
            var result = sut.HasSkills(Skill.SpeakGreek, Skill.GoodWithFamilyCars);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void AssignCustomer_Succeeds_WhenCustomerNotAlreadyAssigned()
        {
            // Arrange
            var sut = new Salesperson("Alice Abraham", Group.A, Group.B);
            var customer = new Customer("Bob Roberts", false, CarType.None);

            // Act
            sut.AssignCustomer(customer);

            // Assert
            sut.Assignment.Should().Be(customer);
        }

        [Fact]
        public void AssignCustomer_Throws_WhenCustomerAlreadyAssigned()
        {
            // Arrange
            var sut = new Salesperson("Alice Abraham", Group.A, Group.B);
            var customer1 = new Customer("Bob Roberts", false, CarType.None);
            sut.AssignCustomer(customer1);
            var customer2 = new Customer("Carol Christmas", false, CarType.None);

            // Act
            Action action = () => sut.AssignCustomer(customer2);

            // Assert
            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void AssignCustomer_Succeeds_AfterCustomerUnassigned()
        {
            // Arrange
            var sut = new Salesperson("Alice Abraham", Group.A, Group.B);
            var customer1 = new Customer("Bob Roberts", false, CarType.None);
            sut.AssignCustomer(customer1);
            sut.UnassignCustomer();
            var customer2 = new Customer("Carol Christmas", false, CarType.None);

            // Act
            sut.AssignCustomer(customer2);

            // Assert
            sut.Assignment.Should().Be(customer2);
        }
    }
}
