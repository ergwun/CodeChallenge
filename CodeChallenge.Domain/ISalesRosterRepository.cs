namespace CodeChallenge.Domain
{
    public interface ISalesRosterRepository
    {
        bool Initialized { get; }
        SalesRoster Get();
        void Save(SalesRoster salesRoster);
    }
}
