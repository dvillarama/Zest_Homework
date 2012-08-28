using System.Collections.Generic;

namespace Temperature
{
    public class InMemoryStorage : IStorage
    {
        private readonly Dictionary<double, TemperatureData> _currentStorage = new Dictionary<double, TemperatureData>();
        private readonly object _lockObject = new object();

        #region IStorage Members

        /// <summary>
        /// Return a string containing the Farenheit conversion and the number of times it was requested.
        /// Insert into storage if this is the first time this value is requested.
        /// Update the requested count.
        /// </summary>
        /// <param name="celcius"></param>
        /// <returns></returns>
        public FarenheitCount Query(double celsius)
        {
            TemperatureData tData;

            lock (_lockObject)
            {
                if (!_currentStorage.ContainsKey(celsius))
                {
                    tData = new TemperatureData(celsius);
                    _currentStorage[celsius] = tData;
                }
                else
                {
                    tData = _currentStorage[celsius];
                }

                tData.Count++;
            }

            return tData.ToFarenheitCount();
        }

        /// <summary>
        /// Return an array of strings composed of queried temperatures
        /// </summary>
        /// <returns></returns>
        public CelsiusCount[] QueryAll()
        {
            var dataList = new List<CelsiusCount>();
            lock (_lockObject)
            {
                foreach (var tData in _currentStorage.Values)
                {
                    dataList.Add(tData.ToCelsiusCount());
                }
            }
            dataList.Sort();
            return dataList.ToArray();
        }
        #endregion
    }
}
