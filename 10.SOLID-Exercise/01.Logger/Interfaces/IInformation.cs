using _01.Logger.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Interfaces
{
    interface IInformation
    {
        ReportLevel ReportLevel { get; set; }
        DateTime DateTime { get; set; }
        string Message { get; set; }
    }
}
