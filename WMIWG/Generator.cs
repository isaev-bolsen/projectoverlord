using System;
using System.CodeDom;
using System.IO;
using System.Management;

namespace WMIWG
{
    public class Generator
    {
        private const string instanceFieldName = "_instance";
        private const string instanceParameterName = "instance";

        private void Generate(ManagementBaseObject WMIObject, string nameSpace)
        {
            CodeCompileUnit CodeCompileUnit = new CodeCompileUnit();
            CodeNamespace CodeNamespace = new CodeNamespace(nameSpace);
            CodeNamespace.Imports.Add(new CodeNamespaceImport("System.Management"));
            CodeNamespace.Types.Add(GetGenerateClass(WMIObject));
            CodeCompileUnit.Namespaces.Add(CodeNamespace);
            File.WriteAllText(WMIObject.ClassPath.ClassName + ".cs", CodeCompileUnit.ToString());
        }

        private CodeTypeDeclaration GetGenerateClass(ManagementBaseObject WMIObject)
        {
            string name = WMIObject.ClassPath.ClassName;
            Type ObjectType = WMIObject.GetType();

            CodeFieldReferenceExpression instanceFieldReference = new CodeFieldReferenceExpression(null, instanceFieldName);

            CodeTypeDeclaration CodeTypeDeclaration = new CodeTypeDeclaration(name);
            CodeTypeDeclaration.Members.Add(new CodeMemberField(ObjectType, instanceFieldName)
            {
                Attributes = MemberAttributes.Private
            });//private readonly ManagementObject _instance;

            CodeConstructor CodeConstructor = new CodeConstructor();
            CodeConstructor.Parameters.Add(new CodeParameterDeclarationExpression(ObjectType, instanceParameterName));
            CodeConstructor.Statements.Add(new CodeAssignStatement(instanceFieldReference, new CodeVariableReferenceExpression(instanceParameterName)));

            CodeTypeDeclaration.Members.Add(CodeConstructor);

            foreach (var prop in WMIObject.Properties)
            {
                CodeMemberProperty Property = new CodeMemberProperty()
                {
                    Name = prop.Name,
                    Type = new CodeTypeReference(CIMTypeToTy(prop.Type)),
                };
                Property.GetStatements.Add(new CodeCastExpression(Property.Type, new CodeIndexerExpression(instanceFieldReference, new CodePrimitiveExpression(prop.Name))));
                CodeTypeDeclaration.Members.Add(Property);
            }
            return CodeTypeDeclaration;
        }

        private Type CIMTypeToTy(CimType cim)
        {
            switch (cim)
            {
                case CimType.SInt8: return typeof(byte);
                case CimType.UInt8: return typeof(sbyte);
                case CimType.SInt16: return typeof(short);
                case CimType.UInt16: return typeof(ushort);
                case CimType.SInt32: return typeof(int);
                case CimType.UInt32: return typeof(uint);
                case CimType.SInt64: return typeof(long);
                case CimType.UInt64: return typeof(ulong);
                case CimType.Real32: return typeof(decimal);
                case CimType.Real64: return typeof(decimal);
                case CimType.Boolean: return typeof(bool);
                case CimType.String: return typeof(string);
                case CimType.DateTime: return typeof(DateTime);
                case CimType.Reference: return typeof(object);
                case CimType.Char16: return typeof(string);
                case CimType.Object: return typeof(object);
                default: throw new ArgumentException("Unknown CIM Type: " + cim);
            }
        }
    }
}