using CodeChallenge.Domain;
using System.IO;

namespace CodeChallenge.Web
{
    public class DataInitializer
    {
        private const string dataFilePath = "Data\\salesperson.json";

        private readonly SalesRosterFactory salesRosterFactory;
        private readonly ISalesRosterRepository salesRosterRepository;

        public DataInitializer(
            SalesRosterFactory salesRosterFactory,
            ISalesRosterRepository salesRosterRepository)
        {
            this.salesRosterFactory = salesRosterFactory;
            this.salesRosterRepository = salesRosterRepository;
        }

        public void InitializeData()
        {
            if (this.salesRosterRepository.Initialized)
            {
                return;
            }

            var salesRoster = this.ParseDataFile();
            this.salesRosterRepository.Save(salesRoster);
        }

        private SalesRoster ParseDataFile()
        {
            var json = File.ReadAllText(dataFilePath);
            return this.salesRosterFactory.Build(json);
        }
    }
}
