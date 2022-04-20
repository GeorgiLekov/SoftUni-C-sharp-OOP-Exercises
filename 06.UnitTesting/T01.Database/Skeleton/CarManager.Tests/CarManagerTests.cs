namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void Constructor_PositiveTest_ValidData()
        {
            Car car = new Car("Ford","Fiesta",6.5,60.0);
            Assert.IsNotNull(car);
        }

        [TestCase(null,"Fiesta",6.5,60.0)]
        [TestCase("Ford",null,6.5,60.0)]
        [TestCase("Ford","Fiesta",0,60.0)]
        [TestCase("Ford","Fiesta",-1,60.0)]
        [TestCase("Ford","Fiesta",6.5,-1)]
        [TestCase("Ford","Fiesta",6.5,0)]
        public void Constructor_ShouldThrowException_InvalidData_NegativeTest(string make, string model, double consumption, double capacity)
        {
            
            Assert.Throws<ArgumentException>(() => new Car(make, model, consumption, capacity));
            Assert.Throws<ArgumentException>(() => new Car(make, model, consumption, capacity));
            Assert.Throws<ArgumentException>(() => new Car(make, model, consumption, capacity));
            Assert.Throws<ArgumentException>(() => new Car(make, model, consumption, capacity));
            Assert.Throws<ArgumentException>(() => new Car(make, model, consumption, capacity));
            Assert.Throws<ArgumentException>(() => new Car(make, model, consumption, capacity));

        }

        [TestCase(59,59)]
        [TestCase(100,60)]
        public void Refuel_ValidData_PositiveTest(double amount,double expected)
        {
            Car car = new Car("Ford", "Fiesta", 6.5, 60.0);
            car.Refuel(amount);
            Assert.AreEqual(expected, car.FuelAmount);
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void Refuel_UnvalidData_NegativeTest(double amount)
        {
            Car car = new Car("Ford", "Fiesta", 6.5, 60.0);
            Assert.Throws<ArgumentException>(() => car.Refuel(amount));
        }

        [Test]
        public void Drive_ValidData_PositiveTest()
        {
            Car car = new Car("Ford", "Fiesta", 6.5, 60.0);

            car.Refuel(10);

            car.Drive(100);

            Assert.AreEqual(3.5, car.FuelAmount);
        }

        [Test]
        public void Drive_UnvalidData_NegativeTest()
        {
            Car car = new Car("Ford", "Fiesta", 6.5, 60.0);

            car.Refuel(4);

            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        }

    }
}