﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Height + 2 * Width;
        }

        public override double CalculateArea()
        {
            return Height * Width;
        }


        public override string Draw()
        {
            return base.Draw() + GetType().Name;
        }
    }
}
