using System;
using System.Collections.Generic;

namespace _02.GraphicEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphicEditor graphicEditor = new GraphicEditor();
            List<IShape> shapes = new List<IShape>();
            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "circle")
                {
                    shapes.Add(new Circle(input));
                }
                else if (input == "rectangle")
                {
                    shapes.Add(new Rectangle(input));
                }
                else if (input == "square")
                {
                    shapes.Add(new Square(input));
                }
            }
            foreach (IShape item in shapes)
            {
                graphicEditor.DrawShape(item);
            }
        }
    }
}
