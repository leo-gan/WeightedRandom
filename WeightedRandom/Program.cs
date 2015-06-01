using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            var cycles = Convert.ToInt32(args[0]);
            Console.WriteLine("{0,10:N0} cycles:", cycles);
            Console.WriteLine("Method   Ticks    Ticks/Cycle");
            Console.WriteLine("==============================================");

            for (int i = 0; i < 5; i++)
            {
                Test(cycles, new Simple(KeyValues, ValueDistribution));
                Test(cycles, new Fast(KeyValues, ValueDistributionRandomized));
                Test(cycles, new Auto(ValueWeights));
            }
        }

        private static void Test(int cycles, IRandValue randomValue)
        {
            var timer = new Stopwatch();
            var times = new long[cycles];
            for (var i = 0; i < cycles; i++)
            {
                timer.Restart();
                var curValue = randomValue.Status;
                timer.Stop();
                times[i] = timer.ElapsedTicks;
                GC.Collect();
                GC.WaitForFullGCComplete();
                GC.Collect();
            }
            //for (var i = 0; i < cycles; i++)
            //{
            //    Console.Write("{0,3:N0} ", times[i]);
            //    if (i % 20 == 19)
            //        Console.WriteLine("\n");
            //}
            Console.WriteLine("{0,6} {1,8:N0} {2,10:F2}", randomValue.GetType().Name,
                times.Sum(), ((double)times.Sum())/cycles);
        }
    }
}