using _01.Logger.Files;
using _01.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Loggers
{
    class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            Appenders = appenders;
        }

        public IAppender[] Appenders { get; set; }

        public void Log(IInformation info)
        {
            foreach (IAppender item in Appenders)
            {
                if (info.ReportLevel >= item.ReportLevel)
                {
                    item.Append(info);
                }              
            }
        }
    }
}
