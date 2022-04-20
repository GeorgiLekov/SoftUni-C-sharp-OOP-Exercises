using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(int.MaxValue)]
       public void Constructor_ValidData(int capacity)
        {
            Shop shop = new Shop(capacity);

            Assert.AreEqual(capacity, shop.Capacity);
        }

        [TestCase(-1)]
        [TestCase(int.MinValue)]

        public void Constructor_InvalidData(int capacity) 
        { 
            Assert.Throws<ArgumentException>(() => new Shop(capacity));
        }

        [Test]
        public void Add_NegativeTests()
        {
            Smartphone smartphone = new Smartphone("Samsun", 100);
            Smartphone smartphone2 = new Smartphone("Samsun", 100);

            Shop shop = new Shop(3);

            shop.Add(smartphone);

            InvalidOperationException ex = Assert.Throws< InvalidOperationException > (() => shop.Add(smartphone2));

            Assert.AreEqual($"The phone model {smartphone2.ModelName} already exist.", ex.Message);
        }
        [Test]
        public void Add_NegativeTests_FullShop()
        {
            Smartphone smartphone = new Smartphone("Samsun", 100);
            Smartphone smartphone2 = new Smartphone("Nokia", 100);

            Shop shop = new Shop(1);

            shop.Add(smartphone);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone2));

            Assert.AreEqual("The shop is full.", ex.Message);
        }

        [Test]
        public void Add_PositiveTest()
        {
            Smartphone smartphone = new Smartphone("Samsun", 100);
            Smartphone smartphone2 = new Smartphone("Nokia", 100);

            Shop shop = new Shop(2);

            shop.Add(smartphone);
            shop.Add(smartphone2);

            Assert.AreEqual(2, shop.Count);
        }

        [Test]
        public void Remove_PositiveTest()
        {
            Smartphone smartphone = new Smartphone("Samsun", 100);
            Smartphone smartphone2 = new Smartphone("Nokia", 100);

            Shop shop = new Shop(5);

            shop.Add(smartphone);
            shop.Add(smartphone2);

            shop.Remove("Samsun");
            shop.Remove("Nokia");

            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void Remove_NegativeTest()
        {
            Smartphone smartphone = new Smartphone("Samsun", 100);
            Smartphone smartphone2 = new Smartphone("Nokia", 100);

            Shop shop = new Shop(5);

            shop.Add(smartphone);
            shop.Add(smartphone2);

            shop.Remove("Samsun");
          
            Assert.Throws<InvalidOperationException>(() => shop.Remove("Samsung"));
        }

        [Test]
        public void TestPhone_PositiveTest()
        {
            Smartphone smartphone = new Smartphone("Samsun", 100);
            Smartphone smartphone2 = new Smartphone("Nokia", 100);

            Shop shop = new Shop(5);

            shop.Add(smartphone);
            shop.Add(smartphone2);

            shop.TestPhone("Samsun", 10);

            Assert.AreEqual(90, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void TestPhone_NotFound()
        {
            Smartphone smartphone = new Smartphone("Samsun", 100);
            Smartphone smartphone2 = new Smartphone("Nokia", 100);

            Shop shop = new Shop(5);

            shop.Add(smartphone);
            shop.Add(smartphone2);

            
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Nqma me",100));

            Assert.AreEqual($"The phone model {"Nqma me"} doesn't exist.", ex.Message);
        }

        [Test]
        public void TestPhone_NotEnoughCharge()
        {
            Smartphone smartphone = new Smartphone("Samsun", 100);
            Smartphone smartphone2 = new Smartphone("Nokia", 100);

            Shop shop = new Shop(5);

            shop.Add(smartphone);
            shop.Add(smartphone2);


            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Samsun", 200));

            Assert.AreEqual($"The phone model {smartphone.ModelName} is low on batery.", ex.Message);
        }

        [Test]
        public void ChargePhone_NegativeTest()
        {
            Smartphone smartphone = new Smartphone("Samsun", 100);
            Smartphone smartphone2 = new Smartphone("Teal", 100);

            Shop shop = new Shop(3);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Red"));
        }

        [Test]
        public void ChargePhone_PositiveTest()
        {
            Smartphone smartphone = new Smartphone("Samsun", 100);
            Smartphone smartphone2 = new Smartphone("Teal", 100);

            Shop shop = new Shop(3);

            shop.Add(smartphone);
            shop.Add(smartphone2);

            shop.TestPhone("Teal", 50);

            shop.ChargePhone("Teal");

            Assert.AreEqual(smartphone2.MaximumBatteryCharge, smartphone2.CurrentBateryCharge);


        }
    }
}