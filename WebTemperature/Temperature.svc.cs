using System;
using System.Collections.Generic;
using Temperature;

namespace WebTemperature
{
    public class Temperature : ITemperature
    {
        /// <summary>
        /// Returns a JSON with Farenheit conversion and the number of times queried for the Celsius value
        /// </summary>
        /// <example>
        /// {
        /// "QueryResult":{
        ///     "Count":1,
        ///     "Farenheit":32
        ///  }
        /// }
        /// </example>
        /// <param name="celsius"></param>
        /// <returns></returns>
        public FarenheitCount Query(string celsius)
        {
            // throw exception if celsius cannot be converted to a double
            double dCelcius = Double.Parse(celsius);
            return Converter.Query(dCelcius);
        }

        /// <summary>
        /// Returns an array of Celsius temperature and number of times queried. The order is from least querried to most querried.
        /// <example>
        /// {
        /// "QueryAllResult":[
        ///  {
        ///          "Celsius":0,
        ///          "Count":1
        ///  },
        ///  {
        ///          "Celsius":4,
        ///          "Count":2
        /// },
        /// {
        ///          "Celsius":3,
        ///           "Count":3
        /// }
        /// ]
        ///}
        /// </example>
        /// </summary>
        /// <returns></returns>
        public CelsiusCount[] QueryAll()
        {
            return Converter.Query();
        }
    }
}
