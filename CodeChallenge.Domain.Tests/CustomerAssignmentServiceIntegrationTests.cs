using FluentAssertions;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CodeChallenge.Domain.Tests
{
    public class CustomerAssignmentServiceIntegrationTests
    {
        [Fact]
        public void AssignCustomer_ReturnsAssignedSalesperson_WhenSalespersonAvailable()
        {
            // Arrange
            var salesPerson = new Salesperson("Alice", new List<Group> { Group.A });
            var salespeople = new List<Salesperson> { salesPerson };
            var salesTeam = new SalesTeam(salespeople);
            var repo = new FakeSalesTeamRepository(salesTeam);
            var sut = new CustomerAssignmentService(repo, Policy.NoOp());
            var customer = new Customer("Bob", true, CarType.None);

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
            var salesTeam = new SalesTeam(salespeople);
            var repo = new FakeSalesTeamRepository(salesTeam);
            var sut = new CustomerAssignmentService(repo, Policy.NoOp());
            var customer = new Customer("Bob", true, CarType.None);

            // Act
            var assignedSalesperson = sut.AssignCustomer(customer);

            // Assert
            assignedSalesperson.Should().BeNull();
        }

        [Fact]
        public void AssignCustomer_SavesSalesTeam_WhenSalespersonAssigned()
        {
            // Arrange
            var salesPerson = new Salesperson("Alice", new List<Group> { Group.A });
            var salespeople = new List<Salesperson> { salesPerson };
            var salesTeam = new SalesTeam(salespeople);
            var repo = new FakeSalesTeamRepository(salesTeam);
            var sut = new CustomerAssignmentService(repo, Policy.NoOp());
            var customer = new Customer("Bob", true, CarType.None);

            // Act
            var assignedSalesperson = sut.AssignCustomer(customer);

            // Assert
            repo.SavedSalesTeams.Count().Should().Be(1);
        }

        [Fact]
        public void AssignCustomer_DoesNotSaveSalesTeam_WhenSalespersonNotAssigned()
        {
            // Arrange
            var salespeople = Enumerable.Empty<Salesperson>();
            var salesTeam = new SalesTeam(salespeople);
            var repo = new FakeSalesTeamRepository(salesTeam);
            var sut = new CustomerAssignmentService(repo, Policy.NoOp());
            var customer = new Customer("Bob", true, CarType.None);

            // Act
            var assignedSalesperson = sut.AssignCustomer(customer);

            // Assert
            repo.SavedSalesTeams.Count().Should().Be(0);
        }

        private class FakeSalesTeamRepository : ISalesTeamRepository
        {
            private List<SalesTeam> savedSalesTeams = new List<SalesTeam>();

            public FakeSalesTeamRepository(SalesTeam salesTeamToReturn)
            {
                this.SalesTeamToReturn = salesTeamToReturn;
            }

            public SalesTeam Get() => this.SalesTeamToReturn;

            public SalesTeam SalesTeamToReturn { get; set; }

            public void Save(SalesTeam salesTeam)
            {
                this.savedSalesTeams.Add(salesTeam);   
            }

            public IEnumerable<SalesTeam> SavedSalesTeams => this.savedSalesTeams;
        }

    }
}
