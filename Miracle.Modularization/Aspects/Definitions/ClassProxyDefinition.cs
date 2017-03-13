using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Aspects.Definitions
{
    /// <summary>
    /// 类的代理定义类
    /// </summary>
    public sealed class ClassProxyDefinition : ProxyDefinitionBase
    {
        public ClassProxyDefinition(Type declaringType, IEnumerable<Type> interfaceTypes)
            : base(declaringType, declaringType, interfaceTypes)
        {
        }

        public override IEnumerable<Type> ImplementedInterfaces
        {
            get { return DeclaringInterfaces.Concat(AdditionalInterfaces); }
        }

        /// <summary>
        /// 方法当前类型所有的信息 包含有字段、属性、事件等
        /// </summary>
        /// <param name="proxyDefinitionVisitor"></param>
        public override void AcceptVisitor(IProxyDefinitionVisitor proxyDefinitionVisitor)
        {
            base.AcceptVisitor(proxyDefinitionVisitor);

            proxyDefinitionVisitor.VisitMembers(DeclaringType);
        }

        public override object UnwrapProxy(object proxy)
        {
            if (proxy == null)
                throw new ArgumentNullException("proxy");

            return proxy;
        }

        /// <summary>
        /// 创建代理对象
        /// </summary>
        /// <param name="type"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public override object CreateProxy(Type type, object[] arguments)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (arguments == null)
                throw new ArgumentNullException("arguments");

            return Activator.CreateInstance(type, arguments);
        }

    }
}
