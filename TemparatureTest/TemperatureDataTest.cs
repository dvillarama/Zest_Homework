using Microsoft.VisualStudio.TestTools.UnitTesting;
using Temperature;

namespace TemparatureTest
{
    [TestClass]
    public class TemperatureDataTest
    {
        [TestMethod]
        public void TemperatureData_Zero()
        {
            var tData = new TemperatureData(0);
            var expected = "0 C => 32 F requested 0 time.";
            var actual = tData.ToString();
            Assert.AreEqual(expected, actual, "Zero Celius is 32 Farenheit");
        }

        [TestMethod]
        public void TemperatureData_Negative()
        {
            var tData = new TemperatureData(-20);
            var expected = "-20 C => -4 F requested 0 time.";
            var actual = tData.ToString();
            Assert.AreEqual(expected, actual, "-20 Celius is -4 Farenheit");
        }

        [TestMethod]
        public void TemperatureData_Positive()
        {
            var tData = new TemperatureData(54.44);
            var expected = "54.44 C => 129.992 F requested 0 time.";
            var actual = tData.ToString();
            Assert.AreEqual(expected, actual, "54.44 Celius is around 130 Farenheit.  Medium rare.");
        }

        [TestMethod]
        public void ToFarenheitCount()
        {
            var tData = new TemperatureData(54.44);
            var actual = tData.ToFarenheitCount();
            Assert.AreEqual(actual.Count, 0, "Just constructed so count should be zero.");
            Assert.AreEqual(actual.Farenheit, 129.992, "Celsius should be converted to the ~130 Farenheit.");
        }

        [TestMethod]
        public void ToCelsiusCount()
        {
            var tData = new TemperatureData(54.44);
            var actual = tData.ToCelsiusCount();
            Assert.AreEqual(actual.Count, 0, "Just constructed so count should be zero.");
            Assert.AreEqual(actual.Celsius, 54.44, "Celsius should be the same as passed in the constructor.");
        }

    }
}
