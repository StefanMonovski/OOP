using _01.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.SystemManagement
{
    class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
