using System.CodeDom;
using System.Management;
using WMIWG.Props;

namespace WMIWG
{
    internal static class PropsFactory
    {
        public static CodeMemberProperty GetProperty(PropertyData prop)
        {
            if (prop.IsArray) return new ArrayProp(prop).GetProperty();
            else return new Prop(prop).GetProperty();
        }
    }
}
