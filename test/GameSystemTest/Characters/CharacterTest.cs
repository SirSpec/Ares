using Ares.GameSystem;
using Xunit;

namespace Ares.GameSystemTest.Characters
{
    public class CharacterTest
    {
        [Fact]
        public void IsUnarmed_Default_True()
        {
            //Arrange
            var sut = new CharacterFactory().NewCharacter("JohnDoe");

            //Act
            var result = sut.IsUnarmed;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsUnarmed_EquipedWeapon_False()
        {
            //Arrange
            var sut = new CharacterFactory().NewCharacter("JohnDoe");
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
            var sut = new CharacterFactory().NewCharacter("JohnDoe");

            //Act
            var result = sut.SkillPoints;

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void SkillPoints_LevelUpToThirdLevel_Three()
        {
            //Arrange
            var sut = new CharacterFactory().NewCharacter("JohnDoe");

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
            var sut = new CharacterFactory().NewCharacter("JohnDoe");

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
            var sut = new CharacterFactory().NewCharacter("JohnDoe");

            //Act
            var result = sut.IsDead;

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsDead_HealthPoolEmpty_True()
        {
            //Arrange
            var sut = new CharacterFactory().NewCharacter("JohnDoe");
            sut.HealthPool.Decrease(sut.HealthPool.Current);

            //Act
            var result = sut.IsDead;

            //Assert
            Assert.True(result);
        }
    }
}