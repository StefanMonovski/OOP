﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.GameObjects
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(symbol);
        }

        public void Draw(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
    }
}
