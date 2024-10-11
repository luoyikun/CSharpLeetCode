using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.DynamicProgramming
{
    //爬楼梯
    //https://leetcode.cn/problems/climbing-stairs/solutions/286022/pa-lou-ti-by-leetcode-solution/?envType=study-plan-v2&envId=top-100-liked
    public class ClimbStair
    {
        public static int DoClimbStairs(int n)
        {
            int p = 0, q = 0, r = 1;
            for (int i = 1; i <= n; ++i)
            {
                p = q;
                q = r;
                r = p + q;
            }
            return r;
        }

        public static void Test()
        {
            int n = 3;
            int ret = DoClimbStairs(n);
            Console.WriteLine($"有{ret}种跳跃方法");
        }

    }
}
