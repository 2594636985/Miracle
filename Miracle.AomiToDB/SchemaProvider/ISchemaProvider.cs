using System;

namespace Miracle.AomiToDB.SchemaProvider
{
	using Data;

	public interface ISchemaProvider
	{
		DatabaseSchema GetSchema(DataConnection dataConnection, GetSchemaOptions options = null);
	}
}
