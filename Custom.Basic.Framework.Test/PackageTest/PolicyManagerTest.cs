using Custom.Basic.Framework.Package;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Custom.Basic.Framework.Test.PackageTest
{
    /// <summary>
    /// PolicyManagerTest
    /// </summary>
    public class PolicyManagerTest
    {
        [Fact]
        public void HandleResult()
        {
            int resultVal = PolicyManager.HandleResult<int>(5, () =>
            {
                int val = GetRondom();
                Debug.WriteLine("执行>>> " + val);

                return val;

            }, (val, count, ex) =>
            {
                // log
                Debug.WriteLine("重试...." + count);

            }, 3);

            Assert.Equal(resultVal, 5);

        }


        private int GetRondom()
        {
            int r = new Random().Next(0, 9);
            return r;
        }



    }
}
