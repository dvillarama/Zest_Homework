using Microsoft.VisualStudio.TestTools.UnitTesting;
using Temperature;

namespace TemparatureTest
{
    [TestClass]
    public class InMemoryStorageTest
    {
        [TestMethod]
        public void Query_First()
        {
            IStorage storage = new InMemoryStorage();
            var actual = storage.Query(0);
            Assert.AreEqual(1, actual.Count, "First query should report a count of 1.");
            Assert.AreEqual(32, actual.Farenheit, "0 Celsius should be 32 F");
        }

        [TestMethod]
        public void Query_SecondTime()
        {
            IStorage storage = new InMemoryStorage();
            storage.Query(0);
            var actual = storage.Query(0);
            Assert.AreEqual(2, actual.Count, "First query should report a count of 2.");
            Assert.AreEqual(32, actual.Farenheit, "0 Celsius should be 32 F");
        }

        [TestMethod]
        public void Query_NoValues()
        {
            IStorage storage = new InMemoryStorage();
            var actual = storage.QueryAll();
            Assert.AreEqual(0, actual.Length, "Should be empty at the start.");
        }

        [TestMethod]
        public void Query_OneValue()
        {
            IStorage storage = new InMemoryStorage();

            storage.Query(0);
            var actual = storage.QueryAll();
            Assert.AreEqual(1, actual.Length, "One query should report one item.");
            Assert.AreEqual(1, actual[0].Count, "0 C should have been querried once.");
        }

        [TestMethod]
        public void Query_ManyValues()
        {
            IStorage storage = new InMemoryStorage();

            storage.Query(0);
            storage.Query(0);
            storage.Query(3);
            storage.Query(3);
            storage.Query(3);
            storage.Query(1);

            var actual = storage.QueryAll();
            // sorted from lowest to highest
            Assert.AreEqual(3, actual.Length, "Should contain 3 unique quierries.");
            Assert.AreEqual(1, actual[0].Count, "0 C should have been querried twice.");
            Assert.AreEqual(2, actual[1].Count, "1 C should have been querried once.");
            Assert.AreEqual(3, actual[2].Count, "3 C should have been querried three times.");
        }
    }
}
