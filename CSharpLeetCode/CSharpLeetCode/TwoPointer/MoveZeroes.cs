using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.TwoPointer
{
    public class MoveZeroes
    {
        public static void moveZeroes(int[] nums)
        {
            //  使用双指针，左指针指向当前已经处理好的序列的尾部，右指针指向待处理序列的头部。
            int n = nums.Length, left = 0, right = 0;
            while (right < n)
            {
               
                if (nums[right] != 0)
                {
                    swap(nums, left, right);
                    Console.WriteLine($"right:{right}，left:{left},交换后{PublicFunc.GetObjet2Str(nums)}");
                    left++;
                    
                }
                //右指针不断向右移动，每次右指针指向非零数，则将左右指针对应的数交换，同时左指针右移。
                right++;
            }
        }

        public static void swap(int[] nums, int left, int right)
        {
            int temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
        }

        public static void Test()
        {
            int[] nums = new int[] { 1,0, 2, 3, 4 };
            moveZeroes(nums);
            PublicFunc.DebugObj(nums);
        }

    }
}
