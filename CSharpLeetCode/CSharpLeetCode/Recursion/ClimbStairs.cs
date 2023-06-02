using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Recursion
{
    //一个人爬楼梯，一步可以迈一级，二级，三级台阶， 如果楼梯有N级，编写程序，输出所有走法
    //https://blog.csdn.net/C_S__D_N_/article/details/121044375
    public static class ClimbStairs
    {

        static int[] ans = new int[20];
        static int n = 5;
        static void print(int i)
        {
            string s = "";
            for (int k = 0; k < i; k++)
            {
                s += ans[k] + ",";
            }
            Console.WriteLine(s);
        }
        static void dfs(int s, int i) //s--总爬了多少格,i--爬了几次
        {
            if (s == n) { print(i); return; }
            else if (s <= n-1)
            {
                ans[i] = 1; //第 i 次，爬 1 个台阶
                dfs(s + 1, i + 1);
            }
            else if (s <= n - 2)
            {
                ans[i] = 2; //第 i 次，爬 2 个台阶
                dfs(s + 2, i + 1);
            }
        }
        public static void Test()
        {

            dfs(0, 0);

        }
    }
}
