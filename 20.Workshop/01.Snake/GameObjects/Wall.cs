using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';

        public Wall(int x, int y) 
            :base(x, y)
        {
            InitializeWallBorders();
        }

        public bool IsPointOfWall(Point snakeHead)
        {
            return snakeHead.X == 0 || snakeHead.Y == Y || snakeHead.Y == 0 || snakeHead.X == X - 1;
        }

        private void SetHorizontalLine(int y)
        {
            for (int i = 0; i < X; i++)
            {
                if (i % 2 == 0)
                {
                    Draw(i, y, wallSymbol);
                }
            }
        }

        private void SetVerticalLine(int x)
        {
            for (int i = 0; i < Y; i++)
            {
                Draw(x, i, wallSymbol);
            }
        }

        private void InitializeWallBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(Y);
            SetVerticalLine(0);
            SetVerticalLine(X - 1);
        }
    }
}
