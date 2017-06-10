using System;
using System.CodeDom;
using System.Management;

namespace WMIWG.Props
{
    internal class Prop : AbstrctProp
    {
        public Prop(PropertyData prop) : base(prop) { }

        protected override CodeTypeReference GetTypeReference(Type type)
        {
            return type.IsClass ? new CodeTypeReference(type) : new CodeTypeReference("System.Nullable", new CodeTypeReference(type));
        }
    }
}
