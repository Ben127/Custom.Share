using Custom.Basic.Framework.Entity.PetaPoco;
using Custom.Basic.Framework.Test.ModelTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Custom.Basic.Framework.Test.EntityTest
{
    /// <summary>
    /// PetaPocoTest
    /// </summary>
    public class PetaPocoTest
    {
        private const string connection = "server=(local);database=demo;Integrated Security=True;";
        private const string providerName = "System.Data.SqlClient";

        [Theory(DisplayName = "删除测试")]
        [InlineData(41)]
        [InlineData(42)]
        [InlineData(43)]
        public void DeleteTest(int id)
        {
            bool deleted = false;
            using (Database db = new Database(connection, providerName))
            {
                deleted = db.Delete<TestModel>(" where TestId=@0", id) > 0;
            }
            Assert.True(deleted);
        }

        [Fact]
        public void InsertManyTest()
        {
            bool inserted = false;
            List<TestModel> source = new List<TestModel>()
            {
                new TestModel("测试1"),
                new TestModel("测试2"),
                new TestModel("测试3"),
                new TestModel("测试4"),
                new TestModel("测试5"),
                new TestModel("测试6"),
                new TestModel("测试7"),
                new TestModel("测试8")
            };
            using (Database db = new Database(connection, providerName))
            {
                inserted = db.BulkInsert("Test", source);
            }
            Assert.True(inserted);
        }

        [Fact]
        public void QueryTest()
        {
            using (Database db = new Database(connection, providerName))
            {
                var list = db.Query<TestModel>("").ToList();
                Assert.True(list.Count > 0);
            }
        }

        [Fact]
        public void UpdateTest()
        {
            bool updated = false;
            using (Database db = new Database(connection, providerName))
            {
                updated = db.Update<TestModel>(" set TestName=REPLACE(TestName,'测试','名称')") > 0;
            }
            Assert.True(updated);
        }




    }
}
