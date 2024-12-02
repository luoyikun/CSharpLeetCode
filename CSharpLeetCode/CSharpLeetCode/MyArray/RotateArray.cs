using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.MyArray
{
    //轮转数组
    //每调用一次，把尾部放置在最前面
    //https://leetcode.cn/problems/rotate-array/solutions/551039/xuan-zhuan-shu-zu-by-leetcode-solution-nipk/?envType=study-plan-v2&envId=top-100-liked
    public class RotateArray
    {
        public static int[] RotateUseOtherArray(int[] oriArr,int k)
        {
            int n = oriArr.Length;
            int[] newArr = new int[n];
            for (int i = 0; i < n; i++)
            {
                newArr[(i + k) % n] = oriArr[i];
            }
            return newArr;
        }

        public static void Test()
        {
            int[] oriArr = new int[7] { 1, 2, 3, 4, 5, 6, 7 };
            int[] newArr = RotateUseOtherArray(oriArr, 3);
            PublicFunc.DebugObj(newArr);
        }
    }
}
