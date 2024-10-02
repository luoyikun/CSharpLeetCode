using CSharpLeetCode.Tree;
using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Heap
{
    //第K大的数在无序数组中
    public class KthInArray
    {
        public static int findKthLargest(int[] nums, int k)
        {
            int heapSize = nums.Length;
            buildMaxHeap(nums, heapSize);
            for (int i = nums.Length - 1; i >= nums.Length - k + 1; --i)
            {
                swap(nums, 0, i);//与队尾交换
                --heapSize; //size - 1，防止最大的数又参与了递归判断，又把最大数顶上了
                maxHeapify(nums, 0, heapSize);
            }
            return nums[0];
        }

        public static void buildMaxHeap(int[] a, int heapSize)
        {
            //完全二叉树的第一个非叶子节点是size/2 - 1
            //从最后个非叶节点，遍历到根节点
            for (int i = heapSize / 2 - 1; i >= 0; --i)
            {
                maxHeapify(a, i, heapSize);
            }
        }

        public static void maxHeapify(int[] a, int i, int heapSize)
        {
            Console.WriteLine($"处理索引[{i}]={a[i]} ,数组{PublicFunc.GetObjet2Str(a)},树{TreeUtil.BuildTreeByLevelOrderArr(a)}");
            int l = i * 2 + 1, r = i * 2 + 2, largest = i;
            if (l < heapSize && a[l] > a[largest])
            {
                largest = l;
            }
            if (r < heapSize && a[r] > a[largest])
            {
                largest = r;
            }
            if (largest != i)
            {
                
                swap(a, i, largest);
                Console.WriteLine($"交换{i}，{largest},数组{PublicFunc.GetObjet2Str(a)}");
                maxHeapify(a, largest, heapSize);//如果不是最底层，上面交换了，需要再对子树进行交换判断
                Console.WriteLine($"构建大顶堆{PublicFunc.GetObjet2Str(a)}");
                CSharpLeetCode.Tree.TreeUtil.BuildTreeByLevelOrderArr(a);
            }
        }

        public static void swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        public static void Test()
        {
            int[] arr = new int[] { 3, 2, 1, 5, 6, 4 };
            int ret = findKthLargest(arr,2);
            Console.WriteLine($"第K个最大数{ret}");
        }
    }
}
