using _01.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _01.Logger.SystemManagement
{
    class FileWriter : IWriter
    {
        private string filePath;

        public FileWriter(string filePath)
        {
            this.filePath = filePath;
        }

        public void Write(string text)
        {
            File.AppendAllText(filePath, text);
        }

        public void WriteLine(string text)
        {
            File.AppendAllText(filePath, text + Environment.NewLine);
        }
    }
}
