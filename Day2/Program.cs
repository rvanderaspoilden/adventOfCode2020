using System;
using System.IO;
using System.Linq;

namespace Day2 {
    internal class Program {
        private const char SPACE = ' ';
        private const char TIRET = '-';
        private const char COLON = ':';
        
        public static void Main(string[] args) {
            string[] lines = File.ReadAllLines("../../Input/input.txt");
            int validCounter = 0;
            
            Console.WriteLine(lines.Length);

            foreach (string line in lines) {
                string[] parts = line.Split(SPACE);
                int min = int.Parse(parts[0].Split(TIRET)[0]);
                int max = int.Parse(parts[0].Split(TIRET)[1]);
                char charToFind = parts[1].ToCharArray()[0];
                char[] passwordChars = parts[2].ToCharArray();

                int occurences = passwordChars.ToList().Where(x => x.Equals(charToFind)).ToArray().Length;
                validCounter += occurences >= min && occurences <= max ? 1 : 0;
            }
            
            Console.WriteLine("result is : " + validCounter);
        }
    }
}