using _01.DI.Attributes;
using _01.DI.Modules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _01.DI.Injectors
{
    public class Injector
    {
        private IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass).GetFields((BindingFlags) 62).Any(x => x.GetCustomAttributes(typeof(Inject), true).Any());
        }

        private bool CheckForConstructorInjection<TClass>()
        {
            return typeof(TClass).GetConstructors().Any(x => x.GetCustomAttributes(typeof(Inject), true).Any());
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            Type classType = typeof(TClass);
            if (classType == null)
            {
                return default(TClass);
            }

            ConstructorInfo[] constructors = classType.GetConstructors();
            foreach (var constructor in constructors)
            {
                if (!CheckForConstructorInjection<TClass>())
                {
                    continue;
                }

                Inject inject = (Inject)constructor.GetCustomAttributes(typeof(Inject), true).FirstOrDefault();
                ParameterInfo[] parametersInfo = constructor.GetParameters();
                var constructorParams = new object[parametersInfo.Length];
                int i = 0;
                foreach (var parameterInfo in parametersInfo)
                {
                    Named named = (Named)parameterInfo.GetCustomAttribute(typeof(Named));
                    Type parameterMapping = null;

                    if (named == null)
                    {
                        parameterMapping = module.GetMapping(parameterInfo.ParameterType, inject);
                    }
                    else
                    {
                        parameterMapping = module.GetMapping(parameterInfo.ParameterType, named);
                    }

                    if (parameterInfo.ParameterType.IsAssignableFrom(parameterMapping))
                    {
                        object parameterInstance = module.GetInstance(parameterMapping);
                        if (parameterInstance != null)
                        {
                            constructorParams[i++] = parameterInstance;
                        }
                        else
                        {
                            parameterInstance = Activator.CreateInstance(parameterMapping);
                            constructorParams[i++] = parameterInstance;
                            module.SetInstance(parameterMapping, parameterInstance);
                        }
                    }
                }
                return (TClass)Activator.CreateInstance(classType, constructorParams);
            }
            return default(TClass);
        }

        private TClass CreateFieldInjection<TClass>()
        {
            Type classType = typeof(TClass);
            object classInstance = module.GetInstance(classType);
            if (classInstance == null)
            {
                classInstance = Activator.CreateInstance(classType);
                module.SetInstance(classType, classInstance);
            }

            FieldInfo[] fieldsInfo = classType.GetFields((BindingFlags)62);
            foreach (var fieldInfo in fieldsInfo)
            {
                if (fieldInfo.GetCustomAttributes(typeof(Inject), true).Any())
                {
                    Inject inject = (Inject)fieldInfo.GetCustomAttributes(typeof(Inject), true).FirstOrDefault();
                    Named named = (Named)fieldInfo.GetCustomAttribute(typeof(Named), true);
                    Type fieldMapping = null;

                    if (named == null)
                    {
                        fieldMapping = module.GetMapping(fieldInfo.FieldType, inject);
                    }
                    else
                    {
                        fieldMapping = module.GetMapping(fieldInfo.FieldType, named);
                    }

                    if (fieldInfo.FieldType.IsAssignableFrom(fieldMapping))
                    {
                        object fieldInstance = module.GetInstance(fieldMapping);
                        if (fieldInstance == null)
                        {
                            fieldInstance = Activator.CreateInstance(fieldMapping);
                            module.SetInstance(fieldMapping, fieldInstance);
                        }
                        fieldInfo.SetValue(classInstance, fieldInstance);
                    }
                } 
            }
            return (TClass)classInstance;
        }

        public TClass Inject<TClass>()
        {
            bool hasConstructorAttribute = CheckForConstructorInjection<TClass>();
            bool hasFieldAttribute = CheckForFieldInjection<TClass>();

            if (hasConstructorAttribute && hasFieldAttribute)
            {
                throw new ArgumentException("There must be only fields or constructors annotated with attribute");
            }

            if (hasConstructorAttribute)
            {
                return CreateConstructorInjection<TClass>();
            }
            else if (hasFieldAttribute)
            {
                return CreateFieldInjection<TClass>();
            }
            return default(TClass);
        }
    }
}
