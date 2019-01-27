using Custom.Basic.Framework.Package.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Custom.Basic.Framework.Test.PackageTest
{
    /// <summary>
    /// RedisManagerTest
    /// </summary>
    public class RedisManagerTest
    {

        [Fact(DisplayName = "字符串")]
        public void StringTest()
        {
            RedisManager redis = new RedisManager();
            List<Bus> listData = new List<Bus>()
            {
                new Bus(){ BusId=1, BusName="汽车1", Score=89},
                new Bus(){ BusId=2, BusName="汽车2", Score=43},
                new Bus(){ BusId=3, BusName="汽车3", Score=54},
                new Bus(){ BusId=4, BusName="汽车4", Score=32}
            };

            var result = redis.StringGetCollection<Bus>(new List<string> { "test:string:bus" });
            Assert.True(result.Count > 0);

        }


        [Fact(DisplayName = "HashTest")]
        public void HashTest()
        {
            RedisManager redis = new RedisManager();
            List<Bus> listData = new List<Bus>()
            {
                new Bus(){ BusId=1, BusName="汽车1", Score=89},
                new Bus(){ BusId=2, BusName="汽车2", Score=43},
                new Bus(){ BusId=3, BusName="汽车3", Score=54},
                new Bus(){ BusId=4, BusName="汽车4", Score=32}
            };

            var result = redis.HashKeys<Bus>("test:hash:bus");
            Assert.True(result.Count > 0);
        }


        [Fact]
        public void SortSetTest()
        {
            RedisManager redis = new RedisManager();

            List<Bus> listData = new List<Bus>()
            {
                new Bus(){ BusId=1, BusName="汽车1", Score=89},
                new Bus(){ BusId=2, BusName="汽车2", Score=43},
                new Bus(){ BusId=3, BusName="汽车3", Score=54},
                new Bus(){ BusId=4, BusName="汽车4", Score=32}
            };

            var result = redis.SortSetGet<Bus>("test:sortset:bus");
            Assert.True(result.Count > 0);
        }



        public class User
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public class Bus
        {
            public int BusId { get; set; }
            public string BusName { get; set; }
            public decimal Score { get; set; }

        }


    }
}
