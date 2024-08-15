using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.SubSequence
{
    //合为k的子序列
    //https://leetcode.cn/problems/subarray-sum-equals-k/description/?envType=study-plan-v2&envId=top-100-liked
    public static class SubarraySumEqualsK
    {
        // 计算和为K的最短子数组的长度
        public static int SubarraySum(int[] nums, int k)
        {
            int count = 0;
            int sum = 0;
            Dictionary<int, int> map = new Dictionary<int,int>();
            map.Add(0, 1); // 初始化前缀和为0的次数为1

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (map.ContainsKey(sum - k))
                {
                    count += map[sum - k];
                }
                if (map.ContainsKey(sum))
                {
                    map[sum] += 1;
                }
                else
                {
                    map.Add(sum, 1);
                }

            }

            return count;

        }

        public static void Test()
        {
            int[] nums = { 1, 1, 1 };
            int k = 2;
            int result = SubarraySum(nums, k);
            Console.WriteLine("最短子数组长度为: " + result); // 输出: 最短子数组长度为: 2
        }
    }
}
