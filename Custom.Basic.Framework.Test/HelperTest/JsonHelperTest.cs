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
    /// JsonHelper
    /// </summary>
    public class JsonHelperTest
    {
        [Fact]
        public void SerializeObjectTest()
        {
            List<TestModel> result = new List<TestModel>();
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(5);
                result.Add(new TestModel());
            }

            string json = JsonHelper.SerializeObject(result);

            Assert.True(json != null);
        }


        [Fact]
        public void DeserializeObjectTest()
        {
            string json="[{\"TestId\":-63949053,\"TestName\":\"-63949053名称\"},{\"TestId\":-63888254,\"TestName\":\"-63888254名称\"},{\"TestId\":-63829643,\"TestName\":\"-63829643名称\"},{\"TestId\":-63778549,\"TestName\":\"-63778549名称\"},{\"TestId\":-63719683,\"TestName\":\"-63719683名称\"}]";
            List<TestModel> result = JsonHelper.DeserializeObject<List<TestModel>>(json);

            Assert.True(result.Count > 0);

        }

    }
}
