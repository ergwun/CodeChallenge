using CodeChallenge.Domain.Model;
using CodeChallenge.Domain.Repositories;
using System;

namespace CodeChallenge.Persistence.Repositories
{
    /// <summary>
    /// Temporary repository implementation that does not correctly manage concurrency.
    /// </summary>
    public class InMemorySalesRosterRepository : ISalesRosterRepository
    {
        private SalesRoster? salesRoster;

        public bool Initialized => salesRoster != null;

        public SalesRoster Get() => salesRoster
            ?? throw new InvalidOperationException("Initial sales roster has not been created.");

        public void Save(SalesRoster salesRoster) => this.salesRoster = salesRoster;
    }
}
