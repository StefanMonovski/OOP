using SnakeGame.Core;
using SnakeGame.GameObjects;
using SnakeGame.Utilities;
using System;
using System.Text;

namespace SnakeGame
{
    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            Console.BufferHeight = Console.LargestWindowHeight;
            Wall wall = new Wall(125, 53);
            DisplayGameInstructions();

            ConsoleKeyInfo userInput = Console.ReadKey(true);
            while (userInput.Key != ConsoleKey.Spacebar)
            {
                userInput = Console.ReadKey(true);
            }
            Snake snake = new Snake(wall);
            Engine engine = new Engine(wall, snake);
            engine.Run();
        }

        static void DisplayGameInstructions()
        {
            Console.SetCursorPosition(150, 1);
            Console.WriteLine("Press spacebar to start!");

            Console.SetCursorPosition(150, 3);
            Console.WriteLine("How to play:");
            Console.SetCursorPosition(150, 4);
            Console.WriteLine(" W -> move up");
            Console.SetCursorPosition(150, 5);
            Console.WriteLine(" A -> move left");
            Console.SetCursorPosition(150, 6);
            Console.WriteLine(" S -> move down");
            Console.SetCursorPosition(150, 7);
            Console.WriteLine(" D -> move right");

            Console.SetCursorPosition(150, 9);
            Console.WriteLine("Points value:");
            Console.SetCursorPosition(150, 10);
            Console.WriteLine(" * -> 1 point");
            Console.SetCursorPosition(150, 11);
            Console.WriteLine(" $ -> 2 points");
            Console.SetCursorPosition(150, 12);
            Console.WriteLine(" # -> 3 points");
        }
    }
}
