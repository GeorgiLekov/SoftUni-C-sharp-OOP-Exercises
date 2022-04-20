using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [TestCase("audi", int.MinValue)]
            [TestCase("toyota", int.MaxValue)]
            [TestCase("chevrolet", 15)]
            public void Car_PositiveTest(string carModel, int numberOfIssues)
            {
                Car car = new Car(carModel, numberOfIssues);

                Assert.AreEqual(carModel, car.CarModel);
                Assert.AreEqual(numberOfIssues, car.NumberOfIssues);
                Assert.False(car.IsFixed);
            }

            [TestCase("chevrolet", 0)]
            public void Car_NeutralTest(string carModel, int numberOfIssues)
            {
                Car car = new Car(carModel, numberOfIssues);

                Assert.AreEqual(carModel, car.CarModel);
                Assert.AreEqual(numberOfIssues, car.NumberOfIssues);
                Assert.True(car.IsFixed);
            }

            [TestCase("garag", 100)]
            [TestCase("garg", int.MaxValue)]
            [TestCase("garg", 1)]
            public void Constructor_PositiveTest(string name, int mechanics)
            {
                Garage garage = new Garage(name, mechanics);

                Assert.AreEqual(name, garage.Name);
                Assert.AreEqual(mechanics, garage.MechanicsAvailable);
                Assert.AreNotEqual(null, garage.CarsInGarage);
            }

            [TestCase("",1)]
            [TestCase(null,1)]
            public void Constructor_Name_NegativeTest(string name, int mechanics)
            {
                Assert.Throws<ArgumentNullException>(() => new Garage(name, mechanics));
                ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new Garage(name, mechanics));
                Assert.AreEqual("Invalid garage name. (Parameter 'value')", ex.Message);
            }

            [TestCase("gara", 0)]
            [TestCase("gara", int.MinValue)]
            public void Constructor_Mechanics_NegativeTest(string name, int mechanics)
            {
                Assert.Throws<ArgumentException>(() => new Garage(name, mechanics));

                ArgumentException ex = Assert.Throws<ArgumentException>(() => new Garage(name, mechanics));

                Assert.AreEqual("At least one mechanic must work in the garage.", ex.Message);
            }

            [TestCase("gara", 10)]
            public void Add_Positive(string name, int mechanics)
            {
                Garage garage = new Garage(name, mechanics);

                Car car = new Car("toyota",1);
                Car car1 = new Car("audi",11);

                garage.AddCar(car);
                garage.AddCar(car1);
                garage.AddCar(car);

                Assert.AreEqual(3, garage.CarsInGarage);
            }

            [TestCase("gara", 1)]
            public void Add_NegativeTest(string name, int mechanics)
            {
                Garage garage = new Garage(name, mechanics);

                Car car = new Car("toyota", 1);
                Car car1 = new Car("audi", 11);

                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() => garage.AddCar(car1));
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => garage.AddCar(car1));

                Assert.AreEqual("No mechanic available.", ex.Message);
            }

            [TestCase("gara", 1)]
            public void Add_Null(string name, int mechanics)
            {
                Garage garage = new Garage(name, mechanics);

                Car car = new Car("toyota", 1);
                Car car1 = new Car("audi", 11);

                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() => garage.AddCar(null));
            }

            [TestCase("gara", 1)]
            public void FixCar_Negative(string name, int mechanics)
            {
                Garage garage = new Garage(name, mechanics);

                Car car = new Car("toyota", 1);
                Car car1 = new Car("audi", 11);

                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() => garage.FixCar("audi"));
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => garage.FixCar("audi"));

                Assert.AreEqual("The car audi doesn't exist.", ex.Message);
            }

            [TestCase("gara", 1)]
            public void FixCar_Null(string name, int mechanics)
            {
                Garage garage = new Garage(name, mechanics);

                Car car = new Car("toyota", 1);
                Car car1 = new Car("audi", 11);

                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() => garage.FixCar(null));
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => garage.FixCar(null));

                Assert.AreEqual("The car  doesn't exist.", ex.Message);
            }

            [TestCase("gara", 2)]
            public void FixCar_Positive(string name, int mechanics)
            {
                Garage garage = new Garage(name, mechanics);

                Car car = new Car("toyota", 1);
                Car car1 = new Car("audi", 11);

                garage.AddCar(car);
                garage.AddCar(car1);
                var temp = garage.FixCar("audi");

                Assert.AreEqual(0, temp.NumberOfIssues);
            }

            [TestCase("gara", 2)]
            public void RemoveCar_Negative(string name, int mechanics)
            {
                Garage garage = new Garage(name, mechanics);

                Car car = new Car("toyota", 1);
                Car car1 = new Car("audi", 11);

                garage.AddCar(car);
                garage.AddCar(car1);
                

                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());
                Assert.AreEqual("No fixed cars available.", ex.Message);
            }

            [TestCase("gara", 2)]
            public void RemoveCar_Positive(string name, int mechanics)
            {
                Garage garage = new Garage(name, mechanics);

                Car car = new Car("toyota", 1);
                Car car1 = new Car("audi", 11);

                garage.AddCar(car);
                garage.AddCar(car1);
                garage.FixCar("toyota");
                garage.FixCar("audi");

                int number = garage.RemoveFixedCar();

                Assert.AreEqual(2, number);
                Assert.AreEqual(0, garage.CarsInGarage);

            }

            [TestCase("gara", 2)]
            public void Report_Positive(string name, int mechanics)
            {
                Garage garage = new Garage(name, mechanics);

                Car car = new Car("toyota", 1);
                Car car1 = new Car("audi", 11);

                garage.AddCar(car);
                garage.AddCar(car1);

                string report = garage.Report();

                Assert.AreEqual("There are 2 which are not fixed: toyota, audi.", report);
            }

            [TestCase("gara", 2)]
            public void Report_Negative(string name, int mechanics)
            {
                Garage garage = new Garage(name, mechanics);

                Car car = new Car("toyota", 1);
                Car car1 = new Car("audi", 11);

                garage.AddCar(car);
                garage.AddCar(car1);
                garage.FixCar("toyota");
                garage.FixCar("audi");

                string report = garage.Report();

                Assert.AreEqual("There are 0 which are not fixed: .", report);
            }

            [TestCase("gara", 2)]
            public void Report_Negative2(string name, int mechanics)
            {
                Garage garage = new Garage(name, mechanics);

                string report = garage.Report();

                Assert.AreEqual("There are 0 which are not fixed: .", report);
            }
        }
    }
}