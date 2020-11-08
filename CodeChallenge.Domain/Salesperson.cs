using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Domain
{
    public class Salesperson
    {
        public Salesperson(string name, IEnumerable<Group> groups, Customer? assignedCustomer = null)
        {
            this.Name = name;
            this.Groups = groups;
            this.AssignedCustomer = assignedCustomer;
        }

        public string Name { get; }

        public IEnumerable<Group> Groups { get; }

        public Customer? AssignedCustomer { get; private set; }

        public bool HasSkills(params Skill[] skills) => skills.All(skill => this.Groups.Any(g => g.HasSkill(skill)));

        public void AssignCustomer(Customer customer)
        {
            if (this.AssignedCustomer != null)
            {
                throw new InvalidOperationException();
            }

            this.AssignedCustomer = customer;
        }

        public void UnassignCustomer()
        {
            this.AssignedCustomer = null;
        }
    }
}
