using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Custom.Basic.Framework.Test.ModelTest
{
    [XmlRoot("root")]
    public class RootModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("items")]
        public List<XmlModel> Xmls { get; set; }
    }


    /// <summary>
    /// XmlModel
    /// </summary>
    public class XmlModel
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("data")]
        public DataModel Data { get; set; }
    }

    public class DataModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }
    }


}
