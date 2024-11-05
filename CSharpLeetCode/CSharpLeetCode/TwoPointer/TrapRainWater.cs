using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.TwoPointer
{
    //接雨水
    public class TrapRainWater
    {
        public static int trap(int[] height)
        {
            int ans = 0;
            int left = 0, right = height.Length - 1;
            int leftMax = 0, rightMax = 0;
            while (left < right)
            {
                leftMax = Math.Max(leftMax, height[left]);
                rightMax = Math.Max(rightMax, height[right]);
                if (height[left] < height[right])
                {
                    ans += leftMax - height[left];
                    ++left;
                }
                else
                {
                    ans += rightMax - height[right];
                    --right;
                }
            }
            return ans;
        }

        public static void Test()
        {
            int[] arr = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            int ret = trap(arr);
            Console.WriteLine($"接雨水{ret}");
        }
    }
}
