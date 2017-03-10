using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Miracle.AomiToDB.Linq.Builder
{
	public class SequenceConvertInfo
	{
		public ParameterExpression       Parameter;
		public Expression                Expression;
		public List<SequenceConvertPath> ExpressionsToReplace;
	}
}
