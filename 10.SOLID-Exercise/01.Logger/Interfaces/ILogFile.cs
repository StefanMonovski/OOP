using _01.Logger.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Interfaces
{
    interface ILogFile
    {
        string Path { get; set; }

        int GetSize();
    }
}
