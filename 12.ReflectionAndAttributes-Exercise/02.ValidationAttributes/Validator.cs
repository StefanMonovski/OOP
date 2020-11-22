using ValidationAttributes.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var attributes = property.GetCustomAttributes().Where(x => x is MyValidationAttribute).Cast<MyValidationAttribute>();
                foreach (var attribute in attributes)
                {
                    bool result = attribute.IsValid(property.GetValue(obj));
                    if (!result)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
