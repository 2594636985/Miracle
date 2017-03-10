using System;

namespace Miracle.AomiToDB
{
    using Linq;

    public interface ITable<out T> : IExpressionQuery<T>
    {

    }
}
