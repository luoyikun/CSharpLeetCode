using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Hash
{
    //最长序列
    public class LongestSequence
    {
        public static int DoLongestConsecutive(int[] nums)
        {
            //去重复
            HashSet<int> num_set = new HashSet<int>();
            for (int i = 0;i < nums.Length; i++)
            {
                num_set.Add(nums[i]);
            }

            int longestStreak = 0;
            //遍历hash
            foreach (var num in num_set)
            {

                if (!num_set.Contains(num - 1))
                {
                    //如果发现存在curValue-1，在hash存在，说明肯定有能构成从小到大的序列，能包含curValue，所以跳过
                    int currentNum = num;
                    int currentStreak = 1;
                    //如果不存在curValue - 1，说明curValue可能是子序列中第一个，初始化第一个值，长度为1
                    while (num_set.Contains(currentNum + 1))
                    {
                        //再while(存在curValue+1)，长度+1，下个值为curVlaue+1，每次while中进入长度最长的子串
                        currentNum += 1;
                        currentStreak += 1;
                    }
                    //记录当前最长
                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }

            return longestStreak;
        }

        public static void Test()
        {
            int[] nums = new int[] { 100, 4, 200, 1, 3, 2 };
            int ret = DoLongestConsecutive(nums);
            Console.WriteLine($"最长连续序列{ret}");
        }
    }
}
