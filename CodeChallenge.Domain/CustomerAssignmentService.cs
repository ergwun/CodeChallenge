using Polly;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Domain
{
    public class CustomerAssignmentService
    {
        private readonly ISalesTeamRepository salesTeamRepository;
        private readonly Policy retryPolicy;

        public CustomerAssignmentService(
            ISalesTeamRepository salesTeamRepository,
            Policy retryPolicy)
        {
            this.salesTeamRepository = salesTeamRepository;
            this.retryPolicy = retryPolicy;
        }

        public Salesperson? AssignCustomer(Customer customer)
        {
            Salesperson? HandleImplementation(Customer customer)
            {
                var salesTeam = this.salesTeamRepository.Get();
                var assignedSalesperson = salesTeam.TryAssignCustomer(customer, SalespersonAssigningRulesets.Default);
                if (assignedSalesperson != null)
                {
                    this.salesTeamRepository.Save(salesTeam);
                }

                return assignedSalesperson;
            }

            return this.retryPolicy.Execute(() => HandleImplementation(customer));
        }

        public void UnassignCustomerFromSalesperson(string salesPersonName)
        {
            void Implementation(string salesPersonName)
            {
                var salesTeam = this.salesTeamRepository.Get();
                salesTeam.UnassignCustomerFromSalesperson(salesPersonName);
            }

            retryPolicy.Execute(() => Implementation(salesPersonName));
        }
    }
}
