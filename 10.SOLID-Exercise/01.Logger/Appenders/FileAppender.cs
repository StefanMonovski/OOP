using _01.Logger.Files;
using _01.Logger.Interfaces;
using _01.Logger.SystemManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Appenders
{
    class FileAppender : IAppender
    {
        private IWriter writer;
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
        {
            Layout = layout;
            ReportLevel = ReportLevel.INFO;
            writer = new FileWriter(logFile.Path);
            this.logFile = logFile;
        }

        public ILayout Layout { get; set; }
        public ReportLevel ReportLevel { get; set; }
        public int messagesAppended = 0;
        public int FilesSize = 0;

        public void Append(IInformation info)
        {
            writer.WriteLine(string.Format(Layout.Format, info.DateTime.ToString("G"), info.ReportLevel, info.Message));
            messagesAppended++;
            FilesSize += logFile.GetSize();
        }

        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, LayoutType: {Layout.GetType().Name}, " +
                $"ReportLevel: {ReportLevel}, Messages appended: {messagesAppended}, File size: {logFile.GetSize()}";
        }
    }
}
