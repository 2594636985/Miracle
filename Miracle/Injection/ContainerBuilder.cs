using Miracle.Injection.Activator;
using Miracle.Injection.Factory;
using Miracle.Injection.Lifecycle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Injection
{
    public class ContainerBuilder
    {
        public Dictionary<Identity, InternalFactory> InternalFactorys { private set; get; }

        public ContainerBuilder()
        {
            this.InternalFactorys = new Dictionary<Identity, InternalFactory>();
        }

        public IContainer Build()
        {
            return new ContainerImpl(this.InternalFactorys);
        }

        public InternalFactoryBuilder Register(object instance)
        {
            return this.Register(instance.GetType(), instance);
        }

        public InternalFactoryBuilder Register(Type type, object instance)
        {
            InternalFactory newInternalFactory = new InternalFactory();
            newInternalFactory.Activator = new InstanceActivator(instance);
            newInternalFactory.Lifecycle = new SingletonLifecycle();

            this.InternalFactorys.Add(new Identity(type.TypeHandle, type.FullName), newInternalFactory);

            return new InternalFactoryBuilder(newInternalFactory);
        }

        public InternalFactoryBuilder Register(Type registerType)
        {
            return this.Register(registerType.TypeHandle, registerType.Name, registerType);
        }

        public InternalFactoryBuilder Register(Type type, Type iType)
        {
            return this.Register(iType.TypeHandle, iType.Name, type);
        }

        public InternalFactoryBuilder Register(Type type, string name, Type implementation)
        {
            return this.Register(type);
        }

        public InternalFactoryBuilder Register(RuntimeTypeHandle typeHandle, string keyName, Type registerType)
        {
            InternalFactory newInternalFactory = new InternalFactory();
            newInternalFactory.Activator = new ReflectionActivator(registerType);

            this.InternalFactorys.Add(new Identity(typeHandle, keyName), newInternalFactory);

            return new InternalFactoryBuilder(newInternalFactory);
        }

        public InternalFactoryBuilder Register(Type registerType, InternalFactory newInternalFactory)
        {
            this.InternalFactorys.Add(new Identity(registerType.TypeHandle, registerType.FullName), newInternalFactory);

            return new InternalFactoryBuilder(newInternalFactory);
        }




    }
}
