using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Backtrack
{
    //https://programmercarl.com/0077.%E7%BB%84%E5%90%88.html#%E7%AE%97%E6%B3%95%E5%85%AC%E5%BC%80%E8%AF%BE
    //给定两个整数 n 和 k，返回 1 ... n 中所有可能的 k 个数的组合。
    //示例: 输入: n = 4, k = 2 输出: [ [2,4], [3,4], [2,3], [1,2], [1,3], [1,4], ]
    public static class Combination
    {
        public static IList<IList<int>> res = new List<IList<int>>();
        public static IList<int> path = new List<int>();
        public static IList<IList<int>> Combine(int n, int k)
        {
            BackTracking(n, k, 1);
            return res;
        }
        public static void BackTracking(int n, int k, int start)
        {
            if (path.Count == k)
            {
                Console.WriteLine($"输出{PublicFunc.GetObjet2Str(path)}");
                res.Add(new List<int>(path));
                return;
            }
            for (int i = start; i <= n; i++)
            {
                Console.WriteLine($"增加{PublicFunc.GetObjet2Str(path)} add{i}");
                path.Add(i);
                BackTracking(n, k, i + 1);
                Console.WriteLine($"回退{PublicFunc.GetObjet2Str(path)} remove {path[path.Count - 1]}");
                path.RemoveAt(path.Count - 1);
                
            }
        }

        public static void Test()
        {
            Combine(4, 2);
            PublicFunc.DebugObj(res);
        }
    }
}
