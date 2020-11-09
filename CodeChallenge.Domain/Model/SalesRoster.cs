using CodeChallenge.Domain.Exceptions;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Domain.Model
{
    public class SalesRoster
    {
        public SalesRoster(IEnumerable<Salesperson> salespeople)
        {
            Salespeople = salespeople;
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

            var availableSalespeople = Salespeople.Where(sp => sp.Assignment == null).Shuffle();
            var salesperson = applicableRule.Apply(availableSalespeople);
            if (salesperson != null)
            {
                salesperson.AssignCustomer(customer);
            }

            return salesperson;
        }

        public void DeleteAssignment(Guid assignmentId)
        {
            Salesperson? salesperson = Salespeople.SingleOrDefault(sp => sp.Assignment?.Id == assignmentId);
            if (salesperson == null)
            {
                throw new AssignmentNotFoundException($"Assignment '{assignmentId}' not found.");
            }

            salesperson.UnassignCustomer();
        }
    }
}
