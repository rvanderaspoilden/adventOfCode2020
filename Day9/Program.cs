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

            long[] range = GetRangeOfNumbers(numbers, preamble);
            Console.WriteLine("Result is " + (range.Min() + range.Max()));
        }

        public static long[] CreateArrays(long[] input, int startIdx, int endIdx) {
            List<long> numbers = new List<long>();

            for (int i = startIdx; i <= endIdx; i++) {
                numbers.Add(input[i]);
            }

            return numbers.ToArray();
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

        public static long[] GetRangeOfNumbers(long[] numbers, int preamble) {
            long weakness = FindWeaknessNumber(numbers, preamble);

            for (int i = 0; i < numbers.Length; i++) {
                for (int j = i + 1; j < numbers.Length; j++) {
                    long[] range = CreateArrays(numbers, i, j);
                    long sum = range.ToList().Sum();
                    
                    if (sum > weakness) {
                        break;
                    } else if (sum == weakness) {
                        return range;
                    }
                }
            }

            return null;
        }
    }
}