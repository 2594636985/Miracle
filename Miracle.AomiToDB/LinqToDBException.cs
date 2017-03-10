using System;
using System.Runtime.Serialization;

namespace Miracle.AomiToDB
{

	[Serializable]
	public class AomiToDBException : Exception
	{
		public AomiToDBException()
			: base("A Build Type exception has occurred.")
		{
		}

		public AomiToDBException(string message)
			: base(message)
		{
		}
		
		public AomiToDBException(string message, Exception innerException) 
			: base(message, innerException)
		{
		}

		public AomiToDBException(Exception innerException) 
			: base(innerException.Message, innerException)
		{
		}

		protected AomiToDBException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
