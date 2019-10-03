using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Compiler
{
    /// <summary>
    /// CompilerManager
    /// </summary>
    public abstract class CompilerManager
    {

        public class StringEqualityComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return string.Equals(x, y, StringComparison.InvariantCultureIgnoreCase);
            }

            public int GetHashCode(string obj)
            {
                if (obj == null)
                    return -1;
                return obj.GetHashCode();
            }
        }


        static List<string> _complierDlls;
        static CompilerManager()
        {
            _complierDlls = GetComplierDlls();
        }


        private static List<string> GetComplierDlls()
        {
            return new List<string>()
            {
                {"Microsoft.VisualBasic.dll" },
                { "mscorlib.dll" },
                { "System.dll" },
                { "System.Configuration.dll" },
                { "System.Configuration.Install.dll" },
                { "System.Data.dll" },
                { "System.Data.OracleClient.dll" },
                { "System.Data.SqlXml.dll" },
                { "System.Deployment.dll" },
                { "System.Design.dll" },
                { "System.DirectoryServices.dll" },
                { "System.DirectoryServices.Protocols.dll" },
                { "System.Drawing.dll" },
                { "System.Drawing.Design.dll" },
                { "System.EnterpriseServices.dll" },
                { "System.Management.dll" },
                { "System.Messaging.dll" },
                { "System.Runtime.Remoting.dll" },
                { "System.Runtime.Serialization.Formatters.Soap.dll" },
                { "System.ServiceProcess.dll" },
                { "System.Security.dll" },
                { "System.Transactions.dll" },
                { "System.Web.dll" },
                { "System.Web.Mobile.dll" },
                { "System.Web.RegularExpressions.dll" },
                { "System.Web.Services.dll" },
                { "System.Windows.Forms.dll" },
                { "System.Xml.dll" }
            };
        }

        /// <summary>
        ///  当前dll 集合
        /// </summary>
        public static List<string> ComplierCollection
        {
            get
            {
                return _complierDlls;
            }
        }

        /// <summary>
        ///  添加 Dll
        /// </summary>
        /// <param name="dllName"></param>
        public static void Add(string dllName)
        {
            if (string.IsNullOrEmpty(dllName))
                throw new ArgumentNullException("dllName is not null. ");

            if (!dllName.EndsWith(".dll")) dllName = dllName + ".dll";

            if (_complierDlls.Contains(dllName, new StringEqualityComparer()))
                return;

            _complierDlls.Add(dllName);
        }

        /// <summary>
        ///  添加 Dll 
        /// </summary>
        /// <param name="collections"></param>
        public static void AddRange(IEnumerable<string> collections)
        {
            if (collections != null && collections.Count() > 0)
            {
                foreach (var item in collections)
                {
                    Add(item);
                }
            }
        }


        /// <summary>
        ///  执行
        /// </summary>
        /// <param name="code">内容</param>
        /// <param name="mainFunction">主函数</param>
        public static object Excute(string code, string mainFunction)
        {
            CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider();
            CompilerParameters compilerParameters = new CompilerParameters();
            compilerParameters.GenerateExecutable = false;
            compilerParameters.GenerateInMemory = true;
            foreach (string item in ComplierCollection)
            {
                compilerParameters.ReferencedAssemblies.Add(item);
            }

            CompilerResults compilerResults = cSharpCodeProvider.CompileAssemblyFromSource(compilerParameters, code);
            if (compilerResults.Errors.HasErrors)
            {
                throw new Exception("编译错误：" + compilerResults.Errors[0].ErrorText);
            }
            string typeName = FindClassName(code, mainFunction).Trim();
            Assembly compiledAssembly = compilerResults.CompiledAssembly;
            object obj = compiledAssembly.CreateInstance(typeName);
            MethodInfo method = obj.GetType().GetMethod(mainFunction);
            object callback = method.Invoke(obj, null);
            return callback;
        }

        private static string FindClassName(string code, string entry)
        {
            Regex regex = new Regex("\\s" + entry + "\\s{0,}\\(");
            int index = regex.Match(code).Index;
            if (index <= 0)
            {
                throw new Exception("找不到指定的入口函数！");
            }
            string text = "";
            string text2 = "";
            regex = new Regex("namespace\\s{1,}\\w{1,}\\s");
            Regex regex2 = new Regex("\\s{1,}");
            MatchCollection matchCollection = regex.Matches(code);
            if (matchCollection.Count == 1)
            {
                text2 = matchCollection[0].Value;
                string[] array = regex2.Split(text2);
                text = array[1] + ".";
            }
            if (matchCollection.Count > 1)
            {
                throw new Exception("暂时不支持有多个命名空间！");
            }
            regex = new Regex("\\s{1,}class\\s{1,}\\w{1,}\\s{0,}[:\\{\\s]");
            regex2 = new Regex("\\s{1,}|[:\\{]");
            matchCollection = regex.Matches(code);
            if (matchCollection.Count == 0)
            {
                throw new Exception("必须有一个class！");
            }
            if (matchCollection.Count == 1)
            {
                text2 = matchCollection[0].Value;
                string[] array = regex2.Split(text2);
                return text + array[2];
            }
            for (int i = 0; i < matchCollection.Count; i++)
            {
                if (matchCollection[i].Index > index)
                {
                    text2 = matchCollection[i - 1].Value;
                    string[] array = regex2.Split(text2);
                    return text + array[2];
                }
                if (i == matchCollection.Count - 1)
                {
                    text2 = matchCollection[i].Value;
                    string[] array = regex2.Split(text2);
                    return text + array[2];
                }
            }
            return text;
        }



    }
}
