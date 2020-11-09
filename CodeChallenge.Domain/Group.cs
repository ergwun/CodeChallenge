namespace CodeChallenge.Domain
{
    public enum Group
    {
        [HasSkill(Skill.SpeakGreek)]
        A,

        [HasSkill(Skill.GoodWithSportsCars)]
        B,

        [HasSkill(Skill.GoodWithFamilyCars)]
        C,

        [HasSkill(Skill.GoodWithTradieVehicles)]
        D
    }
}
