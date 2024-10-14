using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.DynamicProgramming
{
    //单词拆分
    public class WordBreak
    {
        public static bool DoWordBreak(string s, IList<string> wordDict)
        {
            var wordDictSet = new HashSet<string>(wordDict);
            //首先，我们初始化一个长度为 9 的布尔数组 dp，所有元素都初始化为 false，除了 dp[0]，它表示空字符串，所以初始化为 true。
            //1.确定dp数组（dp table）以及下标的含义：dp[i] 表示字符串 s 前 i 个字符组成的字符串 s[0..i−1] 是否能被空格拆分成若干个字典中出现的单词
            var dp = new bool[s.Length + 1];
            
            dp[0] = true;
            for (int i = 1; i <= s.Length; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    //遍历从当前字符到末尾。即当前字符+1，再+2，一直加到末尾。末尾是根据i动态调整。外循环跳转结尾，内循环调整开头
                    Console.WriteLine($"i={i},j={j},dp[{j}]={dp[j]},子串{s.Substring(j, i - j)}");
                    if (dp[j] && wordDictSet.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        Console.WriteLine($"dp[{j}] == true,{s.Substring(j, i - j)}包含在Key，设置dp[{i}] = true");
                        break;
                    }
                }
            }

            return dp[s.Length];
        }

        public static void Test()
        {
            string s = "leetcode";
            List<string> listKey = new List<string>(new string[] { "leet", "code" });
            bool ret = DoWordBreak(s, listKey);
            Console.WriteLine($"单词拆分{ret}");
        }

    }


}
