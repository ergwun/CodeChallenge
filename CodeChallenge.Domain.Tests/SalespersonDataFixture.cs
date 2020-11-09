﻿using System.IO;
using System.Reflection;

namespace CodeChallenge.Domain.Tests
{
    public class SalespersonDataFixture
    {
        const string dataFileName = "salesperson.json";

        public SalespersonDataFixture()
        {
            var location = typeof(SalespersonDataFixture).GetTypeInfo().Assembly.Location;
            var dirPath = Path.GetDirectoryName(location);
            var dataFilePath = Path.Combine(dirPath!, dataFileName);
            this.SalespersonJson = File.ReadAllText(dataFilePath);
        }

        public string SalespersonJson { get; }
    }
}
