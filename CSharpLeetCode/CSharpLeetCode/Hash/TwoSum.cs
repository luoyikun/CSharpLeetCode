using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Hash
{
    //两数之和
    public class TwoSum
    {

        public static int[] DoTwoSum(int[] nums, int target)
        {
            Dictionary<int, int> hashtable = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; ++i)
            {
                if (hashtable.ContainsKey(target - nums[i]))
                {
                    return new int[] { hashtable[target - nums[i]], i };
                }
                hashtable.Add(nums[i], i);
            }
            return new int[0];
        }

        public static void Test()
        {
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;
            int[] ret = DoTwoSum(nums, target);
            Console.WriteLine($"两数之和{PublicFunc.GetObjet2Str(ret)}");
        }



    }
}
