using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4 {
    internal class Program {
        private const char SPACE = ' ';
        private const char COLON = ':';
        private const string CID = "cid";
        
        public static void Main(string[] args) {
            string[] lines = File.ReadAllLines("../../Input/input.txt");
            int passportValidCounter = 0;
            HashSet<string> passportKeys = new HashSet<string>();
            
            foreach (string line in lines) {
                if (line.Length == 0) {
                    passportKeys.Clear();
                } else {
                    string[] fields = line.Split(SPACE);
                    string[] keys = fields.ToList().Select(field => field.Split(COLON)[0]).ToArray();
                    
                    passportKeys.UnionWith(keys);
                
                    if (passportKeys.Count == 8 || (passportKeys.Count == 7 && !passportKeys.Contains(CID))) {
                        passportValidCounter++;
                        passportKeys.Clear();
                    }
                }
            }
            
            Console.WriteLine("Passports valid : " + passportValidCounter);
        }
    }
}