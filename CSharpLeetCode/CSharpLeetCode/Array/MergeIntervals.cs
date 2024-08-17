using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Array
{
    //合并区间
    //https://leetcode.cn/problems/merge-intervals/description/?envType=study-plan-v2&envId=top-100-liked
    public static class MergeIntervals
    {
        public static IList<Interval> Merge(List<Interval> intervals)
        {
            if (intervals == null || intervals.Count < 2)
            {
                return intervals;
            }

            // 首先根据区间的起始位置对区间进行排序
            intervals.Sort((a, b) => a.start - b.start);
            PublicFunc.DebugObj(intervals, "排序后{0}");
            List<Interval> result = new List<Interval>();
            Interval last = intervals[0];

            for (int i = 1; i < intervals.Count; i++)
            {
                Interval current = intervals[i];
                // 如果当前区间的起始位置小于等于上一个区间的结束位置，则合并区间
                if (current.start <= last.end)
                {
                    Console.WriteLine($"当前cur.start比last.end 小，cur:{PublicFunc.GetObjet2Str(current)},last：{PublicFunc.GetObjet2Str(last)}");
                    last.end = Math.Max(last.end, current.end);
                    PublicFunc.DebugObj(intervals, "合并后{0}");
                }
                else
                {
                    // 如果不重叠，则将上一个区间添加到结果中，并更新上一个区间为当前区间
                    result.Add(last);
                    Console.WriteLine($"找到一个合并区间{PublicFunc.GetObjet2Str(last)},加入到结果集{PublicFunc.GetObjet2Str(result)},并更新last为{PublicFunc.GetObjet2Str(current)}");
                    last = current;
                }
            }

            // 添加最后一个区间到结果中
            result.Add(last);
            Console.WriteLine($"加入最终合并区间{PublicFunc.GetObjet2Str(last)},最终结果集{PublicFunc.GetObjet2Str(result)}");
            return result;
        }

        public static void Test()
        {
            List<Interval> listOri = new List<Interval>(new Interval[] {
                new Interval(1,3),
                new Interval(2,6),
                new Interval(8,10),
                new Interval(15,18),
            });

            IList<Interval> listRet = Merge(listOri);
            PublicFunc.DebugObj(listRet);
        }

        public class Interval
        {
            public int start;
            public int end;

            public Interval(int s, int e)
            {
                start = s;
                end = e;
            }
        }

    }
}
