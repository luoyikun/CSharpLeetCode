using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.LinkedList
{
    /// <summary>
    /// 检测循环引用
    /// </summary>
    public class CircularDependency
    {
        static List<StampItem> m_Stamps = new List<StampItem>(8);
        /// <summary>
        /// 检查循环依赖
        /// </summary>
        /// <param name="host">待检查资源</param>
        /// <param name="route">路径表，每次访问新的加入</param>
        /// <param name="visited">已访问表</param>
        /// <returns></returns>
        private static bool Check(string host, LinkedList<string> route, HashSet<string> visited)
        {
            visited.Add(host);
            route.AddLast(host);
            Console.WriteLine(string.Format("{0}加入到已访问，和路径表最后一个", host));
            foreach (var stamp in m_Stamps)
            {
                if (host != stamp.HostAssetName)
                {
                    continue;
                }

                if (visited.Contains(stamp.DependencyAssetName))
                {
                    Console.WriteLine("访问表已包含" + stamp.DependencyAssetName);
                    //已经访问节点已经包含了依赖，说明成循环了
                    route.AddLast(stamp.DependencyAssetName);
                    PublicFunc.DebugObj(route);
                    return true;
                }

                if (Check(stamp.DependencyAssetName, route, visited))
                {
                    return true;
                }
            }

            string lastRoute = route.Last.Value;
            route.RemoveLast();
            visited.Remove(host);
            Console.WriteLine(string.Format("删除路径表的最后一个{0}，已访问表{1}", lastRoute, host));
            return false;
        }

        public static void Test()
        {
            
            string[] arrStamp = new string[] {"A","B",
                "B","A"
            };

            for (int i = 0; i < arrStamp.Length; i+= 2)
            {
                StampItem one = new StampItem();
                one.HostAssetName = arrStamp[i];
                one.DependencyAssetName = arrStamp[i+1];
                m_Stamps.Add(one);
            }
            

        }
    }

    public class StampItem
    {
        public string HostAssetName; //主资源
        public string DependencyAssetName; //依赖资源
    }
}
