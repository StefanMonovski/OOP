using SnakeGame.Enums;
using SnakeGame.GameObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace SnakeGame.Core
{
    public class Engine
    {
        private Point[] pointsOfDirection;
        private Direction direction;
        private double sleepTime;
        private readonly Wall wall;
        private Snake snake;

        public Engine(Wall wall, Snake snake)
        {
            pointsOfDirection = new Point[4];
            sleepTime = 100;
            this.wall = wall;
            this.snake = snake;
        }

        public void Run()
        {
            CreateDirections();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = snake.IsMoving(pointsOfDirection[(int)direction], direction);
                if (!isMoving)
                {
                    EndOrRestartGame();
                }

                sleepTime -= 0.01;
                Thread.Sleep((int)sleepTime);
            }           
        }

        public Direction GetDirection()
        {
            return direction;
        }

        private void CreateDirections()
        {
            pointsOfDirection[0] = new Point(1, 0);
            pointsOfDirection[1] = new Point(-1, 0);
            pointsOfDirection[2] = new Point(0, 1);
            pointsOfDirection[3] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey(true);

            if (userInput.Key == ConsoleKey.A)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.D)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.W)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.S)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
            Console.CursorVisible = false;
        }

        private void EndOrRestartGame()
        {
            Console.SetCursorPosition(150, 16);
            Console.WriteLine("--------------------------------");
            Console.SetCursorPosition(150, 17);
            Console.WriteLine("-----------Game over!-----------");
            Console.SetCursorPosition(150, 18);
            Console.WriteLine("--------------------------------");
            Console.SetCursorPosition(150, 19);
            Console.WriteLine("Press spacebar to play again...");
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            if (userInput.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                Console.SetCursorPosition(150, 19);
                Environment.Exit(0);
            }            
        }
    }
}