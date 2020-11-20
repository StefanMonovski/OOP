using _01.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Files
{
    class Information : IInformation
    {
        public Information(ReportLevel reportLevel, DateTime dateTime, string message)
        {
            ReportLevel = reportLevel;
            DateTime = dateTime;
            Message = message;
        }

        public ReportLevel ReportLevel { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
    }
}
