﻿using CodeChallenge.Domain.Model;
using CodeChallenge.Domain.Repositories;
using CodeChallenge.Domain.Services;
using FluentAssertions;
using Polly;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodeChallenge.Domain.Tests.Services
{
    public class CustomerAssignmentServiceTests
    {
        [Fact]
        public void AssignCustomer_ReturnsAssignedSalesperson_WhenSalespersonAvailable()
        {
            // Arrange
            var salesPerson = new Salesperson("Alice", Group.A);
            var salespeople = new List<Salesperson> { salesPerson };
            var salesRoster = new SalesRoster(salespeople);
            var repo = new FakeSalesRosterRepository(salesRoster);
            var sut = new CustomerAssignmentService(repo, Policy.NoOp());
            var customer = new Customer("Bob", true);

            // Act
            var assignedSalesperson = sut.AssignCustomer(customer);

            // Assert
            assignedSalesperson.Should().Be(salesPerson);
        }

        [Fact]
        public void AssignCustomer_ReturnsNull_WhenNoSalespersonAvailable()
        {
            // Arrange
            var salespeople = Enumerable.Empty<Salesperson>();
            var salesRoster = new SalesRoster(salespeople);
            var repo = new FakeSalesRosterRepository(salesRoster);
            var sut = new CustomerAssignmentService(repo, Policy.NoOp());
            var customer = new Customer("Bob", true);

            // Act
            var assignedSalesperson = sut.AssignCustomer(customer);

            // Assert
            assignedSalesperson.Should().BeNull();
        }

        [Fact]
        public void AssignCustomer_SavesSalesRoster_WhenSalespersonAssigned()
        {
            // Arrange
            var salesPerson = new Salesperson("Alice", Group.A);
            var salespeople = new List<Salesperson> { salesPerson };
            var salesRoster = new SalesRoster(salespeople);
            var repo = new FakeSalesRosterRepository(salesRoster);
            var sut = new CustomerAssignmentService(repo, Policy.NoOp());
            var customer = new Customer("Bob", true);

            // Act
            var assignedSalesperson = sut.AssignCustomer(customer);

            // Assert
            repo.SavedSalesRosters.Count().Should().Be(1);
        }

        [Fact]
        public void AssignCustomer_DoesNotSaveSalesRoster_WhenSalespersonNotAssigned()
        {
            // Arrange
            var salespeople = Enumerable.Empty<Salesperson>();
            var salesRoster = new SalesRoster(salespeople);
            var repo = new FakeSalesRosterRepository(salesRoster);
            var sut = new CustomerAssignmentService(repo, Policy.NoOp());
            var customer = new Customer("Bob", true);

            // Act
            var assignedSalesperson = sut.AssignCustomer(customer);

            // Assert
            repo.SavedSalesRosters.Count().Should().Be(0);
        }

        private class FakeSalesRosterRepository : ISalesRosterRepository
        {
            private List<SalesRoster> savedSalesRosters = new List<SalesRoster>();

            public FakeSalesRosterRepository(SalesRoster salesRosterToReturn)
            {
                SalesRosterToReturn = salesRosterToReturn;
            }

            public bool Initialized => true;

            public SalesRoster Get() => SalesRosterToReturn;

            public SalesRoster SalesRosterToReturn { get; set; }

            public void Save(SalesRoster salesRoster)
            {
                savedSalesRosters.Add(salesRoster);
            }

            public IEnumerable<SalesRoster> SavedSalesRosters => savedSalesRosters;
        }

    }
}
