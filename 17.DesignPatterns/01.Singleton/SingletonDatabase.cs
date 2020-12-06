using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _01.Singleton
{
    class SingletonDatabase
    {
        private List<string> database;

        private SingletonDatabase()
        {
            Console.WriteLine("Initialize singleton database");
            database = new List<string>(){ "first", "second", "third", "fourth" };
        }

        public static SingletonDatabase Instance = new SingletonDatabase();

        public string GetData(int index)
        {
            return database[index];
        }
    }
}
