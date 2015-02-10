using System;
using System.Collections.Generic;
using System.Diagnostics;
using GLD.WeightedRandom;

namespace WeightedRandom
{
    internal class Program
    {
        private const string ValueDistribution =
            "122333444455555666666777777788888888999999999AAAAAAAAAABBBBBBBBBBB";

        private const string ValueDistributionRandomized =
            "8B956A78997BB48A627A59B35976A4B9BA76BA848A3285B6B9977863A14AA8B59B";

        private static readonly Dictionary<char, string> KeyValues = new Dictionary
            <char, string>
        {
            {'1', "Sent"},
            {'2', "Received"},
            {'3', "Failed"},
            {'4', "Rejected"},
            {'5', "Suspended"},
            {'6', "Filtered"},
            {'7', "InProcess"},
            {'8', "Validated"},
            {'9', "Validating"},
            {'A', "Canceled"},
            {'B', "Completed"}
        };

        private static readonly Dictionary<string, int> ValueWeights = new Dictionary
            <string, int>
        {
            {"Sent", 1},
            {"Received", 2},
            {"Failed", 3},
            {"Rejected", 4},
            {"Suspended", 5},
            {"Filtered", 6},
            {"InProcess", 7},
            {"Validated", 8},
            {"Validating", 9},
            {"Canceled", 10},
            {"Completed", 11}
        };

        private static void Main(string[] args)
        {
            int cylcles = Convert.ToInt32(args[0]);

            Test(cylcles, new Simple(KeyValues, ValueDistribution));
            Test(cylcles, new Fast(KeyValues, ValueDistributionRandomized));
            Test(cylcles, new Auto(ValueWeights));
            Test(cylcles, new Simple(KeyValues, ValueDistribution));
            Test(cylcles, new Fast(KeyValues, ValueDistributionRandomized));
            Test(cylcles, new Auto(ValueWeights));
            Test(cylcles, new Simple(KeyValues, ValueDistribution));
            Test(cylcles, new Fast(KeyValues, ValueDistributionRandomized));
            Test(cylcles, new Auto(ValueWeights));
        }

        private static void Test(int cylcles, IRandValue randomValue)
        {
            string curValue;
            var timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < cylcles; i++)
                curValue = randomValue.Status;
            timer.Stop();
            Console.WriteLine("{3}:\t{0} cycles {1} msec {2} cylcles/msec", cylcles,
                timer.ElapsedMilliseconds, cylcles/timer.ElapsedMilliseconds,
                randomValue.GetType().Name);
        }
    }
}