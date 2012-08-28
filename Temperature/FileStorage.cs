using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Temperature
{
    internal class FileStorage : IStorage
    {
        private Dictionary<double, int> _currentStorage;
        private readonly object _lockObject = new object();
        private const string DATAFILE = "datafile.csv";

        private Dictionary<double, int> Data
        {
            get
            {
                lock (_lockObject)
                {
                    return _currentStorage ?? (_currentStorage = ProcessFile(DATAFILE));
                }
            }
        }

        private Dictionary<double, int> ProcessFile(string filename)
        {
            if (!File.Exists(filename))
                return new Dictionary<double, int>();

            try
            {
                using (var sr = new StreamReader(filename))
                {
                    return ProcessStream(sr);
                }
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Error opening file: {0}", filename), e);
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
             foreach (var keyPair in Data)
             {
                 builder.AppendFormat("{0}{1}",string.Join(",", keyPair.Key, keyPair.Value), Environment.NewLine);
             }
            return builder.ToString();
        }

        private void SaveToFile()
        {
            File.WriteAllText(DATAFILE, ToString());
        }

        internal void Save(double celsius)
        {
            lock (_lockObject)
            {
                if (!Data.ContainsKey(celsius))
                {
                    Data.Add(celsius, 1);
                }
                else
                {
                    Data[celsius] = Data[celsius]++;
                }
            }

            SaveToFile();
        }

        internal static Dictionary<double, int> ProcessStream(StreamReader reader)
        {
            string line;
            var dataDictionary = new Dictionary<double, int>();
            while ((line = reader.ReadLine()) != null)
            {
                try
                {
                    var pair = line.Split(',');
                    dataDictionary.Add(Double.Parse(pair[0]), Int32.Parse(pair[1]));
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(string.Format("Bad line:'{0}': Ex:{1}", line, ex.Message));
                }
            }
            return dataDictionary;
        }




        #region IStorage Members

        public string Query(double celsius)
        {
            throw new NotImplementedException();
        }

        public string Query()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
