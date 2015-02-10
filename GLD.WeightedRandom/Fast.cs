using System.Collections.Generic;

namespace GLD.WeightedRandom
{
    public class Fast : IRandValue
    {
        public Dictionary<char, string> KeyValues = null;

        public string ValueDistributionRandomized = null;

        private int _curIndex;

        public Fast(Dictionary<char, string> keyValues, string valueDistributionRandomized)
        {
            KeyValues = keyValues;
            ValueDistributionRandomized = valueDistributionRandomized;
        }

        #region IRandValue Members

        public string Status
        {
            get
            {
                _curIndex = _curIndex%ValueDistributionRandomized.Length;
                return KeyValues[ValueDistributionRandomized[_curIndex++]];
            }
        }

        #endregion
    }
}