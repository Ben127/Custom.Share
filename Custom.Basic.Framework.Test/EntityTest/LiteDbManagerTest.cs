using Custom.Basic.Framework.Entity.LiteDb;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Custom.Basic.Framework.Test.EntityTest
{
    /// <summary>
    /// LiteDbManagerTest
    /// </summary>
    public class LiteDbManagerTest
    {

        public class Demo
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        [Fact]
        public void FindAllTest()
        {
            string connectionString = "demo.txt";
            LiteDbManager target = new LiteDbManager(connectionString, "demo");
            var result = target.FindAll<Demo>();

            Assert.True(result.Count > 0);
        }

        [Fact]
        public void InsertTest()
        {
            var demo = new Demo { Id = Guid.NewGuid().ToString("n"), Name = "测试" };
            string connectionString = "demo.txt";
            LiteDbManager target = new LiteDbManager(connectionString, "demo");
            BsonValue inserted = target.Insert<Demo>(demo);
            Assert.NotNull(inserted);

            var result = target.FindAll<Demo>();
            Assert.True(result.Count > 0);


        }

    }
}
