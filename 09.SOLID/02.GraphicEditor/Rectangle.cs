using System;
using System.Collections.Generic;
using System.Text;

namespace _02.GraphicEditor
{
    class Rectangle : IShape
    {
        public Rectangle(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
