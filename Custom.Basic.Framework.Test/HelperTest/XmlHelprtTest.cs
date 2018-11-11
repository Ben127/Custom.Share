using Custom.Basic.Framework.Helper;
using Custom.Basic.Framework.Test.ModelTest;
using System;
using System.Collections.Generic;
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


    }
}
