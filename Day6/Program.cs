using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day6 {
    class Program {
        static void Main(string[] args) {
            string[] lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Input/input.txt"));
            HashSet<char> groupAnswers = new HashSet<char>();
            int count = 0;
            bool takeFirst = true;

            foreach (string line in lines) {
                if (line.Length == 0) { // End of group
                    count += groupAnswers.Count;
                    groupAnswers.Clear();
                    takeFirst = true;
                } else {
                    if (takeFirst) {
                        line.ToCharArray().ToList().ForEach(answer => groupAnswers.Add(answer));
                        takeFirst = false;
                    } else {
                        HashSet<char> answers = line.ToCharArray().ToHashSet();
                        groupAnswers.IntersectWith(answers);
                    }
                }
            }

            count += groupAnswers.Count;
            groupAnswers.Clear();


            Console.WriteLine("Answers : " + count);
        }
    }
}
