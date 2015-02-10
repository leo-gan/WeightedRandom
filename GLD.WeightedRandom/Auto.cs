using System;
using System.Collections.Generic;
using System.Text;

namespace GLD.WeightedRandom
{
    public class Auto : IRandValue
    {
        private static readonly Random Rand = new Random();

        private readonly Dictionary<char, string> KeyValues =
            new Dictionary<char, string>();

        public readonly string ValueDistribution;
        private int _curIndex;

        public Auto(Dictionary<string, int> valueWeights)
        {
            int i = 0;
            var sb = new StringBuilder();
            foreach (var statusWithWeight in valueWeights)
            {
                var curKey = (char) (48 + i++);
                KeyValues.Add(curKey, statusWithWeight.Key);
                sb.Append(new string(curKey, statusWithWeight.Value));
            }
            ValueDistribution = Randomize(sb.ToString());
        }

        #region IRandValue Members

        public string Status
        {
            get
            {
                _curIndex = _curIndex%ValueDistribution.Length;
                return KeyValues[ValueDistribution[_curIndex++]];
            }
        }

        #endregion

        private static string Randomize(string source)
        {
            char[] array = source.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                int position1 = Rand.Next(0, source.Length);
                int position2 = Rand.Next(0, source.Length);
                char temp = array[position1];
                array[position1] = array[position2];
                array[position2] = temp;
            }
            //Console.WriteLine(new string(array));
            return new string(array);
        }
    }
}