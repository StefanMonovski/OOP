using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        private const char foodSymbol = '$';
        private const int foodPoints = 2;

        public FoodDollar(Wall wall)
            : base(wall, foodSymbol, foodPoints)
        {
        }
    }
}
