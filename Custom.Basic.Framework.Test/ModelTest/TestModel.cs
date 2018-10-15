using Custom.Basic.Framework.Entity.PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Test.ModelTest
{
    /// <summary>
    /// Test
    /// </summary>
    [TableName("Test")]
    public class TestModel
    {

        public TestModel() { }

        public TestModel(string testName)
        {
            this.TestName = testName;
        }

        /// <summary>
        /// 
        /// </summary>
        public int TestId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TestName { get; set; }


        public TestModel AsTest()
        {
            return new TestModel
            {
                TestId = this.TestId,
                TestName = this.TestName,
            };
        }

    }
}
