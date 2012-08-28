using System;

namespace Temperature
{
    /// <summary>
    /// Simpliefied data object for JSON transport
    /// </summary>
    public class CelsiusCount : IComparable
    {
        public double Celsius { set; get; }
        public int Count { set; get; }

        #region IComparable Members

        // For sorting
        public int CompareTo(object obj)
        {
            var other = obj as CelsiusCount;
            return other != null ? Count.CompareTo(other.Count) : 1;
        }

        #endregion
    }
}