using System;
using System.IO;
using System.Linq;

namespace Day2 {
    internal class Program {
        private const char SPACE = ' ';
        private const char TIRET = '-';

        public static void Main(string[] args) {
            string[] lines = File.ReadAllLines("../../Input/input.txt");
            int validCounter = 0;

            foreach (string line in lines) {
                string[] parts = line.Split(SPACE);

                int[] expectedPositions = parts[0].Split(TIRET).ToList().Select(int.Parse).ToArray();

                char charToFind = parts[1].ToCharArray()[0];
                string password = parts[2];

                validCounter += (expectedPositions.Count(pos => password[pos - 1] == charToFind) == 1) ? 1 : 0;
            }

            Console.WriteLine("result is : " + validCounter);
        }
    }
}