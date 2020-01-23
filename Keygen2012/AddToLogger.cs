using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace Keygen2012
{
    class AddToLogger
    {

        // Fields
        internal delegate void Delegate156(string message, Enum312 type);
        private Delegate156 delegate156_0;

        // Methods
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void method_0(Delegate156 delegate156_1)
        {
            this.delegate156_0 = (Delegate156)Delegate.Combine(this.delegate156_0, delegate156_1);
        }

        public void method_1(string string_0)
        {
            this.method_2(string_0, Enum312.const_1);
        }

        public void method_2(string string_0, Enum312 enum312_0)
        {
            if (this.delegate156_0 != null)
            {
                this.delegate156_0(string_0, enum312_0);
            }
        }

        internal enum Enum312
        {
            const_0,
            const_1,
            const_2,
            const_3
        }

 

    }
}
