using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7 {
    class Program {

        private const string CONTAIN = " contain ";
        private const string SHINY_GOLD_BAG = "shiny gold";

        static void Main(string[] args) {
            string[] lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Input/input.txt"));
            HashSet<string> eligibleBags = new HashSet<string>();
            HashSet<string> bagsToCheck = new HashSet<string>();
            bagsToCheck.Add(SHINY_GOLD_BAG);

            do {
                string bagToCheck = bagsToCheck.First();

                foreach (string line in lines) {
                    string bagName = line.Split(CONTAIN)[0].Replace("bags", "").Trim();
                    string bagContent = line.Split(CONTAIN)[1].Trim();

                    if (bagContent.IndexOf(bagToCheck) != -1) {
                        eligibleBags.Add(bagName);
                        bagsToCheck.Add(bagName);
                    }
                }

                bagsToCheck.Remove(bagToCheck);

            } while (bagsToCheck.Count > 0);
            

            Console.WriteLine("Result : " + eligibleBags.Count);
        }
    }
}
