﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Command
{
    public class ModifyPrice
    {
        private readonly List<ICommand> commands;
        private ICommand command;

        public ModifyPrice()
        {
            commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void Invoke()
        {
            commands.Add(command);
            command.ExecuteCommand();
        }
    }
}
