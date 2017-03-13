using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Aspects.Definitions
{
    using Reflection;

    public static class ProxyDefinitionVisitorExtensions
    {

        public static void VisitInterfaces(this IProxyDefinitionVisitor proxyDefinitionVisitor, IEnumerable<Type> interfaceTypes)
        {
            foreach (var interfaceType in interfaceTypes)
            {
                proxyDefinitionVisitor.VisitInterface(interfaceType);

                proxyDefinitionVisitor.VisitMembers(interfaceType);
            }
        }

        public static void VisitConstructors(this IProxyDefinitionVisitor proxyDefinitionVisitor, Type type)
        {
            if (proxyDefinitionVisitor == null)
                throw new ArgumentNullException("proxyDefinitionVisitor");

            if (type == null)
                throw new ArgumentNullException("type");

            var constructorInfos = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            foreach (var constructorInfo in constructorInfos)
            {
                proxyDefinitionVisitor.VisitConstructor(constructorInfo);
            }
        }


        public static void VisitMembers(this IProxyDefinitionVisitor proxyDefinitionVisitor, Type type)
        {
            proxyDefinitionVisitor.VisitMethods(type);
        }

        private static void VisitEvents(this IProxyDefinitionVisitor proxyDefinitionVisitor, Type type)
        {
            if (proxyDefinitionVisitor == null)
                throw new ArgumentNullException("proxyDefinitionVisitor");

            if (type == null)
                throw new ArgumentNullException("type");

            var eventInfos = type.GetEvents(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                .Where(e => e.CanOverride());

            foreach (var eventInfo in eventInfos)
            {
                proxyDefinitionVisitor.VisitEvent(eventInfo);
            }
        }


        private static void VisitProperties(this IProxyDefinitionVisitor proxyDefinitionVisitor, Type type)
        {
            if (proxyDefinitionVisitor == null)
                throw new ArgumentNullException("proxyDefinitionVisitor");

            if (type == null)
                throw new ArgumentNullException("type");


            var propertyInfos = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanOverride());

            foreach (var propertyInfo in propertyInfos)
            {
                proxyDefinitionVisitor.VisitProperty(propertyInfo);
            }
        }


        private static void VisitMethods(this IProxyDefinitionVisitor proxyDefinitionVisitor, Type type)
        {
            if (proxyDefinitionVisitor == null)
                throw new ArgumentNullException("proxyDefinitionVisitor");

            if (type == null)
                throw new ArgumentNullException("type");

            var methodInfos = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).Where(m => !m.IsSpecialName  && !m.IsFromObject());

            foreach (var methodInfo in methodInfos)
            {
                proxyDefinitionVisitor.VisitMethod(methodInfo);
            }
        }
    }
}
