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
        internal const string instancePropertyName = "Instance";
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

            CodeTypeDeclaration CodeTypeDeclaration = new CodeTypeDeclaration(name);
            CodeTypeDeclaration.BaseTypes.Add(new CodeTypeReference("WMIWrapper"));

            CodeConstructor CodeConstructor = new CodeConstructor() { Attributes = MemberAttributes.Public };
            CodeConstructor.Parameters.Add(new CodeParameterDeclarationExpression(ObjectType, instanceParameterName));
            CodeConstructor.BaseConstructorArgs.Add(new CodeVariableReferenceExpression(instanceParameterName));

            CodeTypeDeclaration.Members.Add(CodeConstructor);

            foreach (var prop in WMIObject.Properties) CodeTypeDeclaration.Members.Add(new Prop(prop).GetProperty());
            return CodeTypeDeclaration;
        }
    }
}