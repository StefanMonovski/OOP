using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Interfaces
{
    interface IWriter
    {
        void Write(string text);
        void WriteLine(string text);
    }
}
