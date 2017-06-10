using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WMIWG.Props
{
    internal class ArrayProp : AbstrctProp
    {
        public ArrayProp(PropertyData prop) : base(prop)        {        }

        protected override CodeTypeReference GetTypeReference(Type type)
        {
            return new CodeTypeReference(new CodeTypeReference(type), 1);
        }
    }
}
