using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Custom.Basic.Framework.Helper
{
    /// <summary>
    /// XmlHelper
    /// </summary>
    public class XmlHelper
    {

        /// <summary>
        /// 转换对象为Xml字符串。
        /// </summary>
        /// <param name="obj">需要序列化的对象。</param>
        /// <returns>返回Xml字符串。</returns>
        public static string ConvertObjectToXmlString(object obj)
        {
            var xmlString = new StringBuilder();
            var serializer = new XmlSerializer(obj.GetType());
            using (TextWriter writer = new StringWriter(xmlString))
            {
                serializer.Serialize(writer, obj);
            }

            return xmlString.ToString();
        }

        /// <summary>
        /// 转换对象为Xml字符串。
        /// </summary>
        /// <param name="obj">需要序列化的对象。</param>
        /// <param name="type">对象类型。</param>
        /// <param name="nameSpace">命名空间。</param>
        /// <returns>返回Xml字符串。</returns>
        public static string ConvertObjectToXmlString(object obj, Type type = null, XmlSerializerNamespaces nameSpace = null)
        {
            var xmlString = new StringBuilder();
            var serializer = (type == null) ? new XmlSerializer(obj.GetType()) : new XmlSerializer(type);
            using (TextWriter writer = new StringWriter(xmlString))
            {
                if (nameSpace == null)
                {
                    serializer.Serialize(writer, obj);
                }
                else
                {
                    serializer.Serialize(writer, obj, nameSpace);
                }
            }

            return xmlString.ToString();
        }

        /// <summary>
        /// 转换对象为Xml纯节点字符串。
        /// </summary>
        /// <param name="obj">需要序列化的对象。</param>
        /// <returns>返回Xml字符串。</returns>
        public static string ConvertObjectToXmlNodeString(object obj)
        {
            var xmlString = new StringBuilder();
            var serializer = new XmlSerializer(obj.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            XmlSerializerNamespaces emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            using (var stream = new StringWriter(xmlString))
            {
                using (var writer = XmlWriter.Create(stream, settings))
                {
                    serializer.Serialize(writer, obj, emptyNamepsaces);
                }
            }

            return xmlString.ToString();
        }

        /// <summary>
        /// 转换Xml字符串为对象。
        /// </summary>
        /// <param name="xmlString">xml字符串。</param>
        /// <param name="type">对象类型。</param>
        /// <returns>返回对象实例。</returns>
        public static object ConvertXmlStringToObject(string xmlString, Type type)
        {
            using (var stringReader = new StringReader(xmlString))
            {
                var xmlSerializer = new XmlSerializer(type);
                return xmlSerializer.Deserialize(stringReader);
            }
        }
    }
}
