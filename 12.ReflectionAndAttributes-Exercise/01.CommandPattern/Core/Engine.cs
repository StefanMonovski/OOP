using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.CommandPattern.Core
{
    class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string args;
            string result = "";
            while (result != null)
            {
                args = Console.ReadLine();
                result = commandInterpreter.Read(args);
                Console.WriteLine(result);
            }
        }
    }
}
