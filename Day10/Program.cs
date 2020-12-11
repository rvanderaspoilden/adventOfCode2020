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
        }
    }
}