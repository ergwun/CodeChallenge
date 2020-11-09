using CodeChallenge.Domain.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CodeChallenge.Domain.Services
{
    public class SalesRosterFactory
    {
        public SalesRoster Build(string json)
        {
            var salespeople = JsonConvert.DeserializeObject<IEnumerable<Salesperson>>(json);
            return new SalesRoster(salespeople);
        }
    }
}
