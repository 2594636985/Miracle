using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Miracle.Injection
{
    public class ConstructorInjector
    {
        public Type Type { private set; get; }

        public List<IInjector> Injectors { private set; get; }

        public IContainer Container { private set; get; }

        public ConstructorInfo ConstructorInfo { private set; get; }

        public List<ParameterInjector> ParameterInjectors { private set; get; }

        public ConstructorInjector(IContainer container, Type type)
        {
            this.Container = container;
            this.Type = type;
            this.ConstructorInfo = this.GetConstructorInfo(type);
            this.ParameterInjectors = new List<ParameterInjector>();

            ParameterInfo[] parameterInfos = this.ConstructorInfo.GetParameters();

            if (parameterInfos != null && parameterInfos.Length > 0)
            {
                foreach (ParameterInfo parameterInfo in parameterInfos)
                {
                    InjectAttribute injectionAttribute = parameterInfo.GetCustomAttributeEx<InjectAttribute>();
                    string injectValue = injectionAttribute.Value ?? parameterInfo.ParameterType.FullName;
                    Identity identity = new Identity(parameterInfo.ParameterType.TypeHandle, injectValue);
                    this.ParameterInjectors.Add(new ParameterInjector(container, container.GetFactory(identity)));
                }
            }

            this.Injectors = container.GetInjectors(type);
        }

        private ConstructorInfo GetConstructorInfo(Type type)
        {
            ConstructorInfo finalConstructorInfo = null;
            ConstructorInfo[] declaredConstructorInfos = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            foreach (ConstructorInfo declaredConstructorInfo in declaredConstructorInfos)
            {
                if (declaredConstructorInfo.GetCustomAttributeEx<InjectAttribute>() != null)
                {
                    if (finalConstructorInfo != null)
                        throw new InvalidOperationException("在注入{0}类型的时候，发现了多个注入方式".FormatEx(type.Name));

                    finalConstructorInfo = declaredConstructorInfo;
                }
            }

            if (finalConstructorInfo != null)
                return finalConstructorInfo;

            if (declaredConstructorInfos.Length == 1)
            {
                finalConstructorInfo = declaredConstructorInfos[0];
            }
            else
            {
                finalConstructorInfo = type.GetConstructor(new Type[0]);
            }

            return finalConstructorInfo;
        }


        public object Construct()
        {
            object[] parameters = new object[this.ParameterInjectors.Count];

            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = this.ParameterInjectors[i].inject();
            }

            return this.ConstructorInfo.Invoke(parameters);
        }
    }
}
