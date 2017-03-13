using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Miracle.Modularization.Aspects.Reflection
{
    public struct MemberToken : IEquatable<MemberToken>
    {
        private readonly Type _declaringType;
        private readonly int _metadataToken;

        public MemberToken(MemberInfo memberInfo)
        {
            if (memberInfo == null)
                throw new ArgumentNullException("memberInfo");

            _declaringType = memberInfo.DeclaringType;
            _metadataToken = memberInfo.MetadataToken;
        }

        public bool Equals(MemberToken other)
        {
            if (other._declaringType != _declaringType)
                return false;

            return (other._metadataToken == _metadataToken);
        }

        public override int GetHashCode()
        {
            return _metadataToken;
        }

        public override bool Equals(object obj)
        {
            return (obj is MemberToken) && Equals((MemberToken)obj);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(_declaringType);
            sb.Append(Type.Delimiter);
            sb.Append(_metadataToken);

            return sb.ToString();
        }

    }
}
