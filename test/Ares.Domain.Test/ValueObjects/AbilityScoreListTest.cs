using System;
using System.Collections.Generic;
using Ares.Domain.Constants;
using Ares.Domain.Exceptions;
using Ares.Domain.ValueObjects;
using Xunit;

namespace Ares.Domain.Test.ValueObjects;

public class AbilityScoreListTest
{
    [Fact]
    public void Constructor_MissingAbilityScoreType_ThrowsDomainException()
    {
        Action action = () => new AbilityScoreList(new Dictionary<AbilityScoreType, AbilityScore>
        {
            { AbilityScoreType.Strength, new AbilityScore(1) }
        });

        Assert.Throws<DomainException>(action);
    }

    [Theory]
    [InlineData(AbilityScoreType.Strength, 1, 2)]
    [InlineData(AbilityScoreType.Dexterity, 5, 6)]
    [InlineData(AbilityScoreType.Intelligence, 10, 11)]
    [InlineData(AbilityScoreType.Constitution, 13, 18)]
    [InlineData(AbilityScoreType.Wisdom, 10, 15)]
    [InlineData(AbilityScoreType.Charisma, 5, 10)]
    public void GetIncreasedBy_IncreaseBy_IncreasedValue(AbilityScoreType abilityScoreType, int increase, int expected)
    {
        var sut = new AbilityScoreList(new Dictionary<AbilityScoreType, AbilityScore>
        {
            { AbilityScoreType.Strength, new AbilityScore(1) },
            { AbilityScoreType.Dexterity, new AbilityScore(1) },
            { AbilityScoreType.Intelligence, new AbilityScore(1) },
            { AbilityScoreType.Constitution, new AbilityScore(5) },
            { AbilityScoreType.Wisdom, new AbilityScore(5) },
            { AbilityScoreType.Charisma, new AbilityScore(5) },
        });

        var actual = sut.GetIncreasedBy(abilityScoreType, increase)[abilityScoreType].Value;

        Assert.Equal(expected, actual);
    }
}
