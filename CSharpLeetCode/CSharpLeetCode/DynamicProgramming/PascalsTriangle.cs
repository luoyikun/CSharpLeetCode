using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.DynamicProgramming
{
    //杨辉三角
    //https://leetcode.cn/problems/pascals-triangle/solutions/510638/yang-hui-san-jiao-by-leetcode-solution-lew9/?envType=study-plan-v2&envId=top-100-liked
    public class PascalsTriangle
    {
        static List<List<int>> DoPascalsTriangle(int numRows)
        {
            //1.确定dp数组（dp table）以及下标的含义,分为行，从第0行开始。每行是个List<int>
            //2.递推公式，每行为n+1个元素，头尾都是1。每行第1列开始，为 dp[r][c] = dp[r - 1][c - 1] + dp[r - 1][c];
            List<List<int>> dp = new List<List<int>>(numRows);
            for (int r = 0; r < numRows; r++)
            {
                //3.dp数组如何初始化,每行r+1个元素，首尾为1
                var oneLine = new List<int>(new int[r + 1]);
                dp.Add(oneLine);
                dp[r][0] = dp[r][r] = 1;
                //4.确定遍历顺序。每行从1开始，到r-1，根据递推公式赋值
                for (int c = 1; c < r; ++c)
                {
                    dp[r][c] = dp[r - 1][c - 1] + dp[r - 1][c];
                }
            }
            return dp;
        }

        public static void Test()
        {
            List<List<int>> ret = DoPascalsTriangle(5);
            PublicFunc.DebugObj(ret);
        }
    }
}
