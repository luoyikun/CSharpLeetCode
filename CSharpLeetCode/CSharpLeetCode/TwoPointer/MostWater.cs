using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.TwoPointer
{
    //接更多水的容器
    //https://leetcode.cn/problems/container-with-most-water/description/?envType=study-plan-v2&envId=top-100-liked
    public class MostWater
    {
        public static  int maxArea(int[] height)
        {
            int l = 0, r = height.Length - 1;
            int ans = 0;
            while (l < r)
            {
                int area = Math.Min(height[l], height[r]) * (r - l);
                ans = Math.Max(ans, area);
                if (height[l] <= height[r])
                {
                    ++l;
                }
                else
                {
                    --r;
                }
            }
            return ans;
        }

        public static void Test()
        {
            int[] arr = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            int ret = maxArea(arr);
            Console.WriteLine($"接更多水容器的值{ret}");
        }
    }
}
