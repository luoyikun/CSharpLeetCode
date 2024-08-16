using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Array
{
    //最大子数组和
    //https://leetcode.cn/problems/maximum-subarray/description/?envType=study-plan-v2&envId=top-100-liked
    public static class MaxSubarray
    {
        public static int MaxSubArray(int[] nums)
        {
            int pre = 0, maxAns = nums[0]; // maxAns 用来记录全局最大子序和
            foreach (int x in nums)
            {
                Console.WriteLine($"pre:{pre}   x:{x}");
                pre = Math.Max(pre + x, x); // 更新以当前元素结尾的子序和
                maxAns = Math.Max(maxAns, pre); // 更新全局最大子序和
                Console.WriteLine($"maxAns:{maxAns}     pre:{pre}");
            }
            return maxAns; // 返回全局最大子序和
        }

        public static void Test()
        {
            int[] nums = { -2, -3, 4, -1, -2, 1, 5, -3 };
            Console.WriteLine(MaxSubArray(nums));
        }
    }
}
