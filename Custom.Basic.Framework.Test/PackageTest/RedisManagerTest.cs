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
        [Fact]
        public void RedisTest()
        {
            RedisManager redis = new RedisManager();

            User user = new User() { UserId = 10000, UserName = "admin", Password = "123456" };

            string str = "Hello world";
            redis.StringSet("redis_string_test", str);

            string str2 = redis.StringGet("redis_string_test");
            Assert.Equal(str, str2);


        }


        [Fact(DisplayName = "字符串")]
        public void StringTest()
        {
            RedisManager redis = new RedisManager();
            string str = "Hello world";
            redis.StringSet("redis_string_test", str);

            string str2 = redis.StringGet("redis_string_test");
            Assert.Equal(str, str2);

        }


        [Fact]
        public void String2Test()
        {
            RedisManager redis = new RedisManager();
            User user = new User() { UserId = 10000, UserName = "admin", Password = "123456" };
            redis.StringSet("redis_string_model1", user, TimeSpan.FromSeconds(10));

        }


        [Fact(DisplayName = "实体")]
        public void ModelTest()
        {
            RedisManager redis = new RedisManager();
            User user = new User() { UserId = 10000, UserName = "admin", Password = "123456" };


            redis.StringSet("redis_model_test", user);

            User user2 = redis.StringGet<User>("redis_model_test");

            Assert.Equal(user.UserId, user2.UserId);
        }


        [Fact]
        public void ListTest()
        {
            RedisManager redis = new RedisManager();
            for (int i = 0; i < 10; i++)
            {
                redis.ListRightPush("list", i);
            }
            for (int i = 10; i < 20; i++)
            {
                redis.ListLeftPush("list", i);
            }
            var length = redis.ListLength("list");
            Assert.True(length == 20);

            var leftpop = redis.ListLeftPop<string>("list");
            var rightPop = redis.ListRightPop<string>("list");

            var list = redis.ListRange<int>("list");

        }


        [Fact]
        public void HashSetTest()
        {
            RedisManager redis = new RedisManager();

            redis.HashSet("user", "u1", "123");
            redis.HashSet("user", "u2", "1234");
            redis.HashSet("user", "u3", "1235");
            var news = redis.HashGet<string>("user", "u2");
        }


        [Fact]
        public void SubscribeTest()
        {
            RedisManager redis = new RedisManager();
            redis.Subscribe("Channel1");
            for (int i = 0; i < 10; i++)
            {
                redis.Publish("Channel1", "msg" + i);
                if (i == 2)
                {
                    redis.Unsubscribe("Channel1");
                }
            }
        }


        public class User
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }


    }
}
