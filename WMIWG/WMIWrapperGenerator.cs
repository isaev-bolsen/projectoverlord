using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Management;
using Microsoft.CSharp;

namespace WMIWG
{
    /// <summary>
    /// Utility class. Allows to generate class to wrap WMI objects
    /// </summary>
    public class WMIWrapperGenerator
    {
        private const string instanceFieldName = "Instance";
        private const string instanceParameterName = "instance";
        
        /// <summary>
        /// Generates wrapper class for object
        /// </summary>
        /// <param name="WMIObject"></param>
        public void Generate(ManagementBaseObject WMIObject)
        {
            CodeNamespace CodeNamespace = new CodeNamespace("WMIWrappers.Raw");
            CodeNamespace.Types.Add(GetClass(WMIObject));

            CodeCompileUnit CodeCompileUnit = new CodeCompileUnit();
            CodeCompileUnit.Namespaces.Add(CodeNamespace);
            CSharpCodeProvider provider = new CSharpCodeProvider();

            using (StreamWriter sw = new StreamWriter(string.Join(".", WMIObject.ClassPath.ClassName, provider.FileExtension), false))
            {
                provider.GenerateCodeFromCompileUnit(CodeCompileUnit, sw, new CodeGeneratorOptions());
                sw.Close();
            }
        }

        private CodeTypeDeclaration GetClass(ManagementBaseObject WMIObject)
        {
            string name = WMIObject.ClassPath.ClassName;
            Type ObjectType = WMIObject.GetType();

            CodeFieldReferenceExpression instanceFieldReference = new CodeFieldReferenceExpression(null, instanceFieldName);

            CodeTypeDeclaration CodeTypeDeclaration = new CodeTypeDeclaration(name);
            CodeTypeDeclaration.BaseTypes.Add(new CodeTypeReference("WMIWrapper"));

            CodeConstructor CodeConstructor = new CodeConstructor() { Attributes = MemberAttributes.Public };
            CodeConstructor.Parameters.Add(new CodeParameterDeclarationExpression(ObjectType, instanceParameterName));
            CodeConstructor.BaseConstructorArgs.Add(new CodeVariableReferenceExpression(instanceParameterName));

            CodeTypeDeclaration.Members.Add(CodeConstructor);

            foreach (var prop in WMIObject.Properties) CodeTypeDeclaration.Members.Add(GetProperty(instanceFieldReference, prop));
            return CodeTypeDeclaration;
        }

        private CodeMemberProperty GetProperty(CodeFieldReferenceExpression instanceFieldReference, PropertyData prop)
        {
            CodeMemberProperty Property = new CodeMemberProperty()
            {
                Name = prop.Name,
                Attributes = MemberAttributes.Public,
                Type = new CodeTypeReference(CIMTypeToTy(prop.Type))
            };

            CodeIndexerExpression CodeIndexerExpression = new CodeIndexerExpression(instanceFieldReference, new CodePrimitiveExpression(prop.Name));
            Property.GetStatements.Add(new CodeMethodReturnStatement(new CodeCastExpression(Property.Type, CodeIndexerExpression)));
            Property.SetStatements.Add(new CodeAssignStatement(CodeIndexerExpression, new CodeVariableReferenceExpression("value")));
            return Property;
        }

        private Type CIMTypeToTy(CimType cim)
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