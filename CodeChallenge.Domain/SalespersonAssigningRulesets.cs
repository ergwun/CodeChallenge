using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChallenge.Domain
{
    public static class SalespersonAssigningRulesets
    {
        public static IEnumerable<SalespersonAssigningRule> Default =>
            new List<SalespersonAssigningRule>
            {
                new SalespersonAssigningRule(
                    customer => customer.SpeaksGreek && customer.CarTypePreference == CarType.SportsCar,
                    salesPeople => salesPeople.FirstOrDefault(sp => sp.HasSkills(Skill.SpeakGreek, Skill.GoodWithSportsCars)),
                    salesPeople => salesPeople.FirstOrDefault(sp => sp.HasSkills(Skill.GoodWithSportsCars)),
                    salesPeople => salesPeople.FirstOrDefault()),
                new SalespersonAssigningRule(
                    customer => customer.SpeaksGreek && customer.CarTypePreference == CarType.FamilyCar,
                    salesPeople => salesPeople.FirstOrDefault(sp => sp.HasSkills(Skill.SpeakGreek, Skill.GoodWithFamilyCars)),
                    salesPeople => salesPeople.FirstOrDefault(sp => sp.HasSkills(Skill.GoodWithFamilyCars)),
                    salesPeople => salesPeople.FirstOrDefault()),
                new SalespersonAssigningRule(
                    customer => customer.CarTypePreference == CarType.TradieVehicle,
                    salesPeople => salesPeople.FirstOrDefault(sp => sp.HasSkills(Skill.GoodWithTradieVehicles)),
                    salesPeople => salesPeople.FirstOrDefault()),
                new SalespersonAssigningRule(
                    customer => !customer.SpeaksGreek && customer.CarTypePreference == CarType.SportsCar,
                    salesPeople => salesPeople.FirstOrDefault(sp => sp.HasSkills(Skill.GoodWithSportsCars)),
                    salesPeople => salesPeople.FirstOrDefault()),
                new SalespersonAssigningRule(
                    customer => !customer.SpeaksGreek && customer.CarTypePreference == CarType.FamilyCar,
                    salesPeople => salesPeople.FirstOrDefault(sp => sp.HasSkills(Skill.GoodWithFamilyCars)),
                    salesPeople => salesPeople.FirstOrDefault()),
                new SalespersonAssigningRule(
                    customer => customer.SpeaksGreek && customer.CarTypePreference == null,
                    salesPeople => salesPeople.FirstOrDefault(sp => sp.HasSkills(Skill.SpeakGreek)),
                    salesPeople => salesPeople.FirstOrDefault()),
                new SalespersonAssigningRule(
                    customer => !customer.SpeaksGreek && customer.CarTypePreference == null,
                    salesPeople => salesPeople.FirstOrDefault()),
                };
    }
}
