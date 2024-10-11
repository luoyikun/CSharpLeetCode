using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.GreedyAlgorithm
{
    //跳跃游戏2
    public class Jump2
    {
        //反向查找，时间复杂度O(n^2)
        public static int DoJumpReverse(int[] nums)
        {
            int position = nums.Length - 1;
            int steps = 0;
            while (position > 0)
            {
                for (int i = 0; i < position; i++)
                {
                    //每次从前向后找到，最快能包含最右边的。局部最优推导出全局最优
                    if (i + nums[i] >= position)
                    {
                        position = i; //更新右边界索引
                        steps++;
                        break;
                    }
                }
            }
            return steps;
        }

        //正向查找，时间复杂度O(n)
        public static int DoJump(int[] nums)
        {
            int length = nums.Length;
            int end = 0;
            int maxPosition = 0;
            int steps = 0;
            //不必访问最后一个，因为题意已经可以跳到，并且会增加步数
            for (int i = 0; i < length - 1; i++)
            {
                //每次确定i能跳到最远的地方最为右边界，当前步能跳到的地方 = i + nums[i] 以及之前最远地方的的两者最大值
                maxPosition = Math.Max(maxPosition, i + nums[i]);
                if (i == end)
                {
                    //遍历到了边界，步数+1，更新右边界。右边界是当前可跳跃到的最大值
                    end = maxPosition;
                    steps++;
                }
            }
            return steps;
        }



        public static void Test()
        {
            int[] nums = new int[]{ 2, 3, 1, 1, 4};
            int step = DoJump(nums);
            Console.WriteLine($"跳跃到终点最少步数{step}");
        }
    }
}
