namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [TestCase(new int[0])]
        public void Constructor_PositiveTest(int[] input)
        {
            Database database = new Database(input);
            Assert.AreEqual(input.Length, database.Count);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Constructor_NegativeTest(int[] input)
        {
            Database database = new Database(input);
            Assert.Throws<InvalidOperationException>(() => database.Add(0));
        }

        [TestCase(
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, },
            15)]
        public void AddMethod_PositiveTest(int[] input, int expected)
        {
            Database database = new Database();
            foreach (var item in input)
            {
                database.Add(item);
            }

            Assert.AreEqual(expected, database.Count);
        }

        [TestCase(
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddMethod_NegativeTest(int[] input)
        {
            Database database = new Database();
            foreach (var item in input)
            {
                database.Add(item);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(0));
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 4, 0)]
        [TestCase(new int[0], 0, 0)]

        public void RemoveMethod_PositiveTest(int[] input, int remove, int expected)
        {
            Database database = new Database(input);

            for (int i = 0; i < remove; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(expected, database.Count);
        }

        [TestCase(new int[0], 0)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        public void RemoveMethod_NegativeTest(int[] input, int remove)
        {
            Database database = new Database(input);

            for (int i = 0; i < remove; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [TestCase(new int[] { 1,2,3,4})]
        [TestCase(new int[0])]
        public void FetchMethod_PositiveTest(int[] input)
        {
            Database database = new Database(input);
            int[] result = database.Fetch();

            Assert.AreEqual(database.Count, result.Length);
        }
    }
}
