using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeChallenge.Domain.Tests
{
    public class GroupExtensionTests
    {
        [Theory]
        [InlineData(Group.A, Skill.SpeakGreek)]
        [InlineData(Group.B, Skill.GoodWithSportsCars)]
        public void HasSkill_ReturnsTrue_WhenGroupHasSkill(Group group, Skill skill)
        {
            group.HasSkill(skill).Should().BeTrue();
        }

        [Theory]
        [InlineData(Group.B, Skill.SpeakGreek)]
        [InlineData(Group.A, Skill.GoodWithSportsCars)]
        public void HasSkill_ReturnsFalse_WhenGroupdoesNotHaveSkill(Group group, Skill skill)
        {
            group.HasSkill(skill).Should().BeFalse();
        }
    }
}
