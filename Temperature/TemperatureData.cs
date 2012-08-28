
namespace Temperature
{
    public class TemperatureData
    {
        private double Celsius { set; get; }
        private double Farenheit { set; get; }

        /// <summary>
        /// Number of times the Celsius value is requested to be converted
        /// </summary>
        public int Count { set; get; }

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="celsius"></param>
        public TemperatureData(double celsius)
        {
            Celsius = celsius;
            Farenheit = ToFarenheit(celsius);
        }

        /// <summary>
        /// Convert data into a readable string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} C => {1} F requested {2} time{3}.", Celsius, Farenheit, Count,
                (Count > 1) ? "s" : "");
        }

        /// <summary>
        /// Converts this class to a simplified class for web transport
        /// </summary>
        /// <returns>FarenheitCount</returns>
        public FarenheitCount ToFarenheitCount()
        {
            return new FarenheitCount { Count = Count, Farenheit = Farenheit };
        }

        /// <summary>
        /// Converts this class to a simplified class for web transport
        /// </summary>
        /// <returns>CelsiusCount</returns>
        public CelsiusCount ToCelsiusCount()
        {
            return new CelsiusCount {Count = Count, Celsius = Celsius};
        }

        /// <summary>
        /// Convert celcius to Farenheit
        /// </summary>
        /// <param name="celcius"></param>
        /// <returns></returns>
        private static double ToFarenheit(double celcius)
        {
            return (celcius * 9 / 5) + 32;
        }
    }
}
