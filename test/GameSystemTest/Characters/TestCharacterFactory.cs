using System.Collections.Generic;
using Ares.GameSystemTest.Stubs;
using Ares.Inventory;
using Ares.Statistics;
using Ares.GameSystem;
using Ares.GameSystem.Defence;
using Ares.GameSystem.Statistics.DerivedStatistics.Offence;
using Ares.GameSystem.Statistics.PrimaryStatistics.Defence;
using Ares.GameSystem.Weapons;

namespace Ares.GameSystemTest.Characters
{
    public static class TestCharacterFactory
    {
        public static Character GetCharacterWithBodyArmor()
        {
            var character = new CharacterFactory().NewCharacter("JohnDoe");

            var helmet = GetHelmet();
            character.Inventory.PickUp(helmet);
            character.Inventory.Equip(helmet);

            var chest = GetChest();
            character.Inventory.PickUp(chest);
            character.Inventory.Equip(chest);

            var gloves = GetGloves();
            character.Inventory.PickUp(gloves);
            character.Inventory.Equip(gloves);

            var boots = GetBoots();
            character.Inventory.PickUp(boots);
            character.Inventory.Equip(boots);

            return character;
        }

        public static Weapon GetSword()
        {
            return new Weapon(
                "Sword",
                SlotType.MainHand,
                new Weight(1),
                new DamageDealt(5, DamageType.Melee),
                new List<IEnhancement<IStatistic>>());
        }

        public static Weapon GetBow()
        {
            return new Weapon(
                "Bow",
                SlotType.MainHand,
                new Weight(1),
                new DamageDealt(5, DamageType.Range),
                new List<IEnhancement<IStatistic>>());
        }

        public static Weapon GetEnhancedWeapon(DamageType damageType)
        {
            return new Weapon(
                "Weapon",
                SlotType.MainHand,
                new Weight(1),
                new DamageDealt(5, damageType),
                new List<IEnhancement<IStatistic>> { new StubTypeEnhancement<MeleeDamage>(10) });
        }

        public static BodyArmor GetEnhancedArmor()
        {
            return new BodyArmor(
                "Chest",
                SlotType.Chest,
                new Weight(1),
                new ArmorValue(1),
                new List<IEnhancement<IStatistic>> { new StubTypeEnhancement<FireResistance>(10) });
        }

        public static Weapon GetWeapon(DamageType damageType)
        {
            return new Weapon(
                "Weapon",
                SlotType.MainHand,
                new Weight(1),
                new DamageDealt(5, damageType),
                new List<IEnhancement<IStatistic>>());
        }

        public static Weapon GetAxe()
        {
            return new Weapon(
                "Axe",
                SlotType.MainHand,
                new Weight(1),
                new DamageDealt(5, DamageType.Melee),
                new List<IEnhancement<IStatistic>>());
        }

        public static BodyArmor GetChest()
        {
            return new BodyArmor(
                "Chest",
                SlotType.Chest,
                new Weight(1),
                new ArmorValue(1),
                new List<IEnhancement<IStatistic>>());
        }

        public static BodyArmor GetBoots()
        {
            return new BodyArmor(
                "Boots",
                SlotType.Boots,
                new Weight(1),
                new ArmorValue(1),
                new List<IEnhancement<IStatistic>>());
        }

        public static BodyArmor GetGloves()
        {
            return new BodyArmor(
                "Gloves",
                SlotType.Gloves,
                new Weight(1),
                new ArmorValue(1),
                new List<IEnhancement<IStatistic>>());
        }

        public static BodyArmor GetHelmet()
        {
            return new BodyArmor(
                "Helmet",
                SlotType.Helmet,
                new Weight(1),
                new ArmorValue(1),
                new List<IEnhancement<IStatistic>>());
        }
    }
}