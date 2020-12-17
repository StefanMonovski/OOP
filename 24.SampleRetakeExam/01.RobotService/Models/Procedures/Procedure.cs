using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected List<IRobot> Robots { get; }

        protected Procedure()
        {
            Robots = new List<IRobot>();
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GetType().Name);
            foreach (var item in Robots)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
            robot.ProcedureTime -= procedureTime;
            Robots.Add(robot);
        }
    }
}
