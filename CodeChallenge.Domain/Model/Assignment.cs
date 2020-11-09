using System;

namespace CodeChallenge.Domain.Model
{
    public class Assignment
    {
        public Assignment(Customer customer)
        {
            Id = Guid.NewGuid();
            Customer = customer;
        }

        public Guid Id { get; }

        public Customer Customer { get; }
    }
}
