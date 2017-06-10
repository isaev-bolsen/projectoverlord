using System.CodeDom;
using System.Management;
using WMIWG.Props;

namespace WMIWG
{
    internal static class PropsFactory
    {
        public static CodeMemberProperty GetProperty(PropertyData prop)
        {
            return new Prop(prop).GetProperty();
        }
    }
}
