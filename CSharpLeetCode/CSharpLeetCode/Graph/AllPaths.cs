using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Graph
{
    /// <summary>
    /// 所有可达路径
    /// https://programmercarl.com/kamacoder/0098.%E6%89%80%E6%9C%89%E5%8F%AF%E8%BE%BE%E8%B7%AF%E5%BE%84.html#%E6%9C%AC%E9%A2%98%E4%BB%A3%E7%A0%81
    /// https://leetcode.cn/problems/all-paths-from-source-to-target/description/
    /// </summary>
    public static class AllPaths
    {
        static List<List<int>> m_listAllPath = new List<List<int>>(8); //所有路径
        static List<int> m_listCurPath = new List<int>(); //当前路径
        static Dictionary<int,List<int>> m_graph = new Dictionary<int, List<int>>(); //邻接表构建有向图
        static void dfs(int cur,int target)
        {
            if (cur == target)
            {
                m_listAllPath.Add(new List<int>(m_listCurPath));
                return;
            }
            List<int> list = m_graph[cur];
            for (int i = 0; i < list.Count; i++)
            {
                int curNode = list[i];
                m_listCurPath.Add(curNode);
                Console.WriteLine($"{PublicFunc.GetObjet2Str(m_listCurPath)}增加{curNode}");
                dfs(curNode, target);
                //m_listCurPath.Remove(curNode); //remove 是找个值相等的item
                m_listCurPath.RemoveAt(m_listCurPath.Count - 1); //RemoveAt 第几个索引移除
                Console.WriteLine($"{PublicFunc.GetObjet2Str(m_listCurPath)}移除{curNode}");
            }
        }

        static void CreateGraph()
        {
            m_graph.Add(0, new List<int>(new int[] { 1,2}));
            m_graph.Add(1, new List<int>(new int[] {3 }));
            m_graph.Add(2, new List<int>(new int[] {3 }));
            m_graph.Add(3, new List<int>());
        }

        public static void Test()
        {
            CreateGraph();
            m_listCurPath.Add(0);
            dfs(0, 3);
            PublicFunc.DebugObj(m_listAllPath);
        }
    
    }
}
