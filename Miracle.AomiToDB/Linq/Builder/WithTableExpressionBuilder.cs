﻿using System;
using System.Linq.Expressions;
using Miracle.AomiToDB.Common;

namespace Miracle.AomiToDB.Linq.Builder
{
    using Miracle.AomiToDB.Expressions;
    using SqlQuery;

    class WithTableExpressionBuilder : MethodCallBuilder
    {
        protected override bool CanBuildMethodCall(ExpressionBuilder builder, MethodCallExpression methodCall, BuildInfo buildInfo)
        {
            return methodCall.IsQueryable("With", "WithTableExpression");
        }

        protected override IBuildContext BuildMethodCall(ExpressionBuilder builder, MethodCallExpression methodCall, BuildInfo buildInfo)
        {
            var sequence = builder.BuildSequence(new BuildInfo(buildInfo, methodCall.Arguments[0]));
            var table = (TableBuilder.TableContext)sequence;
            var value = (string)((ConstantExpression)methodCall.Arguments[1]).Value;

            table.SqlTable.SqlTableType = SqlTableType.Expression;
            table.SqlTable.TableArguments = new ISqlExpression[0];

            switch (methodCall.Method.Name)
            {
                case "With": table.SqlTable.Name = "{{0}} {{1}} WITH ({0})".Args(value); break;
                case "WithTableExpression": table.SqlTable.Name = value; break;
            }

            return sequence;
        }

        protected override SequenceConvertInfo Convert(
            ExpressionBuilder builder, MethodCallExpression methodCall, BuildInfo buildInfo, ParameterExpression param)
        {
            return null;
        }
    }
}
