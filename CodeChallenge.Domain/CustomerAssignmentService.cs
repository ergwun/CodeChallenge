using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChallenge.Domain
{
    public class CustomerAssignmentService
    {
        private readonly ISalesRosterRepository salesRosterRepository;
        private readonly Policy retryPolicy;

        public CustomerAssignmentService(
            ISalesRosterRepository salesRosterRepository,
            Policy retryPolicy)
        {
            this.salesRosterRepository = salesRosterRepository;
            this.retryPolicy = retryPolicy;
        }

        public Salesperson? AssignCustomer(Customer customer)
        {
            Salesperson? HandleImplementation(Customer customer)
            {
                var salesRoster = this.salesRosterRepository.Get();
                var assignedSalesperson = salesRoster.TryAssignCustomer(customer, SalespersonAssigningRuleset.Default);
                if (assignedSalesperson != null)
                {
                    this.salesRosterRepository.Save(salesRoster);
                }

                return assignedSalesperson;
            }

            return this.retryPolicy.Execute(() => HandleImplementation(customer));
        }

        public void DeleteAssignment(Guid assignmentId)
        {
            void DeletionImplementation(Guid assignmentId)
            {
                var salesRoster = this.salesRosterRepository.Get();
                salesRoster.DeleteAssignment(assignmentId);
                this.salesRosterRepository.Save(salesRoster);
            }

            retryPolicy.Execute(() => DeletionImplementation(assignmentId));
        }

        public Salesperson? GetSalespersonWithAssignment(Guid assignmentId) =>
            this.salesRosterRepository.Get().Salespeople.SingleOrDefault(sp => sp.Assignment?.Id == assignmentId);
    }
}
