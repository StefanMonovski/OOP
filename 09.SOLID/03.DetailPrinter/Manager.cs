using System;
using System.Collections.Generic;
using System.Text;

namespace _03.DetailPrinter
{
    class Manager : Employee, IPrintable
    {
        public Manager(string name, ICollection<string> documents) 
            :base(name)
        {
            Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string GetDetails()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.GetDetails());
            sb.AppendLine("Documents:");
            if (Documents.Count == 0)
            {
                sb.AppendLine(" Not found");
            }
            else
            {
                foreach (string item in Documents)
                {
                    sb.AppendLine($" {item}");
                }
            }   
            return sb.ToString().Trim();
        }
    }
}
