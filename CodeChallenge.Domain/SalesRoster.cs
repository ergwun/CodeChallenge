using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Domain
{
    public class SalesRoster
    {
        public SalesRoster(IEnumerable<Salesperson> salespeople)
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

            var availableSalespeople = this.Salespeople.Where(sp => sp.Assignment == null).Shuffle();
            var salesperson = applicableRule.Apply(availableSalespeople);
            if (salesperson != null)
            {
                salesperson.AssignCustomer(customer);
            }

            return salesperson;
        }

        public void DeleteAssignment(Guid assignmentId)
        {
            Salesperson? salesperson = this.Salespeople.SingleOrDefault(sp => sp.Assignment?.Id == assignmentId);
            if (salesperson == null)
            {
                throw new SalespersonNotFoundException($"Assignment '{assignmentId}' not found.");
            }

            salesperson.UnassignCustomer();
        }
    }
}
