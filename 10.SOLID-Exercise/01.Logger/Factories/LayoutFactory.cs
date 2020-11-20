using _01.Logger.Interfaces;
using _01.Logger.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _01.Logger.Factories
{
    class LayoutFactory
    {
        public ILayout CreateLayout(string inputLayout)
        {
            ILayout layout = null;
            if (inputLayout == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (inputLayout == "XmlLayout")
            {
                layout = new XmlLayout();
            }
            return layout;
        }
    }
}
