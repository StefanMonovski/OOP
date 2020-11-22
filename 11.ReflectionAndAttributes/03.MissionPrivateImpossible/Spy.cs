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

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicGetters = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo[] classPublicSetters = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();
            foreach (FieldInfo item in classFields)
            {
                sb.AppendLine($"{item.Name} must be private!");
            }
            foreach (MethodInfo item in classNonPublicGetters.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{item.Name} have to be public!");
            }
            foreach (MethodInfo item in classPublicSetters.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{item.Name} have to be private!");
            }
            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] classPrivateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {classType}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");
            foreach (MethodInfo item in classPrivateMethods)
            {
                sb.AppendLine(item.Name);
            }
            return sb.ToString().Trim();
        }
    }
}
