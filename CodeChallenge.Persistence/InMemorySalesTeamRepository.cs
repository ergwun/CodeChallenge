using CodeChallenge.Domain;
using System;

namespace CodeChallenge.Persistence
{
    /// <summary>
    /// Temporary repository implementation that does not correctly manage concurrency.
    /// </summary>
    public class InMemorySalesRosterRepository : ISalesRosterRepository
    {
        private SalesRoster? salesRoster;

        public bool Initialized => this.salesRoster != null;

        public SalesRoster Get() => this.salesRoster
            ?? throw new InvalidOperationException("Initial sales roster has not been created.");

        public void Save(SalesRoster salesRoster) => this.salesRoster = salesRoster;
    }
}
