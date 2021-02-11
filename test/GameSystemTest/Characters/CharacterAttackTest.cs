using Ares.GameSystem;
using Ares.GameSystem.Statistics.DerivedStatistics.Offence;
using Ares.GameSystem.Weapons;
using Xunit;

namespace Ares.GameSystemTest.Characters
{
    public class CharacterAttackTest
    {
        [Fact]
        public void Attack_Unarmed_DamageEqualsMeleeDamage()
        {
            //Arrange
            var sut = new CharacterFactory().NewCharacter("JohnDoe");

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
            var sut = new CharacterFactory().NewCharacter("JohnDoe");
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
            var sut = new CharacterFactory().NewCharacter("JohnDoe");
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
            var sut = new CharacterFactory().NewCharacter("JohnDoe");
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
            var sut = new CharacterFactory().NewCharacter("JohnDoe");
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
            var sut = new CharacterFactory().NewCharacter("JohnDoe");
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
            var sut = new CharacterFactory().NewCharacter("JohnDoe");
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