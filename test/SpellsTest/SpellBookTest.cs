using Ares.Spells;
using Ares.Spells.Effects;
using System;
using Xunit;

namespace Ares.SpellsTest
{
    public class SpellBookTest
    {
        public class StubEffect : IEffect
        {
            public string Name => throw new NotImplementedException();
        }

        private Spell TestSpell => new Spell("Test", new StubEffect(), 1);

        [Fact]
        public void Add_Spell_ContainsSpell()
        {
            //Arrange
            var sut = new SpellBook();
            var testSpell = TestSpell;

            //Act
            sut.Add(testSpell);

            //Assert
            Assert.Contains(testSpell, sut.Spells);
        }

        [Fact]
        public void Add_ExistingSpell_ThrowsInvalidOperationException()
        {
            //Arrange
            var sut = new SpellBook();
            var testSpell = TestSpell;

            //Act
            sut.Add(testSpell);
            Action action = () => sut.Add(testSpell);

            //Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void Contains_ExistingSpell_True()
        {
            //Arrange
            var sut = new SpellBook();
            var testSpell = TestSpell;

            //Act
            sut.Add(testSpell);
            var result = sut.Contains(testSpell);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Contains_NonExistingSpell_False()
        {
            //Arrange
            var sut = new SpellBook();
            var testSpell = TestSpell;

            //Act
            var result = sut.Contains(testSpell);

            //Assert
            Assert.False(result);
        }
    }
}