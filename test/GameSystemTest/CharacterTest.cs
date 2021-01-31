using System.Collections.Generic;
using System.Linq;
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

        public static Weapon GetBow()
        {
            return new Weapon(
                "Bow",
                SlotType.MainHand,
                new Weight(1),
                new DamageDealt(5, DamageType.Range),
                new List<IEnhancement<IStatistic>>());
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
            var sut = new Character("JohnDoe");
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
            var sut = new Character("JohnDoe");
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
            var sut = new Character("JohnDoe");
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
            var sut = new Character("JohnDoe");
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
            var sut = new Character("JohnDoe");
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
            var sut = new Character("JohnDoe");
            var weapon = TestCharacterFactory.GetSword();
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);

            //Act
            var newWeapon = TestCharacterFactory.GetBow();
            sut.Inventory.PickUp(newWeapon);
            sut.Inventory.Equip(newWeapon);
            var result1 = sut.StatisticsSet.GetStatistic<MeleeDamage>().Value;
            var result2 = sut.StatisticsSet.GetStatistic<RangeDamage>().Value;

            //Assert
            Assert.Equal(0, result1);
            Assert.Equal(newWeapon.Damage.Value, result2);
        }

        [Fact]
        public void Equip_ReplaceEquipedItem_ItemPutBackToBackpack()
        {
            //Arrange
            var sut = new Character("JohnDoe");
            var weapon = TestCharacterFactory.GetSword();
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);

            //Act
            var newWeapon = TestCharacterFactory.GetBow();
            sut.Inventory.PickUp(newWeapon);
            sut.Inventory.Equip(newWeapon);
            var result = sut.Inventory.Backpack.Items;

            //Assert
            Assert.Single(result);
            Assert.Equal(weapon, result.First());
        }

        [Fact]
        public void Attack_Unarmed_DamageEqualsMeleeDamage()
        {
            //Arrange
            var sut = new Character("JohnDoe");

            //Act
            var result = sut.Attack();
            var unarmedDamage = sut.StatisticsSet.GetStatistic<MeleeDamage>();

            //Assert
            Assert.Equal(DamageType.Melee, result.Type);
            Assert.Equal(unarmedDamage.Value, result.Value);
        }

        [Fact]
        public void Attack_EquipedWeapon_DamageAdjustedByWeaponDamage()
        {
            //Arrange
            var sut = new Character("JohnDoe");
            var weapon = TestCharacterFactory.GetSword();
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);

            //Act
            var result = sut.Attack();

            //Assert
            Assert.Equal(weapon.Damage.Type, result.Type);
            Assert.Equal(weapon.Damage.Value, result.Value);
        }

        [Fact]
        public void Attack_EquipedRangeWeapon_RangeDamage()
        {
            //Arrange
            var sut = new Character("JohnDoe");
            var weapon = TestCharacterFactory.GetBow();
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);

            //Act
            var result = sut.Attack();
            var rangeDamage = sut.StatisticsSet.GetStatistic<RangeDamage>();

            //Assert
            Assert.Equal(weapon.Damage.Type, result.Type);
            Assert.Equal(rangeDamage.Value, result.Value);
        }

        [Fact]
        public void Attack_EquipedFireWeapon_FireDamage()
        {
            //Arrange
            var sut = new Character("JohnDoe");
            var weapon = TestCharacterFactory.GetWeapon(DamageType.Fire);
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);

            //Act
            var result = sut.Attack();
            var damage = sut.StatisticsSet.GetStatistic<FireDamage>();

            //Assert
            Assert.Equal(weapon.Damage.Type, result.Type);
            Assert.Equal(damage.Value, result.Value);
        }

        [Fact]
        public void Attack_EquipedIceWeapon_IceDamage()
        {
            //Arrange
            var sut = new Character("JohnDoe");
            var weapon = TestCharacterFactory.GetWeapon(DamageType.Ice);
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);

            //Act
            var result = sut.Attack();
            var damage = sut.StatisticsSet.GetStatistic<IceDamage>();

            //Assert
            Assert.Equal(weapon.Damage.Type, result.Type);
            Assert.Equal(damage.Value, result.Value);
        }

        [Fact]
        public void Attack_EquipedLightningWeapon_LightningDamage()
        {
            //Arrange
            var sut = new Character("JohnDoe");
            var weapon = TestCharacterFactory.GetWeapon(DamageType.Lightning);
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);

            //Act
            var result = sut.Attack();
            var damage = sut.StatisticsSet.GetStatistic<LightningDamage>();

            //Assert
            Assert.Equal(weapon.Damage.Type, result.Type);
            Assert.Equal(damage.Value, result.Value);
        }

        [Fact]
        public void Attack_EquipedMeleeWeapon_OtherDamageTypesZeroValue()
        {
            //Arrange
            var sut = new Character("JohnDoe");
            var weapon = TestCharacterFactory.GetSword();
            sut.Inventory.PickUp(weapon);
            sut.Inventory.Equip(weapon);

            //Act
            var rangeDamage = sut.StatisticsSet.GetStatistic<RangeDamage>().Value;
            var fireDamage = sut.StatisticsSet.GetStatistic<FireDamage>().Value;
            var iceDamage = sut.StatisticsSet.GetStatistic<IceDamage>().Value;
            var lightningDamage = sut.StatisticsSet.GetStatistic<LightningDamage>().Value;

            //Assert
            Assert.Equal(0, rangeDamage);
            Assert.Equal(0, fireDamage);
            Assert.Equal(0, iceDamage);
            Assert.Equal(0, lightningDamage);
        }

        [Fact]
        public void TakeDamage_ArmorBiggerThanDamage_HealthDroppedByOne()
        {
            //Arrange
            var sut = TestCharacterFactory.GetCharacterWithBodyArmor();
            var damage = new DamageDealt(1, DamageType.Melee);
            var expected = sut.HealthPool.Current - 1;

            //Act
            sut.TakeDamage(damage);
            var result = sut.HealthPool.Current;

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TakeDamage_MeleeDamageReducedByArmor_ReducedDamageTaken()
        {
            //Arrange
            var sut = TestCharacterFactory.GetCharacterWithBodyArmor();
            var damage = new DamageDealt(5, DamageType.Melee);

            //Act
            sut.TakeDamage(damage);
            var result = sut.HealthPool.Current;

            //Assert
            Assert.Equal(9, result);
        }
    }
}