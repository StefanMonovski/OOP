using RobotService.Core;
using RobotService.Core.Contracts;
using System;

namespace RobotService
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
