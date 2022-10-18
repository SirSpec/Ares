using Ares.Domain.Constants;
using Ares.Domain.Exceptions;
using Ares.Domain.ValueObjects;

namespace Ares.Domain.Entities;

public class Character : AggregateRoot<Guid>
{
    private readonly List<Guid> _equipment;

    public Character(
        Guid id,
        string name,
        string playerName,
        Race race,
        CharacterClass characterClass,
        Background background,
        Alignment alignment,
        IEnumerable<string> personalityTraits,
        IEnumerable<string> ideals,
        IEnumerable<string> bonds,
        IEnumerable<string> flaws,
        IEnumerable<Skill> proficientSkills,
        IEnumerable<string> featuresAndTraits,
        IEnumerable<string> languages,
        IEnumerable<string> otherProficiencies) : base(id)
    {
        Name = name;
        PlayerName = playerName;
        Race = race;
        CharacterClass = characterClass;
        Background = background;
        Alignment = alignment;
        PersonalityTraits = personalityTraits;
        Ideals = ideals;
        Bonds = bonds;
        Flaws = flaws;
        ProficientSkills = proficientSkills;
        FeaturesAndTraits = featuresAndTraits;
        Languages = languages;
        OtherProficiencies = otherProficiencies;
    }

    public string Name { get; }
    public string PlayerName { get; }

    public Race Race { get; }
    public CharacterClass CharacterClass { get; }
    public Background Background { get; }
    public Alignment Alignment { get; }

    public IEnumerable<string> PersonalityTraits { get; }
    public IEnumerable<string> Ideals { get; }
    public IEnumerable<string> Bonds { get; }
    public IEnumerable<string> Flaws { get; }

    public IEnumerable<Skill> ProficientSkills { get; }
    public IEnumerable<string> FeaturesAndTraits { get; }
    public IEnumerable<string> Languages { get; }
    public IEnumerable<string> OtherProficiencies { get; }

    public List<Guid> Equipment { get; }

    public Experience Experience { get; set; }
    public Level Level { get; internal set; }
    public CoinageBag CoinageBag { get; internal set; }

    public AbilityScoreList AbilityScores { get; internal set; }
    public int AbilityScorePoints { get; internal set; }

    public uint ArmorClass { get; internal set; }
    public uint TotalWeight { get; internal set; }
    public uint Initiative { get; internal set; }
    public uint Speed { get; internal set; }
    public bool Inspiration { get; internal set; }

    public HitDice HitDice { get; internal set; }
    public HitPoints HitPoints { get; internal set; }
    public DeathSaves DeathSaves { get; internal set; }
    public HashSet<Condition> Conditions { get; }

    public int ProficiencyBonus =>
        ((Level - 1) / 4) + 2;

    public void GainExperience(Experience experience) =>
        Experience = Experience.IsMaximum is false
            ? Experience.Value + experience.Value <= Experience.Maximum
                ? Experience.IncreasedBy(experience)
                : new Experience(Experience.Maximum)
            : throw new DomainException(ErrorCodes.Character.MaximumExperienceGained);

    public void AddItem(Guid itemId)
    {
        if (_equipment.Contains(itemId) is false)
            _equipment.Add(itemId);
        else throw new DomainException(ErrorCodes.Character.ItemAlreadyAdded, (nameof(itemId), itemId));
    }

    public void RemoveItem(Guid itemId)
    {
        if (_equipment.Contains(itemId))
            _equipment.Remove(itemId);
        else throw new DomainException(ErrorCodes.Character.ItemNotAdded, (nameof(itemId), itemId));
    }

    public void AddCoinage(Coinage coinage) =>
        CoinageBag = CoinageBag.GetIncreasedBy(coinage);

    public void RemoveCoinage(Coinage coinage) =>
        CoinageBag = CoinageBag.GetDecreasedBy(coinage);

    public void IncreaseAbilityScoreBy(AbilityScoreType abilityScore, int value) =>
        AbilityScores = AbilityScores.GetIncreasedBy(abilityScore, value);
}
