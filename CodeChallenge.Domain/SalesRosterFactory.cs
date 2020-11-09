using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CodeChallenge.Domain
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
