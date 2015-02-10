using System;
using System.Collections.Generic;

namespace GLD.WeightedRandom
{
    public class Simple : IRandValue
    {
        private static readonly Random Rand = new Random();

        public Dictionary<char, string> KeyValues = null;

        public string ValueDistribution = null;

        public Simple(Dictionary<char, string> keyValues, string valueDistribution)
        {
            KeyValues = keyValues;
            ValueDistribution = valueDistribution;
        }

        #region IRandValue Members

        public string Status
        {
            get { return KeyValues[ValueDistribution[Rand.Next(0, ValueDistribution.Length)]]; }
        }

        #endregion
    }
}