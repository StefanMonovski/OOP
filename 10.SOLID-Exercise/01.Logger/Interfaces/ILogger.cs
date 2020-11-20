using _01.Logger.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Interfaces
{
    interface ILogger
    {
        IAppender[] Appenders { get; set; }

        void Log(IInformation info);
    }
}
