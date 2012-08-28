using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Temperature;

namespace TemparatureTest
{
    [TestClass]
    public class CelciusCountTest
    {
        [TestMethod]
        public void CompareTo_Equal()
        {
            var celciusCount1 = new CelsiusCount  {Count = 10};
            var celciusCount2 = new CelsiusCount { Count = 10};
            Assert.AreEqual(0, celciusCount1.CompareTo(celciusCount2), "Same count should return 0.");
        }

        [TestMethod]
        public void CompareTo_LessThan()
        {
            var celciusCount1 = new CelsiusCount { Count = 0 };
            var celciusCount2 = new CelsiusCount { Count = 10 };
            Assert.AreEqual(-1, celciusCount1.CompareTo(celciusCount2), "2nd one is greater than the first one");
        }

        [TestMethod]
        public void CompareTo_GreaterThan()
        {
            var celciusCount1 = new CelsiusCount { Count = 30 };
            var celciusCount2 = new CelsiusCount { Count = 10 };
            Assert.AreEqual(1, celciusCount1.CompareTo(celciusCount2), "1st one is greater than the second one");
        }

        [TestMethod]
        public void CompareTo_Null()
        {
            var celciusCount1 = new CelsiusCount { Count = 30 };
            Assert.AreEqual(1, celciusCount1.CompareTo(new Object()), "1st one is greater than the second one");
        }
    }
}
