using System;
using System.Reflection;


namespace Miracle.AomiToDB.Metadata
{
    using Extensions;

    /// <summary>
    /// 注解读取者
    /// </summary>
    public class AttributeReader : IMetadataReader
    {
        public T[] GetAttributes<T>(Type type, bool inherit = true)
            where T : Attribute
        {
            var attrs = type.GetCustomAttributesEx(typeof(T), inherit);
            var arr = new T[attrs.Length];

            for (var i = 0; i < attrs.Length; i++)
                arr[i] = (T)attrs[i];

            return arr;
        }

        public T[] GetAttributes<T>(MemberInfo memberInfo, bool inherit = true)
            where T : Attribute
        {
            var attrs = memberInfo.GetCustomAttributesEx(typeof(T), inherit);
            var arr = new T[attrs.Length];

            for (var i = 0; i < attrs.Length; i++)
                arr[i] = (T)attrs[i];

            return arr;
        }
    }
}
