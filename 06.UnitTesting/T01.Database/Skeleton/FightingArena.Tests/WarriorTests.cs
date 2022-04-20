namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void Constructor_ValidData_PositiveTest()
        {
            Warrior warrior = new Warrior("Spartak", 10, 100);

            Assert.AreEqual("Spartak", warrior.Name);
            Assert.AreEqual(10, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);
        }

        [TestCase(" ", 10, 100)]
        [TestCase("", 10, 100)]
        [TestCase(null, 10, 100)]
        [TestCase("Spartak", 0, 100)]
        [TestCase("Spartak", -1, 100)]
        [TestCase("Spartak", 10, -1)]
        public void Constructor_NotValidData_NegativeTest(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        public void Attack_Method_ValidData_PositiveTest()
        {
            Warrior attacker = new Warrior("Ahil", 60, 100);
            Warrior defender = new Warrior("Hector", 10, 100);

            attacker.Attack(defender);

            Assert.AreEqual(40, defender.HP);
            Assert.AreEqual(90, attacker.HP);

            attacker.Attack(defender);

            Assert.AreEqual(0, defender.HP);
            Assert.AreEqual(80, attacker.HP);
        }

        [TestCase(60,20,10,100)]
        [TestCase(60,100,10,20)]
        [TestCase(60,40,50,100)]
        [TestCase(20,40,50,100)]
        public void Attack_Method_NotValidData_NegativeTest(int attackerDamage, int attackerHP, int defenderDamage, int defenderHP)
        {
            Warrior attacker = new Warrior("Ahil", attackerDamage, attackerHP);
            Warrior defender = new Warrior("Hector", defenderDamage, defenderHP);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }
    }
}