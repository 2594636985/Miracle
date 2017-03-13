using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Aspects
{
    using Caching;
    using Definitions;
    using Reflection;
    using Reflection.Emit;
    /// <summary>
    /// 代理工厂类
    /// </summary>
    public sealed class ProxyFactory : IProxyFactory
    {
        private readonly ITypeBuilderFactory _typeBuilderFactory;
        private readonly IInterceptionFilter _interceptionFilter;
        private readonly ICache<IProxyDefinition, IProxyTemplate> _proxyTemplateCache;//

        public ProxyFactory()
            : this(new NonInterceptedInterceptionFilter())
        { }

        public ProxyFactory(IInterceptionFilter interceptionFilter)
            : this(new ProxyTypeBuilderFactory(false), interceptionFilter)
        { }

        public ProxyFactory(ITypeBuilderFactory typeBuilderFactory, IInterceptionFilter interceptionFilter)
        {
            if (typeBuilderFactory == null)
                throw new ArgumentNullException("typeBuilderFactory");

            if (interceptionFilter == null)
                throw new ArgumentNullException("interceptionFilter");

            _typeBuilderFactory = typeBuilderFactory;
            _interceptionFilter = interceptionFilter;

            _proxyTemplateCache = new LockOnWriteCache<IProxyDefinition, IProxyTemplate>();
        }

        /// <summary>
        /// 获得代理定义类
        /// </summary>
        /// <param name="declaringType"></param>
        /// <param name="interfaceTypes"></param>
        /// <returns></returns>
        private static IProxyDefinition CreateProxyDefinition(Type declaringType, IEnumerable<Type> interfaceTypes)
        {
            if (declaringType.IsDelegate())
                return new DelegateProxyDefinition(declaringType, interfaceTypes);

            if (declaringType.IsInterface)
                return new InterfaceProxyDefinition(declaringType, interfaceTypes);

            return new ClassProxyDefinition(declaringType, interfaceTypes);
        }

        private IProxyTemplate GenerateProxyTemplate(IProxyDefinition proxyDefinition)
        {
            var typeBuilder = _typeBuilderFactory.CreateBuilder(proxyDefinition.ParentType);
            var proxyGenerator = new ProxyGenerator(typeBuilder, _interceptionFilter);

            return proxyGenerator.GenerateProxyTemplate(proxyDefinition);
        }
        
        public IProxyTemplate GetProxyTemplate(Type declaringType, IEnumerable<Type> interfaceTypes)
        {
            if (declaringType == null)
                throw new ArgumentNullException("declaringType");

            if (interfaceTypes == null)
                throw new ArgumentNullException("interfaceTypes");

            var proxyDefinition = CreateProxyDefinition(declaringType, interfaceTypes);

            return _proxyTemplateCache.GetOrAdd(proxyDefinition, GenerateProxyTemplate);
        }
    }
}
