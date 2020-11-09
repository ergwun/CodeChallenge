using System.Collections.Generic;

namespace CodeChallenge.Domain
{
    public static class SalespersonAssigningRuleset
    {
        public static IEnumerable<SalespersonAssigningRule> Default =>
            new List<SalespersonAssigningRule>
            {
                new SalespersonAssigningRule(
                    customer => customer.SpeaksGreek && customer.CarTypePreference == CarType.SportsCar,
                    sp => sp.HasSkills(Skill.SpeakGreek, Skill.GoodWithSportsCars),
                    sp => sp.HasSkills(Skill.GoodWithSportsCars),
                    sp => true),
                new SalespersonAssigningRule(
                    customer => customer.SpeaksGreek && customer.CarTypePreference == CarType.FamilyCar,
                    sp => sp.HasSkills(Skill.SpeakGreek, Skill.GoodWithFamilyCars),
                    sp => sp.HasSkills(Skill.GoodWithFamilyCars),
                    sp => true),
                new SalespersonAssigningRule(
                    customer => customer.CarTypePreference == CarType.TradieVehicle,
                    sp => sp.HasSkills(Skill.GoodWithTradieVehicles),
                    sp => true),
                new SalespersonAssigningRule(
                    customer => !customer.SpeaksGreek && customer.CarTypePreference == CarType.SportsCar,
                    sp => sp.HasSkills(Skill.GoodWithSportsCars),
                    sp => true),
                new SalespersonAssigningRule(
                    customer => !customer.SpeaksGreek && customer.CarTypePreference == CarType.FamilyCar,
                    sp => sp.HasSkills(Skill.GoodWithFamilyCars),
                    sp => true),
                new SalespersonAssigningRule(
                    customer => customer.SpeaksGreek && customer.CarTypePreference == null,
                    sp => sp.HasSkills(Skill.SpeakGreek),
                    sp => true),
                new SalespersonAssigningRule(
                    customer => !customer.SpeaksGreek && customer.CarTypePreference == null,
                    sp => true)
                };
    }
}
