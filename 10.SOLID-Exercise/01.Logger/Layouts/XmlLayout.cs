using _01.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Layouts
{
    class XmlLayout : ILayout
    {
        public XmlLayout()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<log>");
            sb.AppendLine("   <date>{0}</date>");
            sb.AppendLine("   <level>{1}</level>");
            sb.AppendLine("   <message>{2}</message>");
            sb.AppendLine("</log>");
            Format = sb.ToString();
        }

        public string Format { get; set; }
    }
}
