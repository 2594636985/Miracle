using Miracle.Modularization.Aspects.Definitions;
using Miracle.Modularization.Aspects.Reflection.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Aspects
{
    internal sealed class ProxyGenerator : IProxyDefinitionVisitor
    {
        private readonly ITypeBuilder _typeBuilder;
        private readonly IInterceptionFilter _interceptionFilter;
        private readonly List<EventInfo> _eventInfos;
        private readonly List<PropertyInfo> _propertyInfos;
        private readonly List<MethodInfo> _methodInfos;

        public ProxyGenerator(ITypeBuilder typeBuilder, IInterceptionFilter interceptionFilter)
        {
            if (typeBuilder == null)
                throw new ArgumentNullException("typeBuilder");

            if (interceptionFilter == null)
                throw new ArgumentNullException("interceptionFilter");

            _typeBuilder = typeBuilder;
            _interceptionFilter = interceptionFilter;

            _eventInfos = new List<EventInfo>();
            _propertyInfos = new List<PropertyInfo>();
            _methodInfos = new List<MethodInfo>();
        }

        public IProxyTemplate GenerateProxyTemplate(IProxyDefinition proxyDefinition)
        {
            if (proxyDefinition == null)
                throw new ArgumentNullException("proxyDefinition");

            //这一步就是用于收集要切的方法和属性、事件
            proxyDefinition.AcceptVisitor(this);

            var type = _typeBuilder.CreateType();

            return new ProxyTemplate(proxyDefinition, type, _eventInfos, _propertyInfos, _methodInfos);
        }

        #region IProxyDefinitionVisitor Members

        public void VisitInterface(Type interfaceType)
        {
            _typeBuilder.AddInterface(interfaceType);
        }

        public void VisitConstructor(ConstructorInfo constructorInfo)
        {
            _typeBuilder.BuildConstructor(constructorInfo);
        }

        public void VisitEvent(EventInfo eventInfo)
        {
            if (_typeBuilder.IsConcreteEvent(eventInfo) && !_interceptionFilter.AcceptEvent(eventInfo))
                return;

            _typeBuilder.BuildEvent(eventInfo);
            _eventInfos.Add(eventInfo);
        }

        public void VisitProperty(PropertyInfo propertyInfo)
        {
            if (_typeBuilder.IsConcreteProperty(propertyInfo) && !_interceptionFilter.AcceptProperty(propertyInfo))
                return;

            _typeBuilder.BuildProperty(propertyInfo);
            _propertyInfos.Add(propertyInfo);
        }

        public void VisitMethod(MethodInfo methodInfo)
        {
            if (_typeBuilder.IsConcreteMethod(methodInfo) && !_interceptionFilter.AcceptMethod(methodInfo))
                return;

            _typeBuilder.BuildMethod(methodInfo);
            _methodInfos.Add(methodInfo);
        }

        #endregion
    }
}
