using _01.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _01.Logger.Files
{
    class LogFile : ILogFile
    {
        public LogFile(string path)
        {
            Path = path;
        }

        public string Path { get; set; }

        public int GetSize()
        {
            string fileText = File.ReadAllText(Path);
            return fileText.ToCharArray().Where(x => Char.IsLetter(x)).Sum(x => x);
        }
    }
}
