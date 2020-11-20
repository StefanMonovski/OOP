using _01.Logger.Factories;
using _01.Logger.Files;
using _01.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace _01.Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberAppenders = int.Parse(Console.ReadLine());
            List<IAppender> appenders = new List<IAppender>();
            for (int i = 0; i < numberAppenders; i++)
            {
                string[] inputData = Console.ReadLine().Split();
                string inputType = inputData[0];
                string inputLayout = inputData[1];

                LayoutFactory layoutFactory = new LayoutFactory();
                ILayout layout = layoutFactory.CreateLayout(inputLayout);

                AppenderFactory appenderFactory = new AppenderFactory();
                IAppender appender = appenderFactory.CreateAppender(inputType, layout, new LogFile("../../../Log.txt"));

                appender.ReportLevel = ReportLevel.INFO;
                if (inputData.Length == 3)
                {
                    appender.ReportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), inputData[2]);
                }               
                appenders.Add(appender);
            }
            ILogger logger = new Loggers.Logger(appenders.ToArray());
            string input = "";
            List<IInformation> informations = new List<IInformation>(); 
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputData = input.Split("|");
                string inputLevel = inputData[0];
                string inputDateTime = inputData[1];
                string message = inputData[2];

                ReportLevel reportLevel = ReportLevel.INFO;
                if (inputData.Length == 3)
                {
                    reportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), inputLevel);
                }    
                DateTime dateTime = DateTime.ParseExact(inputDateTime, "G", new CultureInfo("en-US"));
                informations.Add(new Information(reportLevel, dateTime, message));
            }
            foreach (IInformation item in informations)
            {
                logger.Log(item);
            }
            Console.WriteLine("Logger info");
            foreach (IAppender item in logger.Appenders)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
