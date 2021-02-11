using System.Linq;
using Ares.GameSystem;
using Ares.GameSystem.Statistics.DerivedStatistics.Offence;
using Ares.GameSystem.Statistics.PrimaryStatistics.Defence;
using Ares.GameSystem.Weapons;
using Xunit;

namespace Ares.GameSystemTest.Characters
{
    public class CharacterEquipTest
    {
        [Fact]
        public void Equip_ReplaceEquipedItem_ItemPutBackToBackpack()
        {
            //Arrange
            var sut = new CharacterFactory().NewCharacter("JohnDoe");
            var weapon = TestCharacterFactory.GetSword();
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);

            //Act
            var newWeapon = TestCharacterFactory.GetBow();
            sut.Inventory.Equipment.Unequip(weapon);
            sut.Inventory.PickUp(newWeapon);
            sut.Inventory.Equip(newWeapon);
            var result = sut.Inventory.Backpack.Items;

            //Assert
            Assert.Single(result);
            Assert.Equal(weapon, result.First());
        }

        [Fact]
        public void Equip_EnhancedWeapon_StatisticEnhanced()
        {
            //Arrange
            var sut = new CharacterFactory().NewCharacter("JohnDoe");
            var weapon = TestCharacterFactory.GetEnhancedWeapon(DamageType.Melee);
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);

            //Act
            var result = sut.StatisticsSet.GetStatistic<MeleeDamage>().Value;
            var expected = weapon.Damage.Value + weapon.Enhancements.First().Enhance(0);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Equip_MultipleEnhancedWeapons_MultipleStatisticsEnhanced()
        {
            //Arrange
            var sut = new CharacterFactory().NewCharacter("JohnDoe");
            var weapon = TestCharacterFactory.GetEnhancedWeapon(DamageType.Melee);
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);
            var armor = TestCharacterFactory.GetEnhancedArmor();
            sut.Inventory.PickUp(armor);
            sut.Inventory.Equip(armor);

            //Act
            var result1 = sut.StatisticsSet.GetStatistic<MeleeDamage>().Value;
            var expected1 = weapon.Damage.Value + weapon.Enhancements.First().Enhance(0);
            var result2 = sut.StatisticsSet.GetStatistic<FireResistance>().Value;
            var expected2 = armor.Enhancements.First().Enhance(0);

            //Assert
            Assert.Equal(expected1, result1);
            Assert.Equal(expected2, result2);
        }

        [Fact]
        public void Unequip_MultipleEnhancedWeapons_DefaultStatistics()
        {
            //Arrange
            var sut = new CharacterFactory().NewCharacter("JohnDoe");
            var weapon = TestCharacterFactory.GetEnhancedWeapon(DamageType.Melee);
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);
            var armor = TestCharacterFactory.GetEnhancedArmor();
            sut.Inventory.PickUp(armor);
            sut.Inventory.Equip(armor);
            sut.Inventory.Equipment.Unequip(weapon);
            sut.Inventory.Equipment.Unequip(armor);

            //Act
            var result1 = sut.StatisticsSet.GetStatistic<MeleeDamage>().Value;
            var result2 = sut.StatisticsSet.GetStatistic<FireResistance>().Value;

            //Assert
            Assert.Equal(0, result1);
            Assert.Equal(0, result2);
        }
    }
}