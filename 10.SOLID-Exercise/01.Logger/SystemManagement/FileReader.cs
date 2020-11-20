using _01.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _01.Logger.SystemManagement
{
    class FileReader : IReader
    {
        private string filePath;

        public FileReader(string filePath)
        {
            this.filePath = filePath;
        }       

        public string ReadLine()
        {
            return File.ReadAllText(filePath);
        }
    }
}
