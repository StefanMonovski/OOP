using System;
using System.Collections.Generic;
using System.Text;

namespace _02.GraphicEditor
{
    class Circle : IShape
    {
        public Circle(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
