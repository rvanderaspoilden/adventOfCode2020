using System;
using System.IO;
using System.Linq;

namespace Day12 {
    class Program {
        static void Main(string[] args) {
            Action[] actions = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Input/input.txt")).ToList().Select(x => {
                ActionType dir = (ActionType) Enum.Parse(typeof(ActionType), x.Substring(0, 1));
                int value = int.Parse(x.Substring(1, x.Length - 1));
                return new Action(dir, value);
            }).ToArray();

            Ship ship = new Ship();

            foreach (Action action in actions) {
                switch (action.actionType) {
                    case ActionType.F:
                        ship.MoveToWaypoint(action.value);
                        break;

                    case ActionType.R:
                        ship.Rotate(action.value, 1);
                        break;

                    case ActionType.L:
                        ship.Rotate(action.value, -1);
                        break;

                    case ActionType.E:
                        ship.MoveWaypoint(action.value, Direction.E);
                        break;

                    case ActionType.W:
                        ship.MoveWaypoint(action.value, Direction.W);
                        break;

                    case ActionType.S:
                        ship.MoveWaypoint(action.value, Direction.S);
                        break;

                    case ActionType.N:
                        ship.MoveWaypoint(action.value, Direction.N);
                        break;
                }
            }

            Console.WriteLine("Manhattan distance : " + ship.GetManhattanDistance());
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

    public class Waypoint {
        public Vector2 position;

        public Waypoint() {
            this.position = new Vector2(10, 1);
        }

        public void Move(int value, Direction direction) {
            switch (direction) {
                case Direction.E:
                    this.position.x += value;
                    break;

                case Direction.W:
                    this.position.x -= value;
                    break;

                case Direction.N:
                    this.position.y += value;
                    break;

                case Direction.S:
                    this.position.y -= value;
                    break;
            }
        }
    }

    public class Ship {
        public Vector2 position;
        public Direction direction;
        public Waypoint waypoint;

        public Ship() {
            this.position = new Vector2(0, 0);
            this.direction = Direction.E;
            this.waypoint = new Waypoint();
        }

        public void MoveToWaypoint(int multiplier) {
            this.position.x += multiplier * this.waypoint.position.x;
            this.position.y += multiplier * this.waypoint.position.y;
        }

        public void MoveWaypoint(int value, Direction direction) {
            this.waypoint.Move(value, direction);
        }

        public void Rotate(int degree, int dir) {
            int newDegree = 360 + degree;
            newDegree = newDegree >= 360 ? newDegree % 360 : newDegree;

            for (int i = 0; i < newDegree; i += 90) {
                if (dir == 1) {
                    this.waypoint.position = new Vector2(this.waypoint.position.y, -this.waypoint.position.x);
                } else {
                    this.waypoint.position = new Vector2(-this.waypoint.position.y, this.waypoint.position.x);
                }
            }
        }

        public int GetManhattanDistance() {
            return Math.Abs(this.position.x) + Math.Abs(this.position.y);
        }
    }

    public enum Direction {
        N = 0,
        E = 90,
        S = 180,
        W = 270
    }

    public enum ActionType {
        N,
        E,
        S,
        W,
        L,
        R,
        F
    }

    public class Action {
        public ActionType actionType;
        public int value;

        public Action(ActionType actionType, int value) {
            this.value = value;
            this.actionType = actionType;
        }
    }
}