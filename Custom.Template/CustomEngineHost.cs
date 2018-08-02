using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom.Template.Commom;
using Microsoft.VisualStudio.TextTemplating;

namespace Custom.Template
{
    /// <summary>
    ///  CustomTextTemplatingEngineHost
    /// </summary>
    [Serializable]
    public class CustomEngineHost : CustomEngineAbstract
    {

        public CustomEngineHost()
        {

        }

        public CustomEngineHost(string connectionName)
        {
            this.SetConnectionName(connectionName);
        }


        /// <summary>
        ///  执行模板
        /// </summary>
        public void Execute(string templatePath)
        {
            if (templatePath == null)
                throw new ArgumentException("模板未找到！");
            Execute(new string[] { templatePath });
        }

        public void Execute(string[] templates)
        {
            if (templates == null && templates.Count() == 0)
                throw new ArgumentException("模板未找到！");
            foreach (string template in templates)
            {
                this.TemplateFileName = template;
                this.SetSession<bool>("single", IsSingle);
                this.SetSession("filename", WithoutExtensionFileName);
                RunTamplate();
            }

            this.FinishIntialize();
        }


        private void RunTamplate()
        {
            Engine engine = new Engine();
            //Read the text template.  
            string input = File.ReadAllText(this.TemplateFile, Encoding.Default);

            //Transform the text template.  
            string output = engine.ProcessTemplate(input, this);

            string outputFileName = Path.GetFileNameWithoutExtension(this.TemplateFile);
            outputFileName = Path.Combine(Path.GetDirectoryName(this.TemplateFile), outputFileName);
            outputFileName = outputFileName + "1" + this.FileExtension;

            //错误写入文件
            if (this.Debugger)
            {
                output += WriteErrorLog();
            }

            File.WriteAllText(outputFileName, output, this.FileEncoding);
        }


        private string WriteErrorLog()
        {
            string output = string.Empty;
            if (this.ErrorList != null && this.ErrorList.Count > 0)
            {
                StringBuilder strBuild = new StringBuilder();

                int currentIndex = 1;
                List<CompilerError> errs = this.Errors.OfType<CompilerError>().Where(p => !p.IsWarning).ToList();
                foreach (CompilerError err in this.ErrorList)
                {
                    strBuild.AppendLine(string.Format("【" + currentIndex + "行 {2} 列 {3}】{4} \n文件：{0}\n错误：{1}", err.FileName, err.ErrorText, err.Line, err.Column, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                    currentIndex++;
                }
                output += "\n\n" + "=================错误信息[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]==========================";
                output += "\n\n" + strBuild.ToString();
            }
            return output;
        }


    }
}
