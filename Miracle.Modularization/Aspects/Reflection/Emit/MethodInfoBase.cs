using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Aspects.Reflection.Emit
{
    public abstract class MethodInfoBase : MethodInfo
    {
        private readonly object _source;
        private readonly MethodInfo _methodInfo;
        private readonly bool _isOverride;
        private readonly Type _declaringType;

        protected MethodInfoBase(object source, MethodInfo methodInfo, bool isOverride)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (methodInfo == null)
                throw new ArgumentNullException("methodInfo");

            _source = source;
            _methodInfo = methodInfo;
            _isOverride = isOverride;

            _declaringType = methodInfo.DeclaringType;
        }


        protected virtual object InvokeBase(object target, object[] parameters)
        {
            throw new NotImplementedException();
        }


        protected abstract object InvokeVirtual(object target, object[] parameters);

        #region MethodInfo Members

        public override sealed ParameterInfo ReturnParameter
        {
            get { return _methodInfo.ReturnParameter; }
        }

        public override sealed Type ReturnType
        {
            get { return _methodInfo.ReturnType; }
        }

        public override sealed ICustomAttributeProvider ReturnTypeCustomAttributes
        {
            get { return _methodInfo.ReturnTypeCustomAttributes; }
        }

        public override sealed MethodInfo GetBaseDefinition()
        {
            return _methodInfo.GetBaseDefinition();
        }

        public override sealed MethodInfo GetGenericMethodDefinition()
        {
            return _methodInfo.GetGenericMethodDefinition();
        }

        public override sealed MethodInfo MakeGenericMethod(params Type[] typeArguments)
        {
            return _methodInfo.MakeGenericMethod(typeArguments);
        }

        #endregion

        #region MethodBase Members

        public override sealed MethodAttributes Attributes
        {
            get { return _methodInfo.Attributes; }
        }

        public override sealed CallingConventions CallingConvention
        {
            get { return _methodInfo.CallingConvention; }
        }

        public override sealed bool ContainsGenericParameters
        {
            get { return _methodInfo.ContainsGenericParameters; }
        }

        public override sealed bool IsGenericMethod
        {
            get { return _methodInfo.IsGenericMethod; }
        }

        public override sealed bool IsGenericMethodDefinition
        {
            get { return _methodInfo.IsGenericMethodDefinition; }
        }

        public override sealed RuntimeMethodHandle MethodHandle
        {
            get { return _methodInfo.MethodHandle; }
        }

        public override sealed Type[] GetGenericArguments()
        {
            return _methodInfo.GetGenericArguments();
        }

        public override sealed MethodBody GetMethodBody()
        {
            return _methodInfo.GetMethodBody();
        }

        public override sealed MethodImplAttributes GetMethodImplementationFlags()
        {
            return _methodInfo.GetMethodImplementationFlags();
        }

        public override sealed ParameterInfo[] GetParameters()
        {
            return _methodInfo.GetParameters();
        }

        public override sealed object Invoke(object target, BindingFlags bindingFlags, Binder binder, object[] parameters, CultureInfo cultureInfo)
        {
            if (ReferenceEquals(target, _source))
            {
                if (_isOverride)
                    return InvokeBase(target, parameters);

                throw new TargetException("当前对象没有实现该方法");
            }

            if (target == null)
                throw new TargetException("方法的执行对象不能为空");

            var targetType = target.GetType();

            if (!_declaringType.IsAssignableFrom(targetType))
                throw new TargetException("执行对象不是当前对象的类型或继承");

            return InvokeVirtual(target, parameters);
        }

        #endregion

        #region ICustomAttributeProvider Members

        public override sealed object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            return _methodInfo.GetCustomAttributes(attributeType, inherit);
        }

        public override sealed object[] GetCustomAttributes(bool inherit)
        {
            return _methodInfo.GetCustomAttributes(inherit);
        }

        public override sealed bool IsDefined(Type attributeType, bool inherit)
        {
            return _methodInfo.IsDefined(attributeType, inherit);
        }

        #endregion

        #region MemberInfo Members

        public override sealed Type DeclaringType
        {
            get { return _declaringType; }
        }

        public override sealed MemberTypes MemberType
        {
            get { return _methodInfo.MemberType; }
        }

        public override sealed int MetadataToken
        {
            get { return _methodInfo.MetadataToken; }
        }

        public override sealed System.Reflection.Module Module
        {
            get { return _methodInfo.Module; }
        }

        public override sealed string Name
        {
            get { return _methodInfo.Name; }
        }

        public override sealed Type ReflectedType
        {
            get { return _methodInfo.ReflectedType; }
        }

        #endregion

        #region Object Members

        public override sealed bool Equals(object obj)
        {
            return _methodInfo.Equals(obj);
        }

        public override sealed int GetHashCode()
        {
            return _methodInfo.GetHashCode();
        }

        public override sealed string ToString()
        {
            return _methodInfo.ToString();
        }

        #endregion
    }
}
