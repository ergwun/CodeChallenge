using CodeChallenge.Domain;
using System;

namespace CodeChallenge.Persistence
{
    /// <summary>
    /// Temporary repository implementation that does not correctly manage concurrency.
    /// </summary>
    public class InMemorySalesTeamRepository : ISalesTeamRepository
    {
        private SalesTeam salesTeam;
    
        public InMemorySalesTeamRepository(SalesTeam initialSaleTeam)
        {
            this.salesTeam = initialSaleTeam;
        }

        public SalesTeam Get() => this.salesTeam;

        public void Save(SalesTeam salesTeam) => this.salesTeam = salesTeam;
    }
}
