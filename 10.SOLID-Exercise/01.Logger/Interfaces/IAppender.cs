using _01.Logger.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Interfaces
{
    interface IAppender
    {
        ILayout Layout { get; set; }
        ReportLevel ReportLevel { get; set; }
        void Append(IInformation info);
    }
}
