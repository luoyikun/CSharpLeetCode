using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Sort
{
    public class MergeSort
    {
        // 归并排序的主体方法
        public static void DoMergeSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return; // 数组已经排序好
            }

            int mid = array.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            // 分解数组
            System.Array.Copy(array, 0, left, 0, mid);
            System.Array.Copy(array, mid, right, 0, right.Length);

            Console.WriteLine($"拆分为两个数组{PublicFunc.GetObjet2Str(left)}--{PublicFunc.GetObjet2Str(right)}");
            // 递归地对左右两部分进行归并排序
            DoMergeSort(left);
            DoMergeSort(right);

            // 合并两个已排序的数组
            Merge(array, left, right);
        }

        // 合并两个已排序的数组
        private static void Merge(int[] array, int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    array[k++] = left[i++];
                }
                else
                {
                    array[k++] = right[j++];
                }
            }

            // 复制剩余的元素
            while (i < left.Length)
            {
                array[k++] = left[i++];
            }

            while (j < right.Length)
            {
                array[k++] = right[j++];
            }
            Console.WriteLine($"合并两有序列：array{PublicFunc.GetObjet2Str(array)},left{PublicFunc.GetObjet2Str(left)},right{PublicFunc.GetObjet2Str(right)}");
            //PublicFunc.DebugObj(array, "合并两有序列");
        }

        // 测试归并排序
        public static void Test()
        {
            int[] array = { 5, 3, 8, 4, 2, 7, 1, 9, 6 };
            Console.WriteLine("Original array:");
            Console.WriteLine(string.Join(", ", array));

            DoMergeSort(array);

            Console.WriteLine("Sorted array:");
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
