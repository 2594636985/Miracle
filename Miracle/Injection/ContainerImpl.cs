using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Injection
{
    /// <summary>
    /// 存放对象的容器
    /// </summary>
    public class ContainerImpl : IContainer
    {
        public Dictionary<Identity, InternalFactory> InternalFactorys { private set; get; }

        public ConcurrentDictionary<Type, List<IInjector>> Injectors { private set; get; }

        public ConcurrentDictionary<Type, ConstructorInjector> Constructors { private set; get; }

        public ContainerImpl(Dictionary<Identity, InternalFactory> internalFactorys)
        {
            this.Injectors = new ConcurrentDictionary<Type, List<IInjector>>();
            this.InternalFactorys = new Dictionary<Identity, InternalFactory>(internalFactorys);
            this.Constructors = new ConcurrentDictionary<Type, ConstructorInjector>();
        }


        /// <summary>
        /// 对存在的实例进行注入
        /// </summary>
        /// <param name="instance"></param>
        public void Inject(object instance)
        {
            List<IInjector> typeInjectors = this.GetInjectors(instance.GetType());

            foreach (IInjector typeInjector in typeInjectors)
            {
                typeInjector.Inject(instance);
            }
        }


        #region GetInjectors的功能
        public List<IInjector> GetInjectors(Type type)
        {
            return this.Injectors.GetOrAdd(type, this.InitializeInjector);
        }
        /// <summary>
        /// 初始化注入列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private List<IInjector> InitializeInjector(Type type)
        {
            List<IInjector> injectors = new List<IInjector>();
            if (type != typeof(object))
            {
                PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    InjectAttribute injectionAttribute = propertyInfo.GetCustomAttributeEx<InjectAttribute>();
                    if (injectionAttribute != null)
                    {
                        string name = injectionAttribute.Value ?? propertyInfo.Name;
                        injectors.Add(new PropertyInjector(this, propertyInfo, name));
                    }
                }
            }

            return injectors;
        }

        #endregion

        #region GetConstructor的功能
        public ConstructorInjector GetConstructor(Type type)
        {
            return this.Constructors.GetOrAdd(type, this.InitializeConstructor);
        }

        private ConstructorInjector InitializeConstructor(Type type)
        {
            return new ConstructorInjector(this, type);
        }

        #endregion

        public InternalFactory GetFactory(Identity identity)
        {
            if (this.InternalFactorys.ContainsKey(identity))
                return this.InternalFactorys[identity];
            return null;
        }

        public InternalFactory GetFactory(Type type)
        {
            return this.GetFactory(new Identity(type.TypeHandle, type.FullName));
        }

        public object GetInstance(Type type)
        {
            return this.GetFactory(type).NewInstance(this);
        }
    }
}
