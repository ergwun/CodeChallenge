using CodeChallenge.Domain.Model;
using CodeChallenge.Domain.Repositories;
using Polly;
using System;
using System.Linq;

namespace CodeChallenge.Domain.Services
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
                var salesRoster = salesRosterRepository.Get();
                var assignedSalesperson = salesRoster.TryAssignCustomer(customer, SalespersonAssigningRuleset.Default);
                if (assignedSalesperson != null)
                {
                    salesRosterRepository.Save(salesRoster);
                }

                return assignedSalesperson;
            }

            return retryPolicy.Execute(() => HandleImplementation(customer));
        }

        public void DeleteAssignment(Guid assignmentId)
        {
            void DeletionImplementation(Guid assignmentId)
            {
                var salesRoster = salesRosterRepository.Get();
                salesRoster.DeleteAssignment(assignmentId);
                salesRosterRepository.Save(salesRoster);
            }

            retryPolicy.Execute(() => DeletionImplementation(assignmentId));
        }

        public Salesperson? GetSalespersonWithAssignment(Guid assignmentId) =>
            salesRosterRepository.Get().Salespeople.SingleOrDefault(sp => sp.Assignment?.Id == assignmentId);
    }
}
