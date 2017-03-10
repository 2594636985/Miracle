using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Injection
{
    public class Identity : IEquatable<Identity>
    {
        public RuntimeTypeHandle TypeHandle { private set; get; }
        public string KeyName { private set; get; }

        public Identity(RuntimeTypeHandle typeHandle, string keyName)
        {
            this.TypeHandle = typeHandle;
            this.KeyName = keyName;
        }

        public override int GetHashCode()
        {
            if (this.KeyName == null)
                return this.TypeHandle.GetHashCode();

            return this.TypeHandle.GetHashCode() ^ this.KeyName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Identity);
        }

        public bool Equals(Identity oIdentity)
        {
            return oIdentity != null && this.TypeHandle.Equals(oIdentity.TypeHandle) && this.KeyName == oIdentity.KeyName;
        }

    }


}
