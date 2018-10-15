using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Custom.Basic.Framework.Helper;

namespace Custom.Basic.Framework.Test.HelperTest
{
    /// <summary>
    /// DictionaryHelperTest
    /// </summary>
    public class DictionaryHelperTest
    {

        private Dictionary<int, string> _dictionarys = new Dictionary<int, string>()
        {
            { 1,"Hello world" },
            {2,"How are you"},
            {3,"And you"},
            {4,"Long time no see"},
            {5,"It's Ok"},
            {6,"Thank you"},
            {7,"You are welcome"},
            {8,"May I help you"},
            {9,"Nothing"}
        };

        [Theory]
        [InlineData(4)]
        public void GetTest(int key)
        {
            string value = _dictionarys.Get(key);
            Assert.Equal(value, "Long time no see");
        }



    }
}
