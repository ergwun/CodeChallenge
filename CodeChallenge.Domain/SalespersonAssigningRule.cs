using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChallenge.Domain
{
    public class SalespersonAssigningRule
    {
        private readonly Predicate<Customer> matchesCustomer;
        private readonly IEnumerable<Func<IEnumerable<Salesperson>, Salesperson?>> selectors;

        public SalespersonAssigningRule(Predicate<Customer> matchesCustomer, params Func<IEnumerable<Salesperson>, Salesperson?>[] selectors)
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
                .Select(selector => selector.Invoke(salespeople))
                .FirstOrDefault(salesperson => salesperson != null);
        }
    }
}
