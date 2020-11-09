using System;

namespace CodeChallenge.Domain
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    sealed class HasSkillAttribute : Attribute
    {
        public HasSkillAttribute(Skill skill) => this.Skill = skill;

        public Skill Skill { get; }
    }
}
