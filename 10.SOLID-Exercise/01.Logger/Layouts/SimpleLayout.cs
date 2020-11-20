using _01.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Layouts
{
    class SimpleLayout : ILayout
    {
        public SimpleLayout()
        {
            Format = "{0} - {1} - {2}";
        }

        public string Format { get; set; }
    }
}
