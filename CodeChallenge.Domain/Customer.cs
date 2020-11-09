﻿namespace CodeChallenge.Domain
{
    public class Customer
    {
        public Customer(string name, bool speaksGreek, CarType? carTypePreference = null)
        {
            this.Name = name;
            this.SpeaksGreek = speaksGreek;
            this.CarTypePreference = carTypePreference;
        }

        public string Name { get; }

        public bool SpeaksGreek { get; }

        public CarType? CarTypePreference { get; }
    }
}
