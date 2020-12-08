using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8 {

    class Program {

        static void Main(string[] args) {
            Gameboy gameboy = new Gameboy(File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Input/input.txt")));
            gameboy.Run();
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

        public Gameboy(string[] input) {
            this.instructions = input
                .ToList()
                .Select(Instruction.ConvertToInstruction)
                .ToArray();
        }

        public void Run() {
            while (pos < instructions.Length) {
                if (!oldPositions.Add(pos)) {
                    break;
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
