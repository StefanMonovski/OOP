using System;
using System.Collections.Generic;
using System.Text;

namespace _01.DI.Modules.Interfaces
{
    public interface IModule
    {
        void Configure();

        Type GetMapping(Type currentInterfaceType, object attribute);

        object GetInstance(Type type);

        void SetInstance(Type currentInstanceType, object instance);
    }
}
