using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4 {
    internal class Program {
        private const char SPACE = ' ';
        private const char COLON = ':';
        private const char HASHTAG = '#';
        private const char A = 'a';
        private const char F = 'f';
        private const string CID = "cid";
        private const string BYR = "byr";
        private const string IYR = "iyr";
        private const string EYR = "eyr";
        private const string HGT = "hgt";
        private const string HCL = "hcl";
        private const string ECL = "ecl";
        private const string PID = "pid";
        private const string CM = "cm";
        private const string IN = "in";

        private static readonly string[] EYE_COLORS = new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
        
        public static void Main(string[] args) {
            string[] lines = File.ReadAllLines("../../Input/input.txt");
            int passportValidCounter = 0;
            HashSet<string> passportKeys = new HashSet<string>();
            
            foreach (string line in lines) {
                if (line.Length == 0) {
                    passportKeys.Clear();
                } else {
                    string[] fields = line.Split(SPACE);

                    foreach (string field in fields) {
                        string[] keyValue = field.Split(COLON);
                        string key = keyValue[0];
                        int numericValue;

                        switch (key) {
                            case BYR:
                                numericValue= int.Parse(keyValue[1]);

                                if (numericValue >= 1920 && numericValue <= 2002) {
                                    passportKeys.Add(key);
                                }
                                break;
                            
                            case IYR:
                                numericValue = int.Parse(keyValue[1]);

                                if (numericValue >= 2010 && numericValue <= 2020) {
                                    passportKeys.Add(key);
                                }
                                break;
                            
                            case EYR:
                                numericValue = int.Parse(keyValue[1]);

                                if (numericValue >= 2020 && numericValue <= 2030) {
                                    passportKeys.Add(key);
                                }
                                break;
                            
                            case HGT:
                                if (keyValue[1].Length >= 3) {
                                    int.TryParse(keyValue[1].Substring(0, keyValue[1].Length - 2), out numericValue);
                                    if ((keyValue[1].IndexOf(IN) != -1 && numericValue >= 59 && numericValue <= 76) || (keyValue[1].IndexOf(CM) != -1 && numericValue >= 150 && numericValue <= 193)) {
                                        passportKeys.Add(key);
                                    }
                                }
                                break;
                            
                            case HCL:
                                if (IsValidHairColor(keyValue[1])) {
                                    passportKeys.Add(key);
                                }
                                break;
                            
                            case ECL:
                                if (EYE_COLORS.Contains(keyValue[1])) {
                                    passportKeys.Add(key);
                                }
                                break;
                            
                            case PID:
                                if (keyValue[1].Length == 9 && int.TryParse(keyValue[1], out numericValue)) {
                                    passportKeys.Add(key);
                                }
                                break;
                        }
                    }
                    
                
                    if (passportKeys.Count == 8 || (passportKeys.Count == 7 && !passportKeys.Contains(CID))) {
                        passportValidCounter++;
                        passportKeys.Clear();
                    }
                }
            }
            
            Console.WriteLine("Passports valid : " + passportValidCounter);
        }

        public static bool IsValidHairColor(string value) {
            char[] chars = value.Substring(1, value.Length - 1).ToCharArray();
            bool isValid = true;
            foreach (char val in chars) {
                int parsedValue;
                if (!(int.TryParse(val.ToString(), out parsedValue) || (val >= A && val <= F))) {
                    isValid = false;
                    break;
                }
            }
            
            return value.Length == 7 && value[0] == HASHTAG && isValid;
        }
    }
}