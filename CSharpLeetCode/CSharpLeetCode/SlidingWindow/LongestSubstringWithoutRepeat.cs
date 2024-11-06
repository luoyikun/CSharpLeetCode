using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.SlidingWindow
{
    //无重复字符的最长子串
    public class LongestSubstringWithoutRepeat
    {
        public static int lengthOfLongestSubstring(String s)
        {
            //滑动窗口
            char[] ss = s.ToCharArray();
            HashSet<char> set = new HashSet<char>();//去重
            int res = 0;//结果
            for (int left = 0, right = 0; right < s.Length; right++)
            {
                //每一轮右端点都扩一个。
                char ch = ss[right];//right指向的元素，也是当前要考虑的元素
                Console.WriteLine($"当前遍历到的元素right：{right}，字符{ch}");
                while (set.Contains(ch))
                {
                    Console.WriteLine($"hash:{PublicFunc.GetObjet2Str(set)}中已经包含字符{ch}");
                    //set中有ch，则缩短左边界，同时从set集合出元素
                    //一直缩短左边界，直到hash里面没有与即将加进来的char重复的元素
                    set.Remove(ss[left]);
                    left++;
                    Console.WriteLine($"hash移除重复right:{PublicFunc.GetObjet2Str(set)}，左边界增加");
                }
                set.Add(ss[right]);//别忘。将当前元素加入。
                res = Math.Max(res, right - left + 1);//计算当前不重复子串的长度。
                Console.WriteLine($"hash增加右边:{PublicFunc.GetObjet2Str(set)}，最长子串{res}");
                Console.WriteLine();
            }
            return res;
        }

        public static void Test()
        {
            string s = "abcabcbb";
            int ans = lengthOfLongestSubstring(s);
            Console.WriteLine($"最长子串长度{ans}");
        }
    }
}
