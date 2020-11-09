using System;

namespace CodeChallenge.Domain
{
    public class Assignment
    {
        public Assignment(Customer customer)
        {
            this.Id = Guid.NewGuid();
            this.Customer = customer;
        }

        public Guid Id { get; }

        public Customer Customer { get; }
    }
}
