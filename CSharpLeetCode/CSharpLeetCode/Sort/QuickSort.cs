using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  CSharpLeetCode.Utils;
namespace CSharpLeetCode.Sort
{
    public class QuickSort
    {
        //由小到大
        static void quick_sort(int[] s, int l, int r)
        {
            if (l < r)
            {
                int i = l, j = r, x = s[l];
                while (i < j)
                {
                    while (i < j && s[j] >= x) // 从右向左找第一个小于x的数
                    {
                        j--;
                    }
                    if (i < j)
                    {
                        s[i] = s[j];
                        i++;
                    }
                    while (i < j && s[i] < x) // 从左向右找第一个大于等于x的数
                    {
                        i++;
                    }
                    if (i < j)
                    {
                        s[j] = s[i];
                        j--;
                    }
                }

                //这时 i == j，开始取的基准数 x 填入现在的坑位中
                s[i] = x;
                Console.WriteLine("i = {0}", i);
                CSharpLeetCode.Utils.Utils.PrintArr(s);
                //按照i位置再分为左半边，右半边，进行排序
                quick_sort(s, l, i - 1); // 递归调用
                quick_sort(s, i + 1, r);

            }

        }

        public static void Test()
        {
            int[] array = new int[4] { 5, 2, 1, 1 };
            quick_sort(array, 0, array.Length - 1);
        }

        
    }
}
