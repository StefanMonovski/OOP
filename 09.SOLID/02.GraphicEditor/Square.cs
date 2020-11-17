using System;
using System.Collections.Generic;
using System.Text;

namespace _02.GraphicEditor
{
    class Square : IShape
    {
        public Square(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
