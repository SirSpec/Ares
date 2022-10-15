namespace Ares.Domain.Constants;

public static class ErrorCodes
{
    public static class DieRoll
    {
        public const string InvalidValue = $"{nameof(Ares.Domain.ValueObjects.DieRoll)}:{nameof(InvalidValue)}";
        public const string InvalidType = $"{nameof(Ares.Domain.ValueObjects.DieRoll)}:{nameof(InvalidType)}";
        public const string InvalidRollCount = $"{nameof(Ares.Domain.ValueObjects.DieRoll)}:{nameof(InvalidRollCount)}";
    }

    public static class AbilityScore
    {
        public const string InvalidValue = $"{nameof(Ares.Domain.ValueObjects.AbilityScore)}:{nameof(InvalidValue)}";
    }

    public static class Level
    {
        public const string InvalidValue = $"{nameof(Ares.Domain.ValueObjects.Level)}:{nameof(InvalidValue)}";
    }

    public static class Experience
    {
        public const string InvalidValue = $"{nameof(Ares.Domain.ValueObjects.Experience)}:{nameof(InvalidValue)}";
    }

    public static class Coinage
    {
        public const string InvalidValue = $"{nameof(Ares.Domain.ValueObjects.Coinage)}:{nameof(InvalidValue)}";
        public const string IncompatibleCoinage = $"{nameof(Ares.Domain.ValueObjects.Coinage)}:{nameof(IncompatibleCoinage)}";
    }

    public static class CoinageBag
    {
        public const string InvalidDictionaryKeys = $"{nameof(Ares.Domain.ValueObjects.CoinageBag)}:{nameof(InvalidDictionaryKeys)}";
    }

    public static class AbilityScoreList
    {
        public const string InvalidDictionaryKeys = $"{nameof(Ares.Domain.ValueObjects.AbilityScoreList)}:{nameof(InvalidDictionaryKeys)}";
    }

    public static class HitPoints
    {
        public const string InvalidArgument = $"{nameof(Ares.Domain.ValueObjects.HitPoints)}:{nameof(InvalidArgument)}";
    }

    public static class HitDice
    {
        public const string InvalidArgument = $"{nameof(Ares.Domain.ValueObjects.HitDice)}:{nameof(InvalidArgument)}";
    }

    public static class DeathSaves
    {
        public const string InvalidArgument = $"{nameof(Ares.Domain.ValueObjects.DeathSaves)}:{nameof(InvalidArgument)}";
    }

    public static class Character
    {
        public const string MaximumSuccessededDeathSavesReached = $"{nameof(Ares.Domain.Entities.Character)}:{nameof(MaximumSuccessededDeathSavesReached)}";
        public const string MaximumFailedDeathSavesReached = $"{nameof(Ares.Domain.Entities.Character)}:{nameof(MaximumFailedDeathSavesReached)}";
    }
}
