using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day8 {

    class Program {

        static void Main(string[] args) {
            Gameboy gameboy = new Gameboy();

            string input = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "../../../Input/input.txt"));

            string pattern = @"(nop|jmp)";
            Match match = Regex.Match(input, pattern);

            while(match.Success) {
                string newInput = input;

                newInput = newInput.Remove(match.Index, match.Length).Insert(match.Index, match.Value == "jmp" ? "nop" : "jmp");

                gameboy.SetInstructions(newInput.Split("\r\n"));

                if (gameboy.Run())
                    break;

                match = match.NextMatch();
            }

            Console.WriteLine("Result acc : " + gameboy.acc);
        }
    }

    public class Gameboy {
        public int acc = 0;
        public int pos = 0;

        private HashSet<int> oldPositions = new HashSet<int>();
        private Instruction[] instructions;

        private const string JMP = "jmp";
        private const string ACC = "acc";

        public void SetInstructions(string[] input) {
            this.instructions = input
                .ToList()
                .Select(Instruction.ConvertToInstruction)
                .ToArray();
        }

        public bool Run() {
            acc = 0;
            pos = 0;
            oldPositions.Clear();

            while (pos < instructions.Length) {
                if (!oldPositions.Add(pos)) {
                    return false;
                }

                Instruction currentInstruction = instructions[pos];

                switch (currentInstruction.operationType) {
                    case JMP:
                        pos += currentInstruction.value - 1;
                        break;

                    case ACC:
                        acc += currentInstruction.value;
                        break;
                }

                pos++;
            }

            return true;
        }
    }

    public class Instruction {
        public string operationType;
        public int value;
        private static char EMPTY = ' ';

        public Instruction(string type, int value) {
            this.operationType = type;
            this.value = value;
        }

        public static Instruction ConvertToInstruction(string line) {
            return new Instruction(line.Split(EMPTY)[0], int.Parse(line.Split(EMPTY)[1]));
        }
    }
}
