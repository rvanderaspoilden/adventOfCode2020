using System;
using System.IO;
using System.Linq;

namespace Day1 {
    internal class Program {
        private const int YEAR = 3;

        public static void Main(string[] args) {
            int[] lines = File.ReadAllLines("../../Input/input.txt").ToList().Select(x => int.Parse(x)).ToArray();

            for (int x = 0; x < lines.Length; x++) {
                for (int y = x + 1; y < lines.Length; y++) {
                    for (int z = y + 1; z < lines.Length; z++) {
                        if (lines[x] + lines[y] + lines[z] == YEAR) {
                            Console.WriteLine(lines[x] * lines[y] * lines[z]);
                            return;
                        }
                    }
                }
            }
        }
    }
}