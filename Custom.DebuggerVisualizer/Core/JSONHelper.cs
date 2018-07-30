using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.DebuggerVisualizer.Core
{
    public class JSONHelper
    {
        private int TABLength = 0;

        private char Break_left = '[';
        private char Break_right = ']';

        private char Bpace_left = '{';
        private char Bpace_right = '}';

        private char Comma = ',';
        private char Line_break = '\n';

        private char Tab = '\t';

        /// <summary>
        /// 字符串 JSON格式化
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public String Format(string str)
        {
            StringBuilder result = new StringBuilder();
            char[] srcArray = str.ToArray();

            foreach (var item in srcArray)
            {
                result.Append(item);

                if (Bpace_left.Equals(item))  //{
                    result.Append(AppendLINE_BREAKAndTAB(++TABLength));

                if (Bpace_right.Equals(item)) //}
                    result.Insert(result.Length - 1, AppendLINE_BREAKAndTAB(--TABLength));

                if (Break_left.Equals(item))    //[
                    result.Append(AppendLINE_BREAKAndTAB(++TABLength));

                if (Break_right.Equals(item))   //]
                    result.Insert(result.Length - 1, AppendLINE_BREAKAndTAB(--TABLength));

                if (Comma.Equals(item))   //,
                    result.Append(AppendLINE_BREAKAndTAB(TABLength));
            }

            return result.ToString();
        }

        //追加换行符和   确定长度的制表符
        private String AppendLINE_BREAKAndTAB(int TABTimes)
        {
            StringBuilder temp = new StringBuilder();
            temp.Append(AppendLINE_BREAK());
            temp.Append(AppendTAB(TABTimes));
            return temp.ToString();
        }

        private char AppendLINE_BREAK()
        {
            return Line_break;
        }

        private String AppendTAB(int TABTimes)
        {
            StringBuilder temp = new StringBuilder();
            for (int i = 0; i < TABTimes; i++)
            {
                temp.Append(Tab);
            }
            return temp.ToString();
        }


    }
}
