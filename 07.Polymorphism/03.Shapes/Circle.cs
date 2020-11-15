using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Radius * Math.PI;
        }

        public override double CalculateArea()
        {
            return Math.Pow(Radius, 2) * Math.PI;
        }

        public override string Draw()
        {
            return base.Draw() + GetType().Name;
        }
    }
}
