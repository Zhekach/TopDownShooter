using System.Collections.Generic;

namespace Enemy
{
    public class Pathfinder
    {
        
    }
    
    // Класс узла для представления клетки на плоскости
    public class Node
    {
        public int X { get; }
        public int Y { get; }
        public Node Parent { get; }
        public double GCost { get; } // Стоимость от начала пути до этой клетки
        public double HCost { get; } // Эвристическая стоимость до цели
        public double FCost => GCost + HCost; // Общая стоимость

        public Node(int x, int y, Node parent, double gCost, double hCost)
        {
            X = x;
            Y = y;
            Parent = parent;
            GCost = gCost;
            HCost = hCost;
        }
    }
    
    
    // Интерфейс для определения препятствий
    public interface IObstacleDetector
    {
        bool IsObstacle(int x, int y);
    }
    
    // Пример реализации обнаружения препятствий
    public class ObstacleDetector : IObstacleDetector
    {
        private readonly HashSet<(int x, int y)> _obstacles;

        public ObstacleDetector(HashSet<(int x, int y)> obstacles)
        {
            _obstacles = obstacles;
        }

        public bool IsObstacle(int x, int y)
        {
            return _obstacles.Contains((x, y));
        }
    }
}