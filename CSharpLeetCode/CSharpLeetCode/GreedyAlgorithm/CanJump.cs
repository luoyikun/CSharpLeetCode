using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.GreedyAlgorithm
{
    //跳跃游戏
    public class CanJump
    {
        public static bool DoCanJump(int[] nums)
        {
            int n = nums.Length;
            int rightmost = 0;//右边界
            for (int i = 0; i < n; ++i)
            {
                if (i <= rightmost)
                {
                    //右边界可到达i才可以进行计算，例如输入[1,0,0,5,1],实际是不可到达
                    //尽可能扩展右边界
                    rightmost = Math.Max(rightmost, i + nums[i]);
                    if (rightmost >= n - 1)
                    {
                        //右边界包含了最后一个索引
                        return true;
                    }
                }
            }
            return false;
        }

        public static void Test()
        {
            int[] nums = new int[] { 2, 3, 1, 1, 4 };
            bool isCanJump = DoCanJump(nums);
            Console.WriteLine($"是否可到达{isCanJump}");
        }

    }
}
