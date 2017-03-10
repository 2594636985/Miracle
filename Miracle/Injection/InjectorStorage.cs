using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Injection
{
    public class InjectorStorage : Dictionary<Type, List<IInjector>>
    {
        public IContainer Container { private set; get; }

        public InjectorStorage(IContainer container)
        {
            this.Container = container;
        }

        public List<IInjector> GetInjectors(Type type)
        {
            if (!this.ContainsKey(type))
            {
                List<IInjector> injectors = new List<IInjector>();
                this.InitializeInjector(type, injectors);
                this.Add(type, injectors);
            }

            return this[type];
        }

        private void InitializeInjector(Type type, List<IInjector> injectors)
        {
            if (type == typeof(object))
                return;

            InitializeInjector(type.BaseType, injectors);

            PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                InjectAttribute injectionAttribute = propertyInfo.GetCustomAttributeEx<InjectAttribute>();
                if (injectionAttribute != null)
                {
                    string name = injectionAttribute.Value ?? propertyInfo.Name;
                    injectors.Add(new PropertyInjector(this.Container, propertyInfo, name));
                }
            }
        }



    }
}
