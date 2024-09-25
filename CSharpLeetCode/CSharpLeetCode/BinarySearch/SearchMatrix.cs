using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.BinarySearch
{
    /// <summary>
    /// 搜索
    /// </summary>
    public class SearchMatrix
    {
        static bool searchMatrix(int[][] matrix, int target)
        {

            int m = matrix.Length, n = matrix[0].Length;

            //过滤不在矩阵范围的数据
            if (target < matrix[0][0] || target > matrix[m - 1][n - 1])
                return false;

            //先找到所在行
            int col = 0;
            int left = 0, right = m - 1;
            while (left <= right)
            {
                int mid = (right + left) / 2;
                if (matrix[mid][0] > target) //在mid行上面
                    right = mid - 1;
                else if (matrix[mid][n - 1] < target)    //在mid行下面
                    left = mid + 1;
                else    //在当前行上
                {
                    col = mid;
                    break;
                }
            }

            //再寻找所在列
            left = 0;
            right = n - 1;
            while (left <= right)
            {
                int mid = (right + left) / 2;
                if (matrix[col][mid] == target)
                    return true;
                else if (matrix[col][mid] > target)
                    right = mid - 1;
                else if (matrix[col][mid] < target)
                    left = mid + 1;
            }

            return false;
        }


        public static void Test()
        {
            int[][] matrix = new int[3][] {
                new int[]{ 1, 3, 5, 7 },
                new int[]{10, 11, 16, 20 },
                new int[]{23, 30, 34, 60 }
            };
            //int[][] matrix = new int[1][] {
            //    new int[]{ 1}

            //};

            int[][] matrix3 = new int[1][] {
                new int[]{ 1, 3}

            };

            bool ret = searchMatrix(matrix, 11);
            //bool ret = searchMatrix(matrix3, 3);
            Console.WriteLine($"二维矩阵搜索找到目标：{ret}");

          

        }

       
    }

}
