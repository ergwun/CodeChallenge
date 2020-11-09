using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Domain
{
    public class Salesperson
    {
        public Salesperson(string name, params Group[] groups)
        {
            this.Name = name;
            this.Groups = groups;
        }

        public string Name { get; }

        public IEnumerable<Group> Groups { get; }

        public Assignment? Assignment { get; private set; }

        public bool HasSkills(params Skill[] skills) => skills.All(skill => this.Groups.Any(g => g.HasSkill(skill)));

        public void AssignCustomer(Customer customer)
        {
            if (this.Assignment != null)
            {
                throw new InvalidOperationException();
            }

            this.Assignment = new Assignment(customer);
        }

        public void UnassignCustomer()
        {
            this.Assignment = null;
        }
    }
}
