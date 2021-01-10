using SnakeGame.Enums;
using SnakeGame.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SnakeGame.GameObjects
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';
        private Queue<Point> snakePositions;
        private Food[] foods;
        private Wall wall;
        private int nextSnakeHeadX;
        private int nextSnakeHeadY;
        private int foodIndex;
        private int RandomFoodNumber => new Random().Next(0, foods.Length);

        public Snake(Wall wall)
        {
            this.wall = wall;
            snakePositions = new Queue<Point>();
            foods = new Food[3];
            foodIndex = RandomFoodNumber;
            CreateFoods();
            CreateSnake();
        }

        private void CreateSnake()
        {
            for (int i = 1; i < 4; i++)
            {
                snakePositions.Enqueue(new Point(2, i));
            }
            DisplayCurrentSnakeLength();
        }

        private void CreateFoods()
        {
            foods[0] = new FoodAsterisk(wall);
            foods[1] = new FoodDollar(wall);
            foods[2] = new FoodHash(wall);
            foods[foodIndex].SetRandomPosition(snakePositions);
        }

        public bool IsMoving(Point nextPosition, Direction direction)
        {
            Point snakeHead = snakePositions.Last();
            GetNextPositionOfSnakeHead(nextPosition, snakeHead, direction);

            if (snakePositions.Any(x => x.X == nextSnakeHeadX && x.Y == nextSnakeHeadY))
            {
                return false;
            }
            snakeHead = new Point(nextSnakeHeadX, nextSnakeHeadY);

            if (wall.IsPointOfWall(snakeHead))
            {
                return false;
            }
            snakePositions.Enqueue(snakeHead);
            snakeHead.Draw(snakeSymbol);

            if (foods[foodIndex].IsPositionFoodPoint(snakeHead))
            {
                Eat(nextPosition, snakeHead, direction);
                DisplayCurrentSnakeLength();               
            }

            Point snakeTail = snakePositions.Dequeue();
            snakeTail.Draw(' ');
            return true;
        }

        private void Eat(Point nextPosition, Point snakeHead, Direction direction)
        {
            int length = foods[foodIndex].FoodPoints;
            for (int i = 0; i < length; i++)
            {
                GetNextPositionOfSnakeHead(nextPosition, snakeHead, direction);
                EnqueueSnakePositions(nextSnakeHeadX, nextSnakeHeadY, direction);
            }
            foodIndex = RandomFoodNumber;
            foods[foodIndex].SetRandomPosition(snakePositions);
        }
         
        private void GetNextPositionOfSnakeHead(Point nextPosition, Point snakeHead, Direction direction)
        {
            if (direction == Direction.Right)
            {
                nextSnakeHeadX = snakeHead.X + nextPosition.X + 1;
                nextSnakeHeadY = snakeHead.Y + nextPosition.Y;
            }
            else if (direction == Direction.Left)
            {
                nextSnakeHeadX = snakeHead.X + nextPosition.X - 1;
                nextSnakeHeadY = snakeHead.Y + nextPosition.Y;
            }
            else
            {
                nextSnakeHeadX = snakeHead.X + nextPosition.X;
                nextSnakeHeadY = snakeHead.Y + nextPosition.Y;
            }
        }

        private void EnqueueSnakePositions(int X, int Y, Direction direction)
        {
            if (direction == Direction.Right)
            {
                snakePositions.Enqueue(new Point(X - 2, Y));
            }
            else if (direction == Direction.Left)
            {
                snakePositions.Enqueue(new Point(X + 2, Y));
            }
            else if (direction == Direction.Down)
            {
                snakePositions.Enqueue(new Point(X, Y - 1));
            }
            else if (direction == Direction.Up)
            {
                snakePositions.Enqueue(new Point(X, Y + 1));
            }
        }

        private void DisplayCurrentSnakeLength()
        {
            Console.SetCursorPosition(150, 14);
            Console.WriteLine($"Current points: {snakePositions.Count}");
        }
    }
}
