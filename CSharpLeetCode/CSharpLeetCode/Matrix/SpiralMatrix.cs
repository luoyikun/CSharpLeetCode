using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Matrix
{
    //螺旋矩阵
    //https://leetcode.cn/problems/spiral-matrix/description/?envType=study-plan-v2&envId=top-100-liked
    public class SpiralMatrix
    {
        public static List<int> spiralOrder(int[][] matrix)
        {
            List<int> ans = new List<int>();
            int m = matrix.Length, n = matrix[0].Length;
            int left = 0, right = n - 1, top = 0, bottom = m - 1;
            int seq = 0;
            while (left <= right && top <= bottom)
            {
                // 从左到右
                for (int i = left; i <= right; i++)
                {
                    ans.Add(matrix[top][i]);
                }
                PublicFunc.DebugObj(ans, $"从左到右,left:{left},right:{right},top:{top},bottom:{bottom},seq:{seq}");
                top++;
                seq++;
                // 从上到下
                for (int i = top; i <= bottom; i++)
                {
                    ans.Add(matrix[i][right]);
                }
                PublicFunc.DebugObj(ans, $"从上到下,left:{left},right:{right},top:{top},bottom:{bottom},seq:{seq}");
                right--;
                seq++;
                // 从右到左，倒车的时候
                if (top <= bottom)
                {
                    for (int i = right; i >= left; i--)
                    {
                        ans.Add(matrix[bottom][i]);
                    }
                }
                PublicFunc.DebugObj(ans, $"从右到左,left:{left},right:{right},top:{top},bottom:{bottom},seq:{seq}");
                bottom--;
                seq++;
                // 从下到上
                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        ans.Add(matrix[i][left]);
                    }
                }
                PublicFunc.DebugObj(ans, $"从下到上,left:{left},right:{right},top:{top},bottom:{bottom},seq:{seq}");
                left++;
                seq++;
            }
            return ans;
        }

        public static void Test()
        {
            int[][] matrix ={   new int[] { 1, 2, 3,4 },  // 第一行
                                new int[] { 5,6,7,8 },  // 第二行
                                new int[] { 9,10,11,12 }   // 第三行
            };

            List<int> ret = spiralOrder(matrix);
            PublicFunc.DebugObj(ret);
        }

    }
}
