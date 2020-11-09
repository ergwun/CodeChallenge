using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Domain
{
    public class SalespersonAssigningRule
    {
        private readonly Predicate<Customer> matchesCustomer;
        private readonly IEnumerable<Predicate<Salesperson>> selectors;

        public SalespersonAssigningRule(Predicate<Customer> matchesCustomer, params Predicate<Salesperson>[] selectors)
        {
            this.matchesCustomer = matchesCustomer;
            this.selectors = selectors;
        }

        public bool MatchesCustomer(Customer customer)
        {
            return this.matchesCustomer(customer);
        }

        public Salesperson? Apply(IEnumerable<Salesperson> salespeople)
        {
            return selectors
                .Select(selector => salespeople.FirstOrDefault(sp => selector.Invoke(sp)))
                .FirstOrDefault(salesperson => salesperson != null);
        }
    }
}
