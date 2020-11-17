using System;
using System.Collections.Generic;
using System.Text;

namespace _02.GraphicEditor
{
    class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            Console.WriteLine($"Drawing {shape.Name}");
        }
    }
}
