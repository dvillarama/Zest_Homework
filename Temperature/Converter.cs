
namespace Temperature
{
    public class Converter
    {
        /// <summary>
        /// Static storage of all queried temperatures.
        /// </summary>
        private static readonly IStorage _iStorage = new InMemoryStorage();

        /// <summary>
        /// Return a string containing the Farenheit conversion and the number of times it was requested.
        /// </summary>
        /// <param name="celcius"></param>
        /// <returns></returns>
        public static FarenheitCount Query(double celcius)
        {
            return _iStorage.Query(celcius);
        }

        /// <summary>
        /// Return a summary of conversions
        /// </summary>
        /// <returns></returns>
        public static CelsiusCount[] Query()
        {
            return _iStorage.QueryAll();
        }
    }
}
