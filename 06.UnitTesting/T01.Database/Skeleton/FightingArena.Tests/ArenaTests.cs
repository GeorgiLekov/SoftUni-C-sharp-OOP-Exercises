namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void Constructor_PositiveTest()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void Enroll_ValidData_PositiveTest()
        {
            Warrior attacker = new Warrior("Ahil", 60, 100);
            Warrior defender = new Warrior("Hector", 10, 100);

            Arena arena = new Arena();

            arena.Enroll(attacker);
            arena.Enroll(defender);

            Assert.AreEqual(2, arena.Count);
            Assert.AreEqual(2, arena.Warriors.Count);

        }

        [TestCase("Ahil",60,100,"Ahil",60,100)]
        [TestCase("Ahil",10,100,"Ahil",60,100)]
        public void Enroll_NotValidData_NegativeTest(string name, int damage, int hp, string defenderName, int defenderDMG, int defenderHP)
        {
            Warrior attacker = new Warrior(name, damage, hp);
            Warrior defender = new Warrior(defenderName, defenderDMG, defenderHP);

            Arena arena = new Arena();

            arena.Enroll(attacker);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(defender));

        }

        [Test]
        public void Fight_Method_ValidData_PositiveTest()
        {
            Warrior attacker = new Warrior("Ahil", 60, 100);
            Warrior defender = new Warrior("Hector", 10, 100);

            Arena arena = new Arena();

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight("Ahil", "Hector");
        }

        [TestCase("Ahil","Spartak")]
        [TestCase("Spartak", "Ahil")]
        [TestCase("Spartak", "Strahil")]
        public void Fight_Method_NotValidData_NegativeTest(string attackerName, string defenderName)
        {
            Warrior attacker = new Warrior("Ahil", 60, 100);
            Warrior defender = new Warrior("Hector", 10, 100);

            Arena arena = new Arena();

            arena.Enroll(attacker);
            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, defenderName));
        }
    }
}
