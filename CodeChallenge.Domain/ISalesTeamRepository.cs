using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Domain
{
    public interface ISalesTeamRepository
    {
        SalesTeam Get();
        void Save(SalesTeam salesTeam);
    }
}
