using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day11 {
    internal class Program {
        public const char EMPTY = 'L';
        public const char OCCUPIED = '#';
        public const char FLOOR = '.';

        public static void Main(string[] args) {
            char[][] map = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../Input/input.txt"))
                .ToList()
                .Select(x => x.ToCharArray()).ToArray();

            int occupiedSeats = 0;
            int oldOccupiedSeats = 0;

            do {
                oldOccupiedSeats = occupiedSeats;

                map = AnalyzeMap(map);

                occupiedSeats = CountOccurrencesOf(OCCUPIED, map);
            } while (occupiedSeats != oldOccupiedSeats);

            Console.WriteLine("Occupied seats : " + occupiedSeats);
        }

        public static int CountOccurrencesOf(char occurrence, char[][] map) {
            return map.SelectMany(x => x).ToArray().Count(x => x == occurrence);
        }

        public static char[][] AnalyzeMap(char[][] map) {
            char[][] newMap = map.Select(x => x.Clone() as char[]).ToArray();

            for (int y = 0; y < map.Length; y++) {
                for (int x = 0; x < map[y].Length; x++) {
                    switch (map[y][x]) {
                        case EMPTY:
                            if (!CheckNeighbours(x, y, map).ContainsKey(OCCUPIED)) {
                                newMap[y][x] = OCCUPIED;
                            }

                            break;

                        case OCCUPIED:
                            Dictionary<char, int> neighbours = CheckNeighbours(x, y, map);
                            if (neighbours.ContainsKey(OCCUPIED) && neighbours[OCCUPIED] >= 5) {
                                newMap[y][x] = EMPTY;
                            }

                            break;
                    }
                }
            }

            return newMap;
        }

        public static Dictionary<char, int> CheckNeighbours(int originX, int originY, char[][] map) {
            Dictionary<char, int> occurrences = new Dictionary<char, int>();

            for (int y = -1; y <= 1; y++) {
                for (int x = -1; x <= 1; x++) {
                    if (!(x == 0 && y == 0)) {
                        char hit = CheckSeatInDirection(new Vector2(originX, originY), new Vector2(x, y), map);
                        if (occurrences.ContainsKey(hit)) {
                            occurrences[hit] = occurrences[hit] + 1;
                        } else {
                            occurrences.Add(hit, 1);
                        }
                    }
                }
            }
            
            return occurrences;
        }

        public static char CheckSeatInDirection(Vector2 origin, Vector2 direction, char[][] map) {
            int y = origin.y + direction.y;
            int x = origin.x + direction.x;

            if (y < 0 || y >= map.Length || x < 0 || x >= map[y].Length) {
                return FLOOR;
            }

            char hit = map[y][x];
            if (hit != FLOOR) {
                return hit;
            }

            return CheckSeatInDirection(new Vector2(x, y), direction, map);
        }
    }

    public class Vector2 {
        public int x;
        public int y;

        public Vector2(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
}