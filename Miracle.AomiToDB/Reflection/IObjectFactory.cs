using System;

namespace Miracle.AomiToDB.Reflection
{
    /// <summary>
    /// ���󹤳�
    /// </summary>
	public interface IObjectFactory
	{
		object CreateInstance(TypeAccessor typeAccessor);
	}
}
