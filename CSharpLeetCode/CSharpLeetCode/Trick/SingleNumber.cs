using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Trick
{
    //只出现一次的数字
    public class SingleNumber
    {
        public static int DoSingleNumber(int[] nums)
        {
            int ret = 0;
            foreach (int e in nums) ret ^= e;
            return ret;
        }

        public static void Test()
        {
            int[] nums = new int[] { 1, 1, 2, 2, 3 };
            int ret = DoSingleNumber(nums);
            Console.WriteLine($"只出现1次数字:{ret}");
        }
    }
}
