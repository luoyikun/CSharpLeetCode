using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.AllArrange
{
    public static class StringArrange
    {
        static List<char> path;//临时访问路径
        static List<String> res;//结果集
        static bool[] visited;
        public static String[] permutation(String s)
        {
            path = new List<Char>();
            res = new List<String>();
            visited = new bool[s.Length];

            char[] arr = s.ToCharArray();
            System.Array.Sort(arr);
            dfs(arr, 0);

            String[] ss = new String[res.Count];
            for (int i = 0; i < res.Count; i++)
            {
                ss[i] = res[i];
            }

            return ss;

        }

        public static void Test()
        {
            String[] arrStr = permutation("aab");
            PublicFunc.DebugObj(arrStr);
        }

        // 时间复杂度：O(n*n!) 空间：N,N,递归调用最大深度也是 N，3n,O(n)
        /// <summary>
        /// 深度邮箱搜索
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k">访问了第几个，从0开始</param>
        static void dfs(char[] arr, int k)
        {
            if (arr.Length == k)
            {
                //如果访问长度，达到数组长度，找到路径
                res.Add(listToString(path));
                PublicFunc.DebugObj(path, "找到一条path：{0}-----------------------------------");
                return;
            }

            //进行N叉树搜索
            for (int i = 0; i < arr.Length; i++)
            {
                // 剪枝 aab
                if (i > 0 && arr[i] == arr[i - 1] && visited[i - 1] == false)
                {
                    //代表同层aa
                    continue;
                }
                if (visited[i] == false)
                {
                    // 递归访问
                    visited[i] = true;
                    Console.WriteLine(string.Format("设置{0}true", i));
                    path.Add(arr[i]);
                    PublicFunc.DebugObj(path, "加入后path{0}：");
                    Console.WriteLine(string.Format("加入路径：{0}；i:{1}；k:{2}", arr[i],i,k));
                    //访问下一个
                    dfs(arr, k + 1);
                    path.RemoveAt(path.Count - 1);
                    PublicFunc.DebugObj(path, "移除后path{0}：");
                    visited[i] = false; //深度优先搜索，搜索完了，把它设置为未访问
                    Console.WriteLine(string.Format("设置{0}false", i));
                }
            }
        }

        static String listToString(List<char> list)
        {
            StringBuilder b = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                b.Append(list[i]);
            }

            return b.ToString();
        }

    }
}
