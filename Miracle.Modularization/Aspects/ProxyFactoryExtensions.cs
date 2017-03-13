using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Aspects
{
    public static class ProxyFactoryExtensions
    {
        /// <summary>
        /// 获得代理类的代理模板
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proxyFactory"></param>
        /// <param name="interfaceTypes"></param>
        /// <returns></returns>
        public static IProxyTemplate<T> GetProxyTemplate<T>(this IProxyFactory proxyFactory, IEnumerable<Type> interfaceTypes) where T : class
        {
            var proxyTemplate = proxyFactory.GetProxyTemplate(typeof(T), interfaceTypes);

            return new ProxyTemplate<T>(proxyTemplate);
        }

        /// <summary>
        /// 根据当前参数类型和接口建立代理类
        /// </summary>
        /// <param name="proxyFactory"></param>
        /// <param name="declaringType"></param>
        /// <param name="interfaceTypes"></param>
        /// <param name="invocationHandler"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static object CreateProxy(this IProxyFactory proxyFactory, Type declaringType, IEnumerable<Type> interfaceTypes, IInvocationHandler invocationHandler, params object[] arguments)
        {
            if (proxyFactory == null)
                throw new ArgumentNullException("proxyFactory");

            var proxyTemplate = proxyFactory.GetProxyTemplate(declaringType, interfaceTypes);

            return proxyTemplate.CreateProxy(invocationHandler, arguments);
        }

        /// <summary>
        /// 根据当前参数类型和接口建立代理类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proxyFactory"></param>
        /// <param name="interfaceTypes"></param>
        /// <param name="invocationHandler"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static T CreateProxy<T>(this IProxyFactory proxyFactory, IEnumerable<Type> interfaceTypes, IInvocationHandler invocationHandler, params object[] arguments) where T : class
        {
            if (proxyFactory == null)
                throw new ArgumentNullException("proxyFactory");

            var proxyTemplate = proxyFactory.GetProxyTemplate<T>(interfaceTypes);

            return proxyTemplate.CreateProxy(invocationHandler, arguments);
        }

        /// <summary>
        /// 根据当前参数类型和接口建立代理类
        /// </summary>
        /// <param name="proxyFactory"></param>
        /// <param name="declaringType"></param>
        /// <param name="invocationHandler"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static object CreateProxy(this IProxyFactory proxyFactory, Type declaringType, IInvocationHandler invocationHandler, params object[] arguments)
        {
            return proxyFactory.CreateProxy(declaringType, Type.EmptyTypes, invocationHandler, arguments);
        }
    }
}
