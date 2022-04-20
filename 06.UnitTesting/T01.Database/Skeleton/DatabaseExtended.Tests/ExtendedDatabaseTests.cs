namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Text;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void Constructor_PositiveTest()
        {
            Person person1 = new Person(371036, "Gosho");
            Person person2 = new Person(371037, "Tosho");
            Database database = new Database(person1, person2);

            Assert.AreEqual(2, database.Count);
        }

        [Test]
        public void Constructor_NegativeTest()
        {
            int id = 371036;

            Person[] people = new Person[17];

            for (int i = 0; i < 17; i++)
            {
                StringBuilder name = new StringBuilder();
                name.Append("Gosho");
                name.Append((char)(i + 1));

                string temp = name.ToString();
                people[i] = new Person(id + i, temp);
            }

            Assert.Throws<ArgumentException>(() => new Database(people));

        }

        [Test]
        public void Add_Method_PositiveTest()
        {
            int id = 371036;

            Person[] people = new Person[14];
            Database database = new Database();

            for (int i = 0; i < 14; i++)
            {
                StringBuilder name = new StringBuilder();
                name.Append("Gosho");
                name.Append((char)(i + 1));

                string temp = name.ToString();
                people[i] = new Person(id + i, temp);
                database.Add(people[i]);

            }

            Assert.AreEqual(14, database.Count);

        }

        [Test]
        public void Add_Method_TooManyPeople_NegativeTest()
        {
            int id = 371036;

            Person[] people = new Person[16];
            Database database = new Database();

            for (int i = 0; i < 16; i++)
            {
                StringBuilder name = new StringBuilder();
                name.Append("Gosho");
                name.Append((char)(i + 1));

                string temp = name.ToString();
                people[i] = new Person(id + i, temp);
                database.Add(people[i]);

            }


            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1, "fxdx")));

        }

        [Test]
        public void Add_Method_SameNames_NegativeTest()
        {
            int id = 371036;

            Person[] people = new Person[15];
            Database database = new Database();

            database.Add(new Person(2, "fxdx"));

            for (int i = 0; i < 14; i++)
            {
                StringBuilder name = new StringBuilder();
                name.Append("Gosho");
                name.Append((char)(i + 1));

                string temp = name.ToString();
                people[i] = new Person(id + i, temp);
                database.Add(people[i]);

            }


            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1, "fxdx")));

        }

        [Test]
        public void Add_Method_SameId_NegativeTest()
        {
            int id = 371036;

            Person[] people = new Person[15];
            Database database = new Database();

            database.Add(new Person(1, "xhamster"));

            for (int i = 0; i < 14; i++)
            {
                StringBuilder name = new StringBuilder();
                name.Append("Gosho");
                name.Append((char)(i + 1));

                string temp = name.ToString();
                people[i] = new Person(id + i, temp);
                database.Add(people[i]);

            }


            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1, "fxdx")));

        }

        [TestCase(0, 0, 0)]
        [TestCase(4, 4, 0)]
        [TestCase(5, 4, 1)]
        public void Remove_Method_PositiveTest(int numberOfPeople, int peopleToRemove, int expectedNumberLeft)
        {
            int id = 371036;

            Person[] people = new Person[numberOfPeople];
            Database database = new Database();

            for (int i = 0; i < numberOfPeople; i++)
            {
                StringBuilder name = new StringBuilder();
                name.Append("Gosho");
                name.Append((char)(i + 1));

                string temp = name.ToString();
                people[i] = new Person(id + i, temp);
                database.Add(people[i]);

            }

            for (int i = 0; i < peopleToRemove; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(expectedNumberLeft, database.Count);
        }

        [TestCase(0, 0)]
        [TestCase(4, 4)]
        public void Remove_Method_RemovedTooMany_NegativeTest(int numberOfPeople, int peopleToRemove)
        {
            int id = 371036;

            Person[] people = new Person[numberOfPeople];
            Database database = new Database();

            for (int i = 0; i < numberOfPeople; i++)
            {
                StringBuilder name = new StringBuilder();
                name.Append("Gosho");
                name.Append((char)(i + 1));

                string temp = name.ToString();
                people[i] = new Person(id + i, temp);
                database.Add(people[i]);

            }

            for (int i = 0; i < peopleToRemove; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FindByUsername_Method_PositiveTest()
        {
            Database database = new Database();

            database.Add(new Person(371036, "Gosho"));

            string name = database.FindByUsername("Gosho").UserName;

            Assert.AreEqual("Gosho", name);
        }

        [Test]
        public void FindByUsername_Method_NotFound_NegativeTest()
        {
            Database database = new Database();

            database.Add(new Person(371036, "Tosho"));

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Gosho"));
        }

        [Test]
        public void FindByUsername_Method_NullOrWhiteSpace_NegativeTest()
        {
            Database database = new Database();

            database.Add(new Person(371036, "Tosho"));

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
        }

        [Test]
        public void FindByID_Method_PositiveTest()
        {
            Database database = new Database();

            database.Add(new Person(371036, "Gosho"));

            long id = database.FindById(371036).Id;

            Assert.AreEqual(371036, id);
        }

        [Test]
        public void FindByID_Method_NotFound_NegativeTest()
        {
            Database database = new Database();

            database.Add(new Person(371036, "Tosho"));

            Assert.Throws<InvalidOperationException>(() => database.FindById(1));
        }

        [Test]
        public void FindByID_Method_NegativeNumber_NegativeTest()
        {
            Database database = new Database();

            database.Add(new Person(371036, "Tosho"));

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }
    }
}