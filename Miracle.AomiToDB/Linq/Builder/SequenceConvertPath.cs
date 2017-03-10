using System;
using System.Diagnostics;
using System.Linq.Expressions;



namespace Miracle.AomiToDB.Linq.Builder
{
	[DebuggerDisplay("Path = {Path}, Expr = {Expr}, Level = {Level}")]
	public class SequenceConvertPath
	{
		 public Expression Path;
		 public Expression Expr;
		          public int        Level;
	}
}
