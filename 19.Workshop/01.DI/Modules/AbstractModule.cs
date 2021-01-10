using _01.DI.Attributes;
using _01.DI.Modules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.DI.Modules
{
    public abstract class AbstractModule : IModule
    {
        private IDictionary<Type, Dictionary<string, Type>> mappings;
        private IDictionary<Type, object> instances;

        protected AbstractModule(IDictionary<Type, Dictionary<string, Type>> mappings, IDictionary<Type, object> instances)
        {
            this.mappings = mappings;
            this.instances = instances;
        }
        
        protected void CreateMapping<TInterface, TImplementation>()
        {
            if (!mappings.ContainsKey(typeof(TInterface)))
            {
                mappings.Add(typeof(TInterface), new Dictionary<string, Type>());
            }
            mappings[typeof(TInterface)].Add(typeof(TImplementation).Name, typeof(TImplementation));
        }

        public abstract void Configure();

        public Type GetMapping(Type currentInterfaceType, object attribute)
        {
            var currentMappings = mappings[currentInterfaceType];
            Type type = null;

            if (attribute is Inject)
            {
                if (currentMappings.Count == 1)
                {
                    type = currentMappings.Values.First();
                }
                else
                {
                    throw new ArgumentException($"No available mapping for class: {currentInterfaceType.FullName}");
                }
            }
            else if (attribute is Named)
            {
                Named named = attribute as Named;
                type = currentMappings[named.Name];
            }
            return type;
        }

        public object GetInstance(Type type)
        {
            instances.TryGetValue(type, out object value);
            return value;
        }

        public void SetInstance(Type currentInstanceType, object instance)
        {
            if (!instances.ContainsKey(currentInstanceType))
            {
                instances.Add(currentInstanceType, instance);
            }
        }
    }
}
