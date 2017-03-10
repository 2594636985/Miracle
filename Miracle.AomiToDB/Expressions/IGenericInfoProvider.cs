using System;

namespace Miracle.AomiToDB.Expressions
{
	using Mapping;

	public interface IGenericInfoProvider
	{
		void SetInfo(MappingSchema mappingSchema);
	}
}
