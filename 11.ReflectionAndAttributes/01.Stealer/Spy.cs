using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Object classInstance = Activator.CreateInstance(classType);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {classType}");
            foreach (FieldInfo item in classFields.Where(x => fieldNames.Contains(x.Name)))
            {
                sb.AppendLine($"{item.Name} = {item.GetValue(classInstance)}");
            }
            return sb.ToString().Trim();
        }
    }
}
