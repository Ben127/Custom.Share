using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom.Template.Properties;
using Microsoft.VisualStudio.TextTemplating;

namespace Custom.Template.Commom
{
    /// <summary>
    ///  CustomTextTemplatingEngineAbstract
    /// </summary>
    public abstract class CustomEngineAbstract : ITextTemplatingEngineHost, ITextTemplatingSessionHost
    {

        #region ITextTemplatingEngineHost 成员

        public object GetHostOption(string optionName)
        {
            object returnObject;
            switch (optionName)
            {
                case "CacheAssemblies":
                    returnObject = true;
                    break;
                default:
                    returnObject = null;
                    break;
            }
            return returnObject;
        }

        //  获取文本，它对应于包含部分文本模板文件的请求。
        public bool LoadIncludeText(string requestFileName, out string content, out string location)
        {
            content = System.String.Empty;
            location = System.String.Empty;

            if (File.Exists(requestFileName))
            {
                content = File.ReadAllText(requestFileName);
                return true;
            }
            else
            {
                return false;
            }
        }

        //  接收来自转换引擎的错误和警告集合。
        public void LogErrors(CompilerErrorCollection errors)
        {
            errorsValue = errors;
        }

        //  提供运行所生成转换类的应用程序域。
        public AppDomain ProvideTemplatingAppDomain(string content)
        {
            return AppDomain.CreateDomain("Generation App Domain");
        }

        //  允许主机提供有关程序集位置的附加信息。
        public string ResolveAssemblyReference(string assemblyReference)
        {
            if (File.Exists(assemblyReference))
            {
                return assemblyReference;
            }

            string candidate = Path.Combine(Path.GetDirectoryName(this.TemplateFile), assemblyReference);
            if (File.Exists(candidate))
            {
                return candidate;
            }

            return "";
        }

        //  在已知指令处理器的友好名称时，返回其类型。
        public Type ResolveDirectiveProcessor(string processorName)
        {
            if (string.Compare(processorName, "XYZ", StringComparison.OrdinalIgnoreCase) == 0)
            {
                //return typeof();
            }

            throw new Exception("Directive Processor not found");
        }


        //  如果在模板文本中未指定某个参数，则为指令处理器解析该参数的值。
        public string ResolveParameterValue(string directiveId, string processorName, string parameterName)
        {
            if (directiveId == null)
            {
                throw new ArgumentNullException("the directiveId cannot be null");
            }
            if (processorName == null)
            {
                throw new ArgumentNullException("the processorName cannot be null");
            }
            if (parameterName == null)
            {
                throw new ArgumentNullException("the parameterName cannot be null");
            }
            return String.Empty;
        }

        //  允许主机提供完整路径以及给定文件名或相对路径。
        public string ResolvePath(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("the file name cannot be null");
            }
            if (File.Exists(fileName))
            {
                return fileName;
            }
            string candidate = Path.Combine(Path.GetDirectoryName(this.TemplateFile), fileName);
            if (File.Exists(candidate))
            {
                return candidate;
            }
            return fileName;
        }

        private string fileExtensionValue = ".txt";
        public string FileExtension
        {
            get { return fileExtensionValue; }
        }

        //  通知主机所生成文本输出需要的文件扩展名。
        public void SetFileExtension(string extension)
        {
            //the parameter extension has a '.' in front of it already
            //--------------------------------------------------------
            fileExtensionValue = extension;
        }

        private CompilerErrorCollection errorsValue;
        public CompilerErrorCollection Errors
        {
            get { return errorsValue; }
        }

        private Encoding fileEncodingValue = Encoding.UTF8;
        public Encoding FileEncoding
        {
            get { return fileEncodingValue; }
        }

        //  通知主机所生成文本输出需要的编码。
        public void SetOutputEncoding(System.Text.Encoding encoding, bool fromOutputDirective)
        {
            fileEncodingValue = encoding;
        }

        public IList<string> StandardAssemblyReferences
        {
            get
            {
                /*
                 *     EnvDTE.dll 
                 *     System.configuration.dll
                 *     System.Core.dll
                 *     System.Data.dll
                 *     System.dll
                 *     System.Windows.Forms.dll 
                 *     System.XML.dll
                 */

                string[] assemblys = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\" + Resources.Temp
                                                , Resources.TargetExt);
                return assemblys;


            }
        }

        public IList<string> StandardImports
        {
            get
            {
                return new string[] { };
            }
        }

        public string TemplateFileName;
        public string TemplateFile
        {
            get
            {
                return TemplateFileName;
            }
        }

        #endregion


        #region ITextTemplatingSessionHost 成员

        public ITextTemplatingSession CreateSession()
        {
            _session = new TextTemplatingSession();
            return _session;
        }

        private ITextTemplatingSession _session = null;
        public ITextTemplatingSession Session
        {
            get
            {
                if (_session == null)
                {
                    _session = new TextTemplatingSession();
                }
                if (this.ouputPath != null)
                {
                    if (!_session.ContainsKey("path"))
                    {
                        _session.Add("path", this.ouputPath);
                    }
                }
                return _session;
            }
            set
            {
                _session = value;
            }
        }

        #endregion


        #region 属性、字段


        private string ouputPath = string.Empty;
        private bool isSingle = true;
        /// <summary>
        /// 是否生成文件在同一个文件夹
        ///     默认，按照模板引擎位置
        /// </summary>
        public bool IsSingle
        {
            get
            {
                return isSingle;
            }
            set
            {
                isSingle = value;
            }
        }


        private string withoutExtensionFileName = string.Empty;

        /// <summary>
        /// 无扩展名的文件名称
        /// </summary>
        public string WithoutExtensionFileName
        {
            get
            {
                if (this.TemplateFileName == null)
                    throw new ArgumentException("TemplateFileName can not null.");

                withoutExtensionFileName = Path.GetFileNameWithoutExtension(this.TemplateFile);
                return withoutExtensionFileName;
            }
        }


        public void SetSession(string key, string value)
        {
            SetSession<string>(key, value);
        }

        public void SetSession<T>(string key, T value)
        {
            if (this.Session != null)
            {
                if (!this.Session.ContainsKey(key))
                {
                    this.Session.Add(key, value);
                }
                else
                {
                    this.Session[key] = value;
                }
            }

        }

        /// <summary>
        /// 模板错误信息
        /// </summary>
        public List<CompilerError> ErrorList
        {
            get { return errorsValue.OfType<CompilerError>().Where(p => !p.IsWarning).ToList(); }
        }


        /// <summary>
        ///  模板警告信息
        /// </summary>
        public List<CompilerError> WarningList
        {
            get { return errorsValue.OfType<CompilerError>().Where(p => p.IsWarning).ToList(); }
        }


        private string connectionName = string.Empty;
        /// <summary>
        /// 数据库连接
        /// </summary>
        public string ConnectionName
        {
            get
            {
                return connectionName;
            }
            set
            {
                connectionName = value;
            }
        }


        private bool debuger = false;

        /// <summary>
        /// 是否debugger 模式
        /// </summary>
        public bool Debugger
        {
            get
            {
                return debuger;
            }
            set
            {
                debuger = value;
            }
        }


        #endregion


        /// <summary>
        /// 设置输出文件夹路径
        /// </summary>
        /// <param name="path"></param>
        public void SetOutputPath(string path)
        {
            if (path == null)
                throw new ArgumentException("path is not null.");
            this.ouputPath = path;
        }

        /// <summary>
        /// 设置数据库连接名称
        /// </summary>
        /// <param name="connectionName"></param>
        public void SetConnectionName(string connectionName)
        {
            if (connectionName == null)
                throw new ArgumentException("connectionName is not null.");
            this.connectionName = connectionName;
        }


        /// <summary>
        /// 模板执行完毕
        ///     移除相关模板引擎引用文件
        /// </summary>
        public virtual void FinishIntialize()
        {
            try
            {
                string temp = Resources.Temp;
                string root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, temp);
                Microsoft.VisualBasic.Devices.Computer computer = new Microsoft.VisualBasic.Devices.Computer();
                if (computer.FileSystem.DirectoryExists(root))
                {
                    computer.FileSystem.DeleteDirectory(root, Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.DeleteAllContents);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("模板引擎移除失败！错误信息：" + ex.Message);
            }

        }


        #region   初始化

        public CustomEngineAbstract()
        {
            Initialize();
        }

        /// <summary>
        ///  初始化引擎dll 环境
        ///             默认当前运行自动生成一个 temp 文件夹，并读取生成相关模板 dll
        /// </summary>
        public virtual void Initialize()
        {
            try
            {
                List<string> names = Resources.CustomAssembly.Split(',').ToList();
                List<string> dllNames = names.Where(p => !p.StartsWith("PetaPoco", StringComparison.CurrentCultureIgnoreCase)).ToList();
                List<string> ttincludes = names.Where(p => !dllNames.Contains(p)).ToList();

                string temp = Resources.Temp;
                string root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, temp);
                Microsoft.VisualBasic.Devices.Computer computer = new Microsoft.VisualBasic.Devices.Computer();
                if (computer.FileSystem.DirectoryExists(root))
                {
                    computer.FileSystem.DeleteDirectory(root, Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.DeleteAllContents);
                }
                computer.FileSystem.CreateDirectory(root);

                // dll
                foreach (var v in dllNames)
                {
                    byte[] bytes = (byte[])Resources.ResourceManager.GetObject(v);
                    File.WriteAllBytes(root + "/" + v.Replace("_", ".") + ".dll", bytes);
                }

                // include
                foreach (var v in ttincludes)
                {
                    byte[] bytes = (byte[])Resources.ResourceManager.GetObject(v);
                    File.WriteAllBytes(root + "/" + v.Replace("_", ".") + ".ttinclude", bytes);
                }

            }
            catch (Exception ex)
            {
                throw new ArgumentException("模板文件初始化失败！错误信息：" + ex.Message);
            }
        }

        #endregion

    }
}
