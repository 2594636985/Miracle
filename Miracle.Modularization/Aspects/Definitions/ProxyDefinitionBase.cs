using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Aspects.Definitions
{
    /// <summary>
    /// 定义代理类的基类
    /// </summary>
    public abstract class ProxyDefinitionBase : IProxyDefinition, IEquatable<ProxyDefinitionBase>
    {
        private readonly Type _declaringType;//声名的类型
        private readonly Type _parentType;//类型的父类
        private readonly HashSet<Type> _declaringInterfaceTypes;//声名类型的接口集合
        private readonly HashSet<Type> _additionalInterfaceTypes;//额外增加的接口集合


        /// <summary>
        /// 获得当前声名类型
        /// </summary>
        public Type DeclaringType
        {
            get { return _declaringType; }
        }

        /// <summary>
        /// 获得当前声名类型
        /// </summary>
        public Type ParentType
        {
            get { return _parentType; }
        }

        /// <summary>
        /// 获得当前声名类型的接口集合
        /// </summary>
        protected IEnumerable<Type> DeclaringInterfaces
        {
            get { return _declaringInterfaceTypes; }
        }

        /// <summary>
        /// 获得当前类型的额外接口集合
        /// </summary>
        protected IEnumerable<Type> AdditionalInterfaces
        {
            get { return _additionalInterfaceTypes; }
        }

        protected ProxyDefinitionBase(Type declaringType, Type parentType, IEnumerable<Type> interfaceTypes)
        {
            if (declaringType == null)
                throw new ArgumentNullException("declaringType");

            if (parentType == null)
                throw new ArgumentNullException("parentType");

            if (interfaceTypes == null)
                throw new ArgumentNullException("interfaceTypes");

            _declaringType = declaringType;
            _parentType = parentType;
            _declaringInterfaceTypes = ExtractInterfaces(declaringType);
            _additionalInterfaceTypes = ExtractAdditionalInterfaces(interfaceTypes, _declaringInterfaceTypes);
        }

        /// <summary>
        /// 提取当前类型的接口集合
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static HashSet<Type> ExtractInterfaces(Type type)
        {
            var interfaceTypes = new HashSet<Type>();

            if (type.IsInterface)
                interfaceTypes.Add(type);

            var inheritedInterfaceTypes = type.GetInterfaces();

            interfaceTypes.UnionWith(inheritedInterfaceTypes);

            return interfaceTypes;
        }

        /// <summary>
        /// 提取当类型的额外接口集合
        /// </summary>
        /// <param name="interfaceTypes"></param>
        /// <param name="declaringInterfaceTypes"></param>
        /// <returns></returns>
        private static HashSet<Type> ExtractAdditionalInterfaces(IEnumerable<Type> interfaceTypes, ICollection<Type> declaringInterfaceTypes)
        {
            var additionalInterfaceTypes = new HashSet<Type>();

            foreach (var interfaceType in interfaceTypes)
            {
                AddAdditionalInterfaces(interfaceType, declaringInterfaceTypes, additionalInterfaceTypes);
            }

            return additionalInterfaceTypes;
        }

        /// <summary>
        /// 增加额外的接口
        /// </summary>
        /// <param name="interfaceType"></param>
        /// <param name="declaringInterfaceTypes"></param>
        /// <param name="additionalInterfaceTypes"></param>
        private static void AddAdditionalInterfaces(Type interfaceType, ICollection<Type> declaringInterfaceTypes, HashSet<Type> additionalInterfaceTypes)
        {
            if (interfaceType == null)
                throw new ArgumentNullException("interfaceType");

            if (!interfaceType.IsInterface)
                throw new ArgumentException("类型{0}不是一个接口".FormatEx(interfaceType), "interfaceType");

            if (interfaceType.IsGenericTypeDefinition)
                throw new ArgumentException("类型{0}不能是一个泛型类".FormatEx(interfaceType), "interfaceType");

            if (declaringInterfaceTypes.Contains(interfaceType))
                return;

            if (!additionalInterfaceTypes.Add(interfaceType))
                return;

            var inheritedInterfaceTypes = interfaceType.GetInterfaces();

            foreach (var inheritedInterfaceType in inheritedInterfaceTypes)
            {
                if (declaringInterfaceTypes.Contains(inheritedInterfaceType))
                    continue;

                additionalInterfaceTypes.Add(inheritedInterfaceType);
            }
        }

        public abstract IEnumerable<Type> ImplementedInterfaces { get; }

        public virtual void AcceptVisitor(IProxyDefinitionVisitor proxyDefinitionVisitor)
        {
            if (proxyDefinitionVisitor == null)
                throw new ArgumentNullException("proxyDefinitionVisitor");

            proxyDefinitionVisitor.VisitConstructors(_parentType);
            proxyDefinitionVisitor.VisitInterfaces(_additionalInterfaceTypes);
        }

        public abstract object UnwrapProxy(object proxy);

        public abstract object CreateProxy(Type type, object[] arguments);

        public bool Equals(ProxyDefinitionBase other)
        {
            if (other == null)
                return false;

            if (other._declaringType != _declaringType)
                return false;

            if (other._parentType != _parentType)
                return false;

            var additionalInterfaceTypes = other._additionalInterfaceTypes;

            if (additionalInterfaceTypes.Count != _additionalInterfaceTypes.Count)
                return false;

            return additionalInterfaceTypes.All(_additionalInterfaceTypes.Contains);
        }

        public override bool Equals(object obj)
        {
            return (obj is ProxyDefinitionBase) && Equals((ProxyDefinitionBase)obj);
        }

        public override int GetHashCode()
        {
            return _declaringType.GetHashCode();
        }

    }
}
