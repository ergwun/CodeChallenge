using System.Linq;
using System.Reflection;

namespace CodeChallenge.Domain
{
    public static class GroupExtensions
    {
        public static bool HasSkill(this Group group, Skill skill) =>
            typeof(Group)
                .GetMember(group.ToString())
                .First()
                .GetCustomAttributes<HasSkillAttribute>()
                .Any(attribute => attribute.Skill == skill);
    }
}
