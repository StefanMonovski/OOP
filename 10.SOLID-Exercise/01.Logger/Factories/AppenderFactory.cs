using _01.Logger.Appenders;
using _01.Logger.Files;
using _01.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _01.Logger.Factories
{
    class AppenderFactory
    {
        public IAppender CreateAppender(string inputType, ILayout layout, ILogFile logFile = null)
        {
            IAppender appender = null;
            if (inputType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout);
            }
            else if (inputType == "FileAppender")
            {
                appender = new FileAppender(layout, logFile);
            }
            return appender;
        }
    }
}
