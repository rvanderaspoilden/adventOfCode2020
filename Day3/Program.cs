using System;
using System.Collections.Generic;
using System.IO;

namespace Day3 {
    public class Program {
        private const char TREE_CHAR = '#';

        public static void Main(string[] args) {
            string[] lines = File.ReadAllLines("../../Input/input.txt");
            long treeCounter = 1;
            int rowLength = lines[0].Length;

            Row[] rows = new Row[lines.Length];

            // Analyze map
            for (int y = 0; y < lines.Length; y++) {
                int patternLength = lines[y].Length;
                char[] cells = lines[y].ToCharArray();

                // Retrieve tree position in pattern
                List<int> treePositions = new List<int>();

                for (int i = 0; i < patternLength; i++) {
                    if (cells[i].Equals(TREE_CHAR)) {
                        treePositions.Add(i);
                    }
                }

                rows[y] = new Row(treePositions);
            }

            // Move
            treeCounter *= CalculateWithSlope(1, 1, lines.Length, rows, rowLength);
            treeCounter *= CalculateWithSlope(3, 1, lines.Length, rows, rowLength);
            treeCounter *= CalculateWithSlope(5, 1, lines.Length, rows, rowLength);
            treeCounter *= CalculateWithSlope(7, 1, lines.Length, rows, rowLength);
            treeCounter *= CalculateWithSlope(1, 2, lines.Length, rows, rowLength);

            Console.WriteLine("Tree counter : " + treeCounter);
        }
        
        static long CalculateWithSlope(int x, int y, int height, Row[] rows, int rowLength) {
            int offsetX = x;
            int treeCounter = 0;
            for (int i = y; i < height; i = i + y) {
                treeCounter += rows[i].isTree(offsetX % rowLength) ? 1 : 0;
                offsetX += x;
            }

            return treeCounter > 0 ? treeCounter : 1;
        }
    }

    public class Row {
        public List<int> treePositions;

        public Row(List<int> treePositions) {
            this.treePositions = treePositions;
        }

        public bool isTree(int position) {
            return this.treePositions.Contains(position);
        }
    }
}