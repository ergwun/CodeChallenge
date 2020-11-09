using CodeChallenge.Domain.Model;

namespace CodeChallenge.Domain.Repositories
{
    public interface ISalesRosterRepository
    {
        bool Initialized { get; }
        SalesRoster Get();
        void Save(SalesRoster salesRoster);
    }
}
