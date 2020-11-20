using _01.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.SystemManagement
{
    class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
