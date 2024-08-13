using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Graph
{
    //有限图冗余连接
    public static class RedundantConnections
    {
        static int n = 1000;
        static List<int> father = new List<int>(1000);

        static void Init()
        {
            for (int i = 1; i <= n; ++i)
            {
                father[i] = i;
            }
        }

        // 并查集里寻根的过程
        static int find(int u)
        {
            return u == father[u] ? u : father[u] = find(father[u]);
        }

        // 将v->u 这条边加入并查集
        static void join(int u, int v)
        {
            u = find(u);
            v = find(v);
            if (u == v) return;
            father[v] = u;
        }
        // 判断 u 和 v是否找到同一个根
        static bool same(int u, int v)
        {
            u = find(u);
            v = find(v);
            return u == v;
        }

        // 在有向图里找到删除的那条边，使其变成树
        static void getRemoveEdge( List<List<int>> edges) 
        {
            Init(); // 初始化并查集
            for (int i = 0; i<n; i++) { // 遍历所有的边
                if (same(edges[i][0], edges[i][1])) { // 构成有向环了，就是要删除的边
                    Console.WriteLine($"{edges[i][0] }-{ edges[i][1]}");
                    return;
                } else {
                    join(edges[i][0], edges[i][1]);
                }
            }
        }

        // 删一条边之后判断是不是树
        static bool isTreeAfterRemoveEdge(List<List<int>> edges, int deleteEdge)
        {
            Init(); // 初始化并查集
            for (int i = 0; i < n; i++)
            {
                if (i == deleteEdge) continue;
                if (same(edges[i][0], edges[i][1]))
                { // 构成有向环了，一定不是树
                    return false;
                }
                join(edges[i][0], edges[i][1]);
            }
            return true;
        }

        public static void Test()
        {
            List<List<int>> edges = new List<List<int>>();
            Dictionary<int,int> inDegree = new Dictionary<int,int>();
            
            {
                List<int> list = new List<int>(new int[] { 2, 1 });
                edges.Add(list);
            }
            {
                List<int> list = new List<int>(new int[] { 1, 3 });
                edges.Add(list);
            }
            {
                List<int> list = new List<int>(new int[] { 3, 2 });
                edges.Add(list);
            }
            {
                List<int> list = new List<int>(new int[] { 3, 4 });
                edges.Add(list);
            }

            for (int i = 0; i < edges.Count; i++)
            {
                if (inDegree.ContainsKey(edges[i][1]) == false)
                {
                    inDegree.Add(edges[i][1], 0);
                }
                inDegree[edges[i][1]]++;
            }

            var reversed = inDegree.Reverse();
            foreach (var kvp in reversed)
            {
                // 倒序处理键值对
                Console.WriteLine(kvp.Value);
            }

        }

    }
}
