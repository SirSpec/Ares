using System.Linq;
using Ares.GameSystem;
using Ares.GameSystem.Defence;
using Ares.GameSystem.Statistics.DerivedStatistics.Offence;
using Ares.GameSystem.Statistics.PrimaryStatistics.Defence;
using Ares.GameSystem.Weapons;
using Xunit;

namespace Ares.GameSystemTest.Characters
{
    public class CharacterStatisticsTest
    {
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
        public void Armor_ReplacedBodyArmor_SumOfArmor()
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
            var sut = new CharacterFactory().NewCharacter("JohnDoe");
            var weapon = TestCharacterFactory.GetSword();
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);

            //Act
            var result = sut.StatisticsSet.GetStatistic<MeleeDamage>().Value;

            //Assert
            Assert.Equal(weapon.Damage.Value, result);
        }

        [Fact]
        public void RangeDamage_EquipedWeapon_WeaponDamage()
        {
            //Arrange
            var sut = new CharacterFactory().NewCharacter("JohnDoe");
            var weapon = TestCharacterFactory.GetWeapon(DamageType.Range);
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);

            //Act
            var result = sut.StatisticsSet.GetStatistic<RangeDamage>().Value;

            //Assert
            Assert.Equal(weapon.Damage.Value, result);
        }

        [Fact]
        public void FireDamage_EquipedWeapon_WeaponDamage()
        {
            //Arrange
            var sut = new CharacterFactory().NewCharacter("JohnDoe");
            var weapon = TestCharacterFactory.GetWeapon(DamageType.Fire);
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);

            //Act
            var result = sut.StatisticsSet.GetStatistic<FireDamage>().Value;

            //Assert
            Assert.Equal(weapon.Damage.Value, result);
        }

        [Fact]
        public void IceDamage_EquipedWeapon_WeaponDamage()
        {
            //Arrange
            var sut = new CharacterFactory().NewCharacter("JohnDoe");
            var weapon = TestCharacterFactory.GetWeapon(DamageType.Ice);
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);

            //Act
            var result = sut.StatisticsSet.GetStatistic<IceDamage>().Value;

            //Assert
            Assert.Equal(weapon.Damage.Value, result);
        }

        [Fact]
        public void LightningDamage_EquipedWeapon_WeaponDamage()
        {
            //Arrange
            var sut = new CharacterFactory().NewCharacter("JohnDoe");
            var weapon = TestCharacterFactory.GetWeapon(DamageType.Lightning);
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);

            //Act
            var result = sut.StatisticsSet.GetStatistic<LightningDamage>().Value;

            //Assert
            Assert.Equal(weapon.Damage.Value, result);
        }

        [Fact]
        public void Damage_ReplaceEquipedWeapon_NewWeaponDamageAndType()
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
            var result1 = sut.StatisticsSet.GetStatistic<MeleeDamage>().Value;
            var result2 = sut.StatisticsSet.GetStatistic<RangeDamage>().Value;

            //Assert
            Assert.Equal(0, result1);
            Assert.Equal(newWeapon.Damage.Value, result2);
        }
    }
}