using Custom.Basic.Framework.Helper;
using Custom.Basic.Framework.Test.ModelTest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Custom.Basic.Framework.Test.HelperTest
{
    /// <summary>
    /// XmlHelprtTest
    /// </summary>
    public class XmlHelprtTest
    {
        [Fact]
        public void ConvertObjectToXmlStringTest()
        {
            List<TestModel> result = new List<TestModel>();
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(5);
                result.Add(new TestModel());
            }
            string json = "[{\"TestId\":-63949053,\"TestName\":\"-63949053名称\"},{\"TestId\":-63888254,\"TestName\":\"-63888254名称\"},{\"TestId\":-63829643,\"TestName\":\"-63829643名称\"},{\"TestId\":-63778549,\"TestName\":\"-63778549名称\"},{\"TestId\":-63719683,\"TestName\":\"-63719683名称\"}]";
            string xmlContent = XmlHelper.ConvertObjectToXmlNodeString(result);

            Assert.True(xmlContent != null);
        }

        [Fact]
        public void ConvertObjectToXmlNodeStringTest()
        {
            List<TestModel> result = new List<TestModel>();
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(5);
                result.Add(new TestModel());
            }
            string xmlContent = XmlHelper.ConvertObjectToXmlNodeString(result);
            Assert.True(xmlContent != null);
        }

        [Fact]
        public void SerializeTest()
        {
            RootModel root = new RootModel()
            {
                Id = 1,
                Xmls = new List<XmlModel>
                {
                     new XmlModel{ Id=100, Data=new DataModel{ Id=1, Name="哪吒闹海"}},
                     new XmlModel{ Id=101, Data=new DataModel{ Id=2, Name="誓言"}}
                }
            };

            string xml = AppDomain.CurrentDomain.BaseDirectory + "\\123.xml";

            XmlHelper.Serialize<RootModel>(xml, root, Encoding.UTF8);
            Assert.True(File.Exists(xml));

        }


        [Fact]
        public void DeserializeTest()
        {
            string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
                                        <root id=""1"">
                                          <items>
                                            <id>100</id>
                                            <data id=""1"">
                                              <name>哪吒闹海</name>
                                            </data>
                                          </items>
                                          <items>
                                            <id>101</id>
                                            <data id=""2"">
                                              <name>誓言</name>
                                            </data>
                                          </items>
                                        </root>";
            RootModel result = XmlHelper.Deserialize<RootModel>(xml);
            Assert.NotNull(result);
            Assert.True(result.Id == 1);

        }

    }
}
