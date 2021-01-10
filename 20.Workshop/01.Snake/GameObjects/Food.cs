using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame.GameObjects
{
    public abstract class Food : Point
    {
        private Wall wall;
        private Random random;
        private readonly char foodSymbol;

        protected Food(Wall wall, char foodSymbol, int foodPoints)
            :base(wall.X, wall.Y)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            FoodPoints = foodPoints;
            random = new Random();
        }

        public int FoodPoints { get; private set; }
        
        public void SetRandomPosition(Queue<Point> snakePositions)
        {
            X = random.Next(2, wall.X - 2);
            Y = random.Next(2, wall.Y - 2);

            while (snakePositions.Any(x => x.X == X && x.Y == Y) || X % 2 == 1)
            {
                X = random.Next(2, wall.X - 2);
                Y = random.Next(2, wall.Y - 2);
            }

            Draw(foodSymbol);
        }

        public bool IsPositionFoodPoint(Point snakeHeadPosition)
        {
            return snakeHeadPosition.X == X && snakeHeadPosition.Y == Y;
        }
    }
}
