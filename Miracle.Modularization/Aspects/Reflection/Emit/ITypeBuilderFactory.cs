using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Aspects.Reflection.Emit
{
    /// <summary>
    /// 创建类型生成类工厂
    /// </summary>
    public interface ITypeBuilderFactory
    {
        ITypeBuilder CreateBuilder(Type parentType);
    }
}
