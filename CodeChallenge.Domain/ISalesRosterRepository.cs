using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Domain
{
    public interface ISalesRosterRepository
    {
        bool Initialized { get; }
        SalesRoster Get();
        void Save(SalesRoster salesRoster);
    }
}
