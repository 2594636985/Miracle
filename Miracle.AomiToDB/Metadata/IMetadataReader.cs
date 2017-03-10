using System;
using System.Reflection;

namespace Miracle.AomiToDB.Metadata
{
    /// <summary>
    /// 元据数读取者
    /// </summary>
	public interface IMetadataReader
	{
        /// <summary>
        /// 根据Type获得对应的用户注解类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
		T[] GetAttributes<T>(Type type,             bool inherit = true) where T : Attribute;
        /// <summary>
        /// 根据MemberInfo获得对应的用户注解类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="memberInfo"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
		T[] GetAttributes<T>(MemberInfo memberInfo, bool inherit = true) where T : Attribute;
	}
}
