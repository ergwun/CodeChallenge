namespace CodeChallenge.Domain.Model
{
    public class Customer
    {
        public Customer(string name, bool speaksGreek, CarType? carTypePreference = null)
        {
            Name = name;
            SpeaksGreek = speaksGreek;
            CarTypePreference = carTypePreference;
        }

        public string Name { get; }

        public bool SpeaksGreek { get; }

        public CarType? CarTypePreference { get; }
    }
}
