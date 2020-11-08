using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Domain
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    sealed class HasSkillAttribute : Attribute
    {
        public HasSkillAttribute(Skill skill) => this.Skill = skill;

        public Skill Skill { get; }
    }
}
