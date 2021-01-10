using System;
using System.Collections.Generic;
using System.Text;

namespace _01.DI.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field)]
    public class Inject : Attribute
    {
    }
}
