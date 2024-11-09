using CSharpLeetCode.Utils;
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
        //使用前缀和
        public static int SubarraySum(int[] nums, int k)
        {
            int count = 0;
            int sum = 0;
            //key：和 value：该和出现的次数
            //为什么不用hashSet，因为无法使用containsKey
            Dictionary<int, int> map = new Dictionary<int,int>();
            map.Add(0, 1); // 初始化前缀和为0的次数为1

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                Console.WriteLine($"当前i:{i}前缀和sum:{sum}");
                if (map.ContainsKey(sum - k))
                {
                    //不是加1，因为分为curSum - lastSum = k，lastSum出现了多次，说明存在正数，负数叠加可以出现多段满足的和为k的子串
                    count += map[sum - k];
                    Console.WriteLine($"存在前缀和，lastSum：{sum - k}，lastSum次数：{ map[sum - k]}");
                }

                //前缀和统计进入到字典中
                if (map.ContainsKey(sum))
                {
                    map[sum] += 1;
                }
                else
                {
                    map.Add(sum, 1);
                }

                PublicFunc.DebugObj(map);
            }

            return count;

        }

        public static void Test()
        {
            int[] nums = {3,4,7,2,-3,1,4,2};
            int k = 7;
            int result = SubarraySum(nums, k);
            Console.WriteLine("和为k的子数组数量: " + result); // 输出: 最短子数组长度为: 2
        }
    }
}
