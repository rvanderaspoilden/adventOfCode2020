using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day9 {
    internal class Program {
        public static void Main(string[] args) {
            long[] numbers = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../Input/input.txt"))
                .ToList()
                .Select(long.Parse)
                .ToArray();

            int preamble = 25;

            Console.WriteLine("Result is " + FindWeaknessNumber(numbers, preamble));
        }

        public static long FindWeaknessNumber(long[] numbers, int preamble) {
            for (int i = 0; i < numbers.Length - preamble; i++) {
                HashSet<long> sums = new HashSet<long>();

                for (int j = i; j < i + preamble; j++) {
                    for (int k = j + 1; k < i + preamble; k++) {
                        sums.Add(numbers[j] + numbers[k]);
                    }
                }

                if (!sums.Contains(numbers[i + preamble])) {
                    return numbers[i + preamble];
                }
            }

            return 0;
        }
    }
}