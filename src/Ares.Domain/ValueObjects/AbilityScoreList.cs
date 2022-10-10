using Ares.Domain.Constants;
using Ares.Domain.Exceptions;

namespace Ares.Domain.ValueObjects;

public record AbilityScoreList
{
    private readonly Dictionary<AbilityScoreType, AbilityScore> _abilityScores;

    public AbilityScoreList(Dictionary<AbilityScoreType, AbilityScore> abilityScores) =>
        _abilityScores = Enum.GetValues<AbilityScoreType>().Except(abilityScores.Keys).Any() is false
            ? abilityScores
            : throw new DomainException(ErrorCodes.AbilityScoreList.InvalidDictionaryKeys, (nameof(abilityScores), abilityScores));

    public AbilityScore this[AbilityScoreType abilityScore] =>
        _abilityScores[abilityScore];

    public AbilityScoreList GetIncreasedBy(AbilityScoreType abilityScore, int value)
    {
        var abilityScores = new Dictionary<AbilityScoreType, AbilityScore>(_abilityScores);
        abilityScores[abilityScore] = abilityScores[abilityScore].GetIncreasedBy(value);
        return new AbilityScoreList(abilityScores);
    }
}
