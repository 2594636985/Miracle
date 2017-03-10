using System;
using System.Linq.Expressions;

namespace Miracle.AomiToDB.Linq
{
	using Mapping;

	public interface IExpressionInfo
	{
		LambdaExpression GetExpression(MappingSchema mappingSchema);
	}
}
