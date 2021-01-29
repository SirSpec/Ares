using System;
using System.Collections.Generic;
using System.Linq;
using Ares.GameSystemTest.Stubs;
using Ares.Inventory;
using Ares.Statistics;
using GameSystem;
using GameSystem.Defence;
using GameSystem.Statistics.DerivedStatistics.Offence;
using GameSystem.Statistics.PrimaryStatistics.Defence;
using GameSystem.Weapons;
using Xunit;

namespace Ares.GameSystemTest
{
    public static class TestCharacterFactory
    {
        public static Character GetCharacterWithBodyArmor()
        {
            var character = new Character("JohnDoe");

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

    public class CharacterTest
    {
        [Fact]
        public void IsUnarmed_Default_True()
        {
            //Arrange
            var sut = new Character("JohnDoe");

            //Act
            var result = sut.IsUnarmed;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsUnarmed_EquipedWeapon_False()
        {
            //Arrange
            var sut = new Character("JohnDoe");
            var weapon = TestCharacterFactory.GetSword();
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);

            //Act
            var result = sut.IsUnarmed;

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void SkillPoints_Default_One()
        {
            //Arrange
            var sut = new Character("JohnDoe");

            //Act
            var result = sut.SkillPoints;

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void SkillPoints_LevelUpToThirdLevel_Three()
        {
            //Arrange
            var sut = new Character("JohnDoe");

            //Act
            sut.Experience.Gain(300);
            var result = sut.SkillPoints;

            //Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void SkillPoints_LevelUpTwice_Three()
        {
            //Arrange
            var sut = new Character("JohnDoe");

            //Act
            sut.Experience.Gain(100);
            sut.Experience.Gain(200);
            var result = sut.SkillPoints;

            //Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void IsDead_Default_False()
        {
            //Arrange
            var sut = new Character("JohnDoe");

            //Act
            var result = sut.IsDead;

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsDead_HealthPoolEmpty_True()
        {
            //Arrange
            var sut = new Character("JohnDoe");
            sut.HealthPool.Decrease(sut.HealthPool.Current);

            //Act
            var result = sut.IsDead;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Armor_EquipedBodyArmor_SumOfArmor()
        {
            //Arrange
            var sut = TestCharacterFactory.GetCharacterWithBodyArmor();

            //Act
            var result = sut.StatisticsSet.GetStatistic<Armor>().Value;
            var expected = sut.Inventory.Equipment.EquipedItems
                .Where(item => item is BodyArmor)
                .Sum(item => ((BodyArmor)item).Armor.Value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void MeleeDamage_EquipedWeapon_WeaponDamage()
        {
            //Arrange
            var sut = new Character("JohnDoe");
            var weapon = TestCharacterFactory.GetSword();
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);

            //Act
            var result = sut.StatisticsSet.GetStatistic<MeleeDamage>().Value;

            //Assert
            Assert.Equal(weapon.Damage.Value, result);
        }
    }
}