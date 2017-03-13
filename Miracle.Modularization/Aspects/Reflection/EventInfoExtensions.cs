using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Aspects.Reflection
{
    public static class EventInfoExtensions
    {

        public static bool CanOverride(this EventInfo eventInfo)
        {
            if (eventInfo == null)
                throw new ArgumentNullException("eventInfo");

            var methodInfos = eventInfo.GetAccessorMethods();

            return methodInfos.All(m => m.CanOverride());
        }

        public static IEnumerable<MethodInfo> GetAccessorMethods(this EventInfo eventInfo)
        {
            if (eventInfo == null)
                throw new ArgumentNullException("eventInfo");

            var methodInfos = new List<MethodInfo>
            {
                eventInfo.GetAddMethod(true),
                eventInfo.GetRemoveMethod(true)
            };

            var raiseMethodInfo = eventInfo.GetRaiseMethod(true);

            if (raiseMethodInfo != null)
                methodInfos.Add(raiseMethodInfo);

            var otherMethodInfos = eventInfo.GetOtherMethods(true);

            if (otherMethodInfos != null)
                methodInfos.AddRange(otherMethodInfos);

            return methodInfos;
        }


        public static string GetFullName(this EventInfo eventInfo)
        {
            if (eventInfo == null)
                throw new ArgumentNullException("eventInfo");

            var fullName = new StringBuilder();

            fullName.Append(eventInfo.DeclaringType);
            fullName.Append(Type.Delimiter);
            fullName.Append(eventInfo.Name);

            return fullName.ToString();
        }
    }
}
