using System;
using System.Collections.Generic;
using Enemy;

namespace Pathfinding
{


    // Основной класс поиска пути
    public class Pathfinding
    {
        private readonly IObstacleDetector _obstacleDetector;

        public Pathfinding(IObstacleDetector obstacleDetector)
        {
            _obstacleDetector = obstacleDetector ?? throw new ArgumentNullException(nameof(obstacleDetector));
        }

        public List<(int x, int y)> FindPath(int startX, int startY, int targetX, int targetY)
        {
            var openList = new SortedSet<Node>(Comparer<Node>.Create((a, b) => a.FCost == b.FCost ? a.HCost.CompareTo(b.HCost) : a.FCost.CompareTo(b.FCost)));
            var closedSet = new HashSet<(int x, int y)>();

            var startNode = new Node(startX, startY, null, 0, GetDistance(startX, startY, targetX, targetY));
            openList.Add(startNode);

            while (openList.Count > 0)
            {
                var currentNode = openList.Min;
                openList.Remove(currentNode);

                if (currentNode.X == targetX && currentNode.Y == targetY)
                    return ConstructPath(currentNode);

                closedSet.Add((currentNode.X, currentNode.Y));

                foreach (var neighbor in GetNeighbors(currentNode))
                {
                    if (closedSet.Contains((neighbor.X, neighbor.Y)) || _obstacleDetector.IsObstacle(neighbor.X, neighbor.Y))
                        continue;

                    var existingNode = FindNodeInSet(openList, neighbor.X, neighbor.Y);
                    if (existingNode == null || neighbor.GCost < existingNode.GCost)
                    {
                        openList.Remove(existingNode);
                        openList.Add(neighbor);
                    }
                }
            }

            return null; // Путь не найден
        }

        private List<(int x, int y)> ConstructPath(Node node)
        {
            var path = new List<(int x, int y)>();
            while (node != null)
            {
                path.Add((node.X, node.Y));
                node = node.Parent;
            }
            path.Reverse();
            return path;
        }

        private IEnumerable<Node> GetNeighbors(Node node)
        {
            var neighbors = new List<Node>();
            var directions = new (int dx, int dy)[]
            {
                (1, 0), (0, 1), (-1, 0), (0, -1), // Основные направления
                (1, 1), (-1, -1), (1, -1), (-1, 1) // Диагонали
            };

            foreach (var (dx, dy) in directions)
            {
                var x = node.X + dx;
                var y = node.Y + dy;

                if (_obstacleDetector.IsObstacle(x, y)) continue;

                var gCost = node.GCost + GetDistance(node.X, node.Y, x, y);
                var hCost = GetDistance(x, y, node.X, node.Y);
                neighbors.Add(new Node(x, y, node, gCost, hCost));
            }

            return neighbors;
        }

        private Node FindNodeInSet(SortedSet<Node> set, int x, int y)
        {
            foreach (var node in set)
                if (node.X == x && node.Y == y)
                    return node;

            return null;
        }

        private double GetDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }
    }



    class Program
    {
        static void Main()
        {
            var obstacles = new HashSet<(int x, int y)> { (2, 2), (2, 3), (3, 2) };
            var obstacleDetector = new ObstacleDetector(obstacles);
            var pathfinder = new Pathfinding(obstacleDetector);

            var path = pathfinder.FindPath(0, 0, 5, 5);

            if (path != null)
            {
                Console.WriteLine("Путь найден:");
                foreach (var (x, y) in path)
                    Console.WriteLine($"({x}, {y})");
            }
            else
            {
                Console.WriteLine("Путь не найден.");
            }
        }
    }
}
