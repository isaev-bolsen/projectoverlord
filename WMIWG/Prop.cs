﻿using System;
using System.CodeDom;
using System.Management;

namespace WMIWG
{
    internal class Prop
    {
        private static CodeFieldReferenceExpression instancePropertyReference = new CodeFieldReferenceExpression(null, WMIWrapperGenerator.instancePropertyName);

        private Type _type;
        private CimType _cimType;
        private string _name;

        private CodeTypeReference _typeReference;
        private CodeIndexerExpression _indexerExpression;

        public Prop(PropertyData prop)
        {
            _cimType = prop.Type;
            _type = CIMTypeToTy(_cimType);
            _name = prop.Name;

            _typeReference = new CodeTypeReference(_type);
            _indexerExpression = new CodeIndexerExpression(instancePropertyReference, new CodePrimitiveExpression(_name));
        }

        public CodeMemberProperty GetProperty()
        {
            CodeMemberProperty Property = new CodeMemberProperty()
            {
                Name = _name,
                Attributes = MemberAttributes.Public,
                Type = _typeReference
            };

            Property.GetStatements.Add(new CodeMethodReturnStatement(ToReturn()));
            Property.SetStatements.Add(new CodeAssignStatement(_indexerExpression, new CodeVariableReferenceExpression("value")));
            return Property;
        }

        private CodeExpression ToReturn()
        {
            if (CimType.DateTime == _cimType) return new CodeMethodInvokeExpression(null, "ParseDate", _indexerExpression);
            else return new CodeCastExpression(_typeReference, _indexerExpression);
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
