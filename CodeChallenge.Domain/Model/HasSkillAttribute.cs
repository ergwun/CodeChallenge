using System;

namespace CodeChallenge.Domain.Model
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    sealed class HasSkillAttribute : Attribute
    {
        public HasSkillAttribute(Skill skill) => Skill = skill;

        public Skill Skill { get; }
    }
}
