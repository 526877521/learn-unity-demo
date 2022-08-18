

using System.Reflection;
using UnityEngine;

namespace Data.EditorTool
{
    public class CreateClass
    {
        public static void BuildBaseClass(string className,object[] fields,object[] types)
        {
           
            Debug.Log(className);
            //准备编译单元
            CodeCompileUnit unit = new CodeCompileUnit();
            
            //设置命名空间（这个是指要生成的类的空间）
            CodeNamespace myNamespace = new CodeNamespace("Data");
            
            //导入必要的命名空间引用
            myNamespace.Imports.Add(new CodeNamespaceImport("System"));
            
            myNamespace.Imports.Add(new CodeNamespaceImport("UnityEngine"));
            // myNamespace
            
            //Code:代码体
            CodeTypeDeclaration myClass = new CodeTypeDeclaration(className);
            //继承
            // myClass.BaseTypes.Add( "ScriptableObject" );
            
            //添加注解
            myClass.CustomAttributes.Add(new CodeAttributeDeclaration("System.Serializable"));                         
            myClass.IsClass = true;
            
            //设置类的访问类型
            myClass.TypeAttributes = TypeAttributes.Public;// | TypeAttributes.Sealed;
            
            //把这个类放在这个命名空间下
            myNamespace.Types.Add(myClass);
            
            //把该命名空间加入到编译器单元的命名空间集合中
            unit.Namespaces.Add(myNamespace);
            Debug.Log(fields.Length+"--->"+types.Length);
            for (int i = 0; i < fields.Length; i++)
            {
                //这里暂时只支持string类型，之后会修改，比如通过编辑器修改，或者在CSV中添加类型行
                Debug.Log("====>"+types[i].ToString());
            
                var fileType = (types[i].ToString() == "uint") ? typeof(uint) : typeof(string);
                Debug.Log(fileType);
                // CodeMemberField field = new CodeMemberField(fileType, fields[i].ToString());
                // field.Attributes = MemberAttributes.Public;
                //这里目前也只能添加固定一种特性之后也可以自定义
                // field.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference("CSVSerialize")));
                myClass.Members.Add(field);
            }
            //生成C#脚本("VisualBasic"：VB脚本)
            // CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            // CodeGeneratorOptions options = new CodeGeneratorOptions();
            // //代码风格:大括号的样式{}
            // options.BracingStyle = "C";
            //     // /是否在字段、属性、方法之间添加空白行
            // options.BlankLinesBetweenMembers = true;
            // //输出文件路径
            // string outputFile = Application.dataPath + "/Data/Entity/" + className + ".cs";
            //
            // //保存
            // using (System.IO.StreamWriter sw = new System.IO.StreamWriter(outputFile))
            //
            // {
            //     //为指定的代码文档对象模型(CodeDOM) 编译单元生成代码并将其发送到指定的文本编写器，使用指定的选项。(官方解释)
            //     //将自定义代码编译器(代码内容)、和代码格式写入到sw中
            //     provider.GenerateCodeFromCompileUnit(unit, sw, options);
            //
            // }
        
            
        }
         public static void BuildManagerClass(string className,object[] fields,object[] types)
        {
           
            Debug.Log(className);
            //准备编译单元
            CodeCompileUnit unit = new CodeCompileUnit();
            
            //设置命名空间（这个是指要生成的类的空间）
            CodeNamespace myNamespace = new CodeNamespace("Data");
            
            //导入必要的命名空间引用
            myNamespace.Imports.Add(new CodeNamespaceImport("System"));
            
            myNamespace.Imports.Add(new CodeNamespaceImport("UnityEngine"));
            // myNamespace
            
            //Code:代码体
            CodeTypeDeclaration myClass = new CodeTypeDeclaration(className);
            //继承
            myClass.BaseTypes.Add( "ScriptableObject" );
            
            //添加注解
            // myClass.CustomAttributes.Add(new CodeAttributeDeclaration("System.Serializable"));                         
            myClass.IsClass = true;
            
            //设置类的访问类型
            myClass.TypeAttributes = TypeAttributes.Public;// | TypeAttributes.Sealed;
            
            //把这个类放在这个命名空间下
            myNamespace.Types.Add(myClass);
            
            //把该命名空间加入到编译器单元的命名空间集合中
            unit.Namespaces.Add(myNamespace);
            
            
            //添加字段
            CodeMemberField field = new CodeMemberField(typeof(System.String []), "dataArray");
            
            //设置访问类型
            field.Attributes = MemberAttributes.Public;
            
            ///添加到myClass类中
            myClass.Members.Add(field);
            
            
            //生成C#脚本("VisualBasic"：VB脚本)
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            //代码风格:大括号的样式{}
            options.BracingStyle = "C";
                // /是否在字段、属性、方法之间添加空白行
            options.BlankLinesBetweenMembers = true;
            //输出文件路径
            string outputFile = Application.dataPath + "/Data/Manager" + className + ".cs";
            
            //保存
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(outputFile))
            
            {
                //为指定的代码文档对象模型(CodeDOM) 编译单元生成代码并将其发送到指定的文本编写器，使用指定的选项。(官方解释)
                //将自定义代码编译器(代码内容)、和代码格式写入到sw中
                provider.GenerateCodeFromCompileUnit(unit, sw, options);
            
            }

        }
         
    }
}