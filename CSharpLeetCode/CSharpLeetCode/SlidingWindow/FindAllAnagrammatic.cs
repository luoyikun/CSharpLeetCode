﻿using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.SlidingWindow
{
    //找到所有异位词
    //https://leetcode.cn/problems/find-all-anagrams-in-a-string/solutions/1123971/zhao-dao-zi-fu-chuan-zhong-suo-you-zi-mu-xzin/?envType=study-plan-v2&envId=top-100-liked
    public static class FindAllAnagrammatic
    {
        public static List<int> findAnagrams(string s, string t)
        {
            Dictionary<char, int> need = new Dictionary<char, int>();
            Dictionary<char, int> window = new Dictionary<char, int>();
            for (int i = 0; i < t.Length; i++)
            {
                if (need.ContainsKey(t[i]) == false)
                {
                    need.Add(t[i], 0);
                }
                need[t[i]]++;
            }
            PublicFunc.DebugObj(need);
            int left = 0, right = 0;
            int valid = 0;
            List<int> res = new List<int>(); // 记录结果
            while (right < s.Length)
            {
                char c = s[right];
                right++;
                // 进行窗口内数据的一系列更新
                if (need.ContainsKey(c))
                {
                    if (window.ContainsKey(c) == false)
                    {
                        window.Add(c, 0);
                    }
                    window[c]++;
                    if (window[c] == need[c])
                        valid++;
                }
                // 判断左侧窗口是否要收缩
                while (right - left >= t.Length)
                {
                    // 当窗口符合条件时，把起始索引加入 res
                    if (valid == need.Count)
                        res.Add(left);
                    char d = s[left];
                    left++;
                    // 进行窗口内数据的一系列更新
                    if (need.ContainsKey(d))
                    {
                        if (window[d] == need[d])
                            valid--;
                        window[d]--;
                    }
                }
            }
            return res;
        }


        public static void Test()
        {
            List<int> res = findAnagrams("cbaebabacd", "abc");
            PublicFunc.DebugObj(res);
        }

    }
}