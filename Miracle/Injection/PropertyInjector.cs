using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Miracle.Injection
{
    public class PropertyInjector : IInjector
    {
        public IContainer Container { private set; get; }
        public InternalFactory InternalFactory { private set; get; }
        public PropertyInfo PropertyInfo { private set; get; }

        public PropertyInjector(IContainer container, PropertyInfo propertyInfo, string name)
        {
            this.Container = container;
            this.PropertyInfo = propertyInfo;
            this.InternalFactory = container.GetFactory(propertyInfo.PropertyType);
        }

        public void Inject(object instance)
        {
            this.PropertyInfo.SetValue(instance, this.InternalFactory.NewInstance(this.Container), null);
        }
    }
}
