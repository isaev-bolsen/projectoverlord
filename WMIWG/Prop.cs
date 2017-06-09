using System;
using System.CodeDom;
using System.Management;

namespace WMIWG
{
    internal class Prop
    {
        private static CodeFieldReferenceExpression instanceFieldReference = new CodeFieldReferenceExpression(null, WMIWrapperGenerator.instancePropertyName);

        private Type _type;
        private string _name;

        public Prop(PropertyData prop)
        {
            _type = CIMTypeToTy(prop.Type);
            _name = prop.Name;
        }

        public CodeMemberProperty GetProperty()
        {
            CodeMemberProperty Property = new CodeMemberProperty()
            {
                Name = _name,
                Attributes = MemberAttributes.Public,
                Type = new CodeTypeReference(_type)
            };

            CodeIndexerExpression CodeIndexerExpression = new CodeIndexerExpression(instanceFieldReference, new CodePrimitiveExpression(_name));

            Property.GetStatements.Add(new CodeMethodReturnStatement(ToReturn(Property, CodeIndexerExpression)));
            Property.SetStatements.Add(new CodeAssignStatement(CodeIndexerExpression, new CodeVariableReferenceExpression("value")));
            return Property;
        }

        private CodeExpression ToReturn(CodeMemberProperty Property, CodeIndexerExpression CodeIndexerExpression)
        {
            if (typeof(DateTime?) == _type) return new CodeMethodInvokeExpression(null, "ParseDate", CodeIndexerExpression);
            else return new CodeCastExpression(Property.Type, CodeIndexerExpression);
        }

        private static Type CIMTypeToTy(CimType cim)
        {
            switch (cim)
            {
                case CimType.SInt8: return typeof(byte?);
                case CimType.UInt8: return typeof(sbyte?);
                case CimType.SInt16: return typeof(short?);
                case CimType.UInt16: return typeof(ushort?);
                case CimType.SInt32: return typeof(int?);
                case CimType.UInt32: return typeof(uint?);
                case CimType.SInt64: return typeof(long?);
                case CimType.UInt64: return typeof(ulong?);
                case CimType.Real32: return typeof(decimal?);
                case CimType.Real64: return typeof(decimal?);
                case CimType.Boolean: return typeof(bool?);
                case CimType.String: return typeof(string);
                case CimType.DateTime: return typeof(DateTime?);
                case CimType.Reference: return typeof(object);
                case CimType.Char16: return typeof(string);
                case CimType.Object: return typeof(object);
                default: throw new ArgumentException("Unknown CIM Type: " + cim);
            }
        }
    }

}
