using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Domain.Model
{
    public class Salesperson
    {
        public Salesperson(string name, params Group[] groups)
        {
            Name = name;
            Groups = groups;
        }

        public string Name { get; }

        public IEnumerable<Group> Groups { get; }

        public Assignment? Assignment { get; private set; }

        public bool HasSkills(params Skill[] skills) => skills.All(skill => Groups.Any(g => g.HasSkill(skill)));

        public void AssignCustomer(Customer customer)
        {
            if (Assignment != null)
            {
                throw new InvalidOperationException();
            }

            Assignment = new Assignment(customer);
        }

        public void UnassignCustomer()
        {
            Assignment = null;
        }
    }
}
