using _01.DI.Injectors;
using _01.DI.Modules.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.DI
{
    class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}
