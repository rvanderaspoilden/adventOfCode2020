using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10 {
    internal class Program {
        public static void Main(string[] args) {
            int[] numbers = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../Input/input.txt"))
                .ToList()
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToArray();
            
            Dictionary<int, int> joltageDifferences = new Dictionary<int, int>();
            int currentJoltAdapter = 0;
            int currentIdx = 0;
            
            joltageDifferences.Add(numbers[currentIdx], 1);

            while (currentIdx != (numbers.Length - 1)) {
                for (int i = 1; i <= 3; i++) {
                    if (currentIdx + i >= numbers.Length) {
                        break;
                    }

                    int difference = numbers[currentIdx + i] - numbers[currentIdx]; 
                
                    if (difference <= 3) {
                        if (joltageDifferences.ContainsKey(difference)) {
                            joltageDifferences[difference] = joltageDifferences[difference] + 1;
                        } else {
                            joltageDifferences.Add(difference, 1);
                        }

                        currentIdx += i;
                        break;
                    }
                }
            }
            

            joltageDifferences[3] = joltageDifferences[3] + 1;
            
            foreach (KeyValuePair<int, int> pair in joltageDifferences) {
                Console.WriteLine(pair.Key + " jolt : " + pair.Value);
            }
            
            Console.WriteLine("Result : " + joltageDifferences[1] * joltageDifferences[3]);
        }
    }
}