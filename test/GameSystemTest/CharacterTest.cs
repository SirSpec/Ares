using System;
using System.Collections.Generic;
using System.Linq;
using Ares.GameSystemTest.Stubs;
using Ares.Inventory;
using Ares.Statistics;
using GameSystem;
using GameSystem.Defence;
using GameSystem.Statistics.PrimaryStatistics.Defence;
using GameSystem.Weapons;
using Xunit;

namespace Ares.GameSystemTest
{
    public class CharacterTest
    {
        public Weapon GetSword()
        {
            return new Weapon(
                "Sword",
                SlotType.MainHand,
                new Weight(1),
                new DamageDealt(5, DamageType.Melee),
                new List<IEnhancement<IStatistic>>());
        }

        public Weapon GetAxe()
        {
            return new Weapon(
                "Axe",
                SlotType.MainHand,
                new Weight(1),
                new DamageDealt(5, DamageType.Melee),
                new List<IEnhancement<IStatistic>>());
        }

        public BodyArmor GetChest()
        {
            return new BodyArmor(
                "Chest",
                SlotType.Chest,
                new Weight(1),
                new ArmorValue(1),
                new List<IEnhancement<IStatistic>>());
        }

        public BodyArmor GetBoots()
        {
            return new BodyArmor(
                "Boots",
                SlotType.Boots,
                new Weight(1),
                new ArmorValue(1),
                new List<IEnhancement<IStatistic>>());
        }

        public BodyArmor GetGloves()
        {
            return new BodyArmor(
                "Gloves",
                SlotType.Gloves,
                new Weight(1),
                new ArmorValue(1),
                new List<IEnhancement<IStatistic>>());
        }

        public BodyArmor GetHelmet()
        {
            return new BodyArmor(
                "Helmet",
                SlotType.Helmet,
                new Weight(1),
                new ArmorValue(1),
                new List<IEnhancement<IStatistic>>());
        }

        [Fact]
        public void SetBaseValue_Negative_ThrowsArgumentException()
        {
            //Arrange
            var sut = new Character("John");
            var s = GetSword();
            sut.Inventory.PickUp(s);
            sut.Inventory.Equip(s);

            var h = GetHelmet();
            sut.Inventory.PickUp(h);
            sut.Inventory.Equip(h);

            var c = GetChest();
            sut.Inventory.PickUp(c);
            sut.Inventory.Equip(c);

            var g = GetGloves();
            sut.Inventory.PickUp(g);
            sut.Inventory.Equip(g);

            var b = GetBoots();
            sut.Inventory.PickUp(b);
            sut.Inventory.Equip(b);


            //Act
            //Assert
            var orc = new Character("Orc");
            var a = GetAxe();
            orc.Inventory.PickUp(a);
            orc.Inventory.Equip(a);

            var h1 = GetHelmet();
            orc.Inventory.PickUp(h1);
            orc.Inventory.Equip(h1);

            var b1 = GetBoots();
            orc.Inventory.PickUp(b1);
            orc.Inventory.Equip(b1);

            var damage = sut.Attack();
            orc.TakeDamage(damage);
        }
    }
}