using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _01.CommandPattern.Core.Commands
{
    class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] argsInput = args.Split();
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == $"{argsInput[0]}Command");
            ICommand command = (ICommand)Activator.CreateInstance(type);
            return command.Execute(argsInput.Skip(1).ToArray());
        }
    }
}
