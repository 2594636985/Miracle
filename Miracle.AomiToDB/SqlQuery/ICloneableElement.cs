using System;
using System.Collections.Generic;

namespace Miracle.AomiToDB.SqlQuery
{
	public interface ICloneableElement
	{
		ICloneableElement Clone(Dictionary<ICloneableElement,ICloneableElement> objectTree, Predicate<ICloneableElement> doClone);
	}
}
