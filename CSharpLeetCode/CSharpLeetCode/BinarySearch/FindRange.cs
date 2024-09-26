
using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.BinarySearch
{
    //寻找区间
    public class FindRange
    {
        // 两次二分查找，分开查找第一个和最后一个
        // 时间复杂度 O(log n), 空间复杂度 O(1)
        // [1,2,3,3,3,3,4,5,9]
        public static int[] searchRange2(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int first = -1;
            int last = -1;
            // 找第一个等于target的位置
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (nums[middle] == target)
                {
                    first = middle; //找到一次不要返回，可能前面还有
                    right = middle - 1; //重点，可能前面还有，right = mid -1，向前接着找
                }
                else if (nums[middle] > target)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            // 最后一个等于target的位置
            left = 0;
            right = nums.Length - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (nums[middle] == target)
                {
                    last = middle; 
                    left = middle + 1; //重点，可能后面还有，left = mid + 1，向后面接着找
                }
                else if (nums[middle] > target)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return new int[] { first, last };
        }

        public static void Test()
        {
            int[] arr = new int[] { 5, 7, 7, 8, 8, 10 };
            int[] ret = searchRange2(arr, 8);
            Console.WriteLine($"找到区间{PublicFunc.GetObjet2Str(ret)}");
        }
    }
}
