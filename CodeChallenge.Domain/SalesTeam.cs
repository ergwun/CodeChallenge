using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChallenge.Domain
{
    public class SalesTeam
    {
        public SalesTeam(IEnumerable<Salesperson> salespeople)
        {
            this.Salespeople = salespeople;
        }

        public IEnumerable<Salesperson> Salespeople { get; }

        public Salesperson? TryAssignCustomer(Customer customer, IEnumerable<SalespersonAssigningRule> ruleset)
        {
            var applicableRule = ruleset.FirstOrDefault(rule => rule.MatchesCustomer(customer));
            if (applicableRule == null)
            {
                // TODO: specific exception.
                throw new InvalidOperationException("No rule for assigning customer could be found.");
            }

            var availableSalespeople = this.Salespeople.Where(sp => sp.AssignedCustomer == null).Shuffle();
            var salesperson = applicableRule.Apply(availableSalespeople);
            if (salesperson != null)
            {
                salesperson.AssignCustomer(customer);
            }

            return salesperson;
        }

        public void UnassignCustomerFromSalesperson(string salespersonName)
        {
            Salesperson? salesperson = this.Salespeople.SingleOrDefault(sp => sp.Name == salespersonName);
            if (salesperson == null)
            {
                throw new SalespersonNotFoundException($"Salesperson '{salespersonName}' not found.");
            }

            salesperson.UnassignCustomer();
        }
    }
}
