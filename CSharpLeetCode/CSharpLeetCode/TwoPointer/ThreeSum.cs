using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.TwoPointer
{
    //三数之和
    public class ThreeSum
    {
        public static List<List<int>> threeSum(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);
            PublicFunc.DebugObj(nums, "排序后");
            List<List<int>> ans = new List<List<int>>();
            // 枚举 a
            for (int first = 0; first < n; ++first)
            {
                Console.WriteLine($"first:{first}");
                // 需要和上一次枚举的数不相同
                if (first > 0 && nums[first] == nums[first - 1])
                {
                    Console.WriteLine($"first重复，first:{first}");
                    continue;
                }
                // c 对应的指针初始指向数组的最右端
                int third = n - 1;
                int target = -nums[first];
                Console.WriteLine($"third:{third},target:{target}");
                // 枚举 b
                for (int second = first + 1; second < n; ++second)
                {
                    Console.WriteLine($"second:{second}");
                    // 需要和上一次枚举的数不相同
                    if (second > first + 1 && nums[second] == nums[second - 1])
                    {
                        Console.WriteLine($"Second重复，second:{second}");
                        continue;
                    }
                    // 需要保证 b 的指针在 c 的指针的左侧
                    while (second < third && nums[second] + nums[third] > target)
                    {
                        Console.WriteLine($"bc之和操作目标，third减少，second:{second}-third:{third}");
                        --third;
                    }
                    // 如果指针重合，随着 b 后续的增加
                    // 就不会有满足 a+b+c=0 并且 b<c 的 c 了，可以退出循环
                    if (second == third)
                    {
                        Console.WriteLine($"bc相遇无答案，进入下个a");
                        break;
                    }
                    if (nums[second] + nums[third] == target)
                    {
                        Console.WriteLine($"bc之和为目标值");
                        List<int> list = new List<int>();
                        list.Add(nums[first]);
                        list.Add(nums[second]);
                        list.Add(nums[third]);
                        ans.Add(list);
                    }
                }
            }
            return ans;
        }

        public static void Test()
        {
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };
            var ret = threeSum(nums);
            PublicFunc.DebugObj(ret);
        }
    }
}
