using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5 {
    public class Program {

        private const int SEVEN = 7;
        private const int THREE = 3;
        private const int EIGHT = 8;
        private const int ZERO = 0;
        private const int TOTAL_ROWS = 128;
        private const int TOTAL_COLS = 8;
        private const char R = 'R';
        private const char L = 'L';
        private const char B = 'B';
        private const char F = 'F';

        static void Main(string[] args) {
            string[] lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Input/input.txt"));
            HashSet<long> seats = new HashSet<long>();

            foreach (string line in lines) {
                int row;
                int col;
                char[] letters = line.ToCharArray();

                // Calculate row
                Range range = new Range(0, TOTAL_ROWS - 1);

                for (int i = 0; i < SEVEN; i++) {
                    range = CalculateMinMax(letters[i], range);
                }

                row = range.min;

                // Calculate column
                range = new Range(0, TOTAL_COLS - 1);

                for (int i = 0; i < THREE; i++) {
                    range = CalculateMinMax(letters[SEVEN + i], range);
                }

                col = range.min;

                seats.Add(row * EIGHT + col);
            }

            HashSet<long> frontAndBackSeats = new HashSet<long>();

            for (int i = 0; i < TOTAL_COLS - 1; i++) {
                frontAndBackSeats.Add(ZERO * EIGHT + i);
                frontAndBackSeats.Add((TOTAL_ROWS - 1) * EIGHT + i);
            }

            HashSet<long> missingSeats = new HashSet<long>();

            for (int i = 0; i < seats.Max(); i++) {
                if (!seats.Contains(i)) {
                    missingSeats.Add(i);
                }
            }

            foreach (long missingSeatId in missingSeats) {
                if (seats.Contains(missingSeatId - 1) && seats.Contains(missingSeatId + 1) && !frontAndBackSeats.Contains(missingSeatId)) {
                    Console.WriteLine("Seat ID is : " + missingSeatId);
                    return;
                }
            }
        }

        private static Range CalculateMinMax(char letter, Range range) {
            Range newRange;
            if (letter == F || letter == L) { // Lower half
                int value = (int)MathF.Floor((range.max - range.min) / 2f);
                newRange = new Range(range.min, range.min + value);
            } else { // Upper half
                int value = (int)MathF.Ceiling((range.max - range.min) / 2f);
                newRange = new Range(range.min + value, range.max);
            }

            return newRange;
        }
    }

    public class Range {
        public int min;
        public int max;

        public Range(int min, int max) {
            this.min = min;
            this.max = max;
        }
    }
}
