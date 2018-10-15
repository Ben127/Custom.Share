using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace demo.Model
{
	/// <summary>
    ///   
    /// </summary>
	[Serializable]
	public class Test
	{
		/// <summary>
        /// 
        /// </summary>
		public int TestId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string TestName { get; set; }
		

		public Test AsTest()
		{
			return new Test
			{
				 TestId = this.TestId,
				 TestName = this.TestName,
			};
		}

	}
}

