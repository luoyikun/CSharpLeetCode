using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Array
{
    public static class ReversalArray
    {
        public static int minArray(int[] numbers)
        {

            // 设置 left, right 指针分别指向 numbers 数组左右两端
            // left 指向当前区间的最左边位置，所以初始化为 0
            int left = 0;

            //  right 指向当前区间的最右边位置，所以初始化为 nums.length - 1
            int right = numbers.Length - 1;


            // 循环进行二分查找，直到左端点位置超过了右端点
            // 或者在循环过程中找到了起始位置
            while (left < right)
            {

                // mid 为中点（这里向下取整，比如 （ 2 + 7 ）/ 2 = 4 )
                int mid = (left + right) / 2;

                // 当 mid 点所在元素大于数组末端的元素时，由于原来的数组是递增有序的，此时出现了异常，大的数在前面
                // 所以旋转点在 [ mid + 1, end ] 区间里面
                if (numbers[mid] > numbers[right])
                {

                    // 所以旋转点在 [ mid + 1, end ] 区间里面 ，更新 left 的位置为 mid + 1
                    left = mid + 1;

                    // 当 mid 点所在元素小于数组末端的元素时，由于原来的数组是递增有序的
                    // 所以旋转点在 [ left, mid ] 区间里面
                }
                else if (numbers[mid] < numbers[right])
                {

                    // 旋转点在 [ left, mid ] 区间里面 ，更新 right 的位置为 mid 
                    right = mid;

                    // 此时，出现了 numbers[mid] = numbers[end] 的情况，无法判断
                    // [ start , mid ]  为有序数组区间
                    // 还是  [ mid , end ]  为有序数组区间
                    // 比如： [1, 0, 1, 1, 1] 和  [1, 1, 1, 0, 1]
                }
                else
                {
                    //  所以这里采取遍历的方式
                    return findMin(numbers, left, right);

                }
            }
            return numbers[left];
        }

        // 从头到尾遍历 numbers ，获取到最小值
        public static int findMin(int[] numbers, int left, int right)
        {

            // 默认为数组的第一个元素为最小值
            int result = numbers[left];

            // 从头到尾遍历 numbers
            for (int i = left; i <= right; i++)
            {

                // 当发现此时遍历的元素值小于 result
                if (numbers[i] < result)
                {
                    // 那么更新 result
                    result = numbers[i];
                }
            }
            // 返回 numbers 中的最小值
            return result;
        }

        public static void Test()
        {
            int[] numbers = { 4,5,6,1,2,3};
            int ret = minArray(numbers);
            Console.WriteLine(ret);
        }
    }
}
