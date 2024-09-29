using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Stack
{
    //字符串解码
    //https://leetcode.cn/problems/decode-string/description/?envType=study-plan-v2&envId=top-100-liked
    public class DecodeString
    {
        static int ptr = 0;

        public static string decodeString(string s)
        {
            Stack<string> stk = new Stack<string>();
            ptr = 0;

            while (ptr < s.Length)
            {
                char cur = s[ptr];
                if (IsCharNumber(cur))
                {
                    //把[前的所有数字组成一个字符串入栈
                    // 获取一个数字并进栈
                    //可能不止一位数，需要[前的数字都入栈，并且索引增加
                    string digits = getDigits(s);
                    stk.Push(digits);
                    Console.WriteLine($"入栈数字：{digits}——》栈{PublicFunc.GetObjet2Str(stk)}");
                }
                else if (IsCharLetter(cur) || cur == '[')
                {
                    // 获取一个字母并进栈
                    char c = s[ptr];
                    stk.Push(c.ToString());
                    ptr++;
                    Console.WriteLine($"入栈字母或[：{c}——》栈{PublicFunc.GetObjet2Str(stk)}");
                }
                else
                {
                    //找到了一个],遍历原字符串索引需要+1
                    ++ptr;
                    List<string> sub = new List<string>();
                    while (!("[" == stk.Peek()))
                    {
                        sub.Add(stk.Pop());
                    }
                    sub.Reverse();
                    // 左括号出栈
                    stk.Pop();
                    // 此时栈顶为当前 sub 对应的字符串应该出现的次数，同时出栈改数字
                    int repTime = int.Parse(stk.Pop());
                    StringBuilder t = new StringBuilder();
                    string o = getString(sub);
                    Console.WriteLine($"出现次数：{repTime}——》字符串{o}-》栈{PublicFunc.GetObjet2Str(stk)}");
                    // 构造字符串
                    while (repTime-- > 0)
                    {
                        t.Append(o);
                    }
                    // 将构造好的字符串入栈
                    stk.Push(t.ToString());
                    Console.WriteLine($"入栈处理完重复字符：{t}——》栈{PublicFunc.GetObjet2Str(stk)}");
                }
            }

            return GetString(stk);
        }

        public static string GetString(Stack<string> stk)
        {
            string ret = "";
            //遍历stk时注意，如果有入栈，出栈，size一直会变，所以需要提前缓存size
            int size = stk.Count;
            List<string> sub = new List<string>();
            for (int i = 0; i < size; i++)
            {
                sub.Add(stk.Pop());
                
            }
            sub.Reverse();
            for (int i = 0; i < sub.Count; i++)
            {
                ret += sub[i];
            }
            return ret;
        }

        public static string getDigits(string s)
        {
            StringBuilder ret = new StringBuilder();
            while (IsCharNumber(s[ptr]))
            {
                ret.Append(s[ptr++]);
            }
            return ret.ToString();
        }

        public static string getString(List<string> v)
        {
            StringBuilder ret = new StringBuilder();
            for (int i = 0; i < v.Count; i++)
            {
                ret.Append(v[i]);
            }

            return ret.ToString();
        }

        static bool IsCharNumber(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return true;
            }
            return false;
        }

        static bool IsCharLetter(char c)
        {
            if (c >= 'a' && c <= 'z')
            {
                return true;
            }
            return false;
        }

        public static void Test()
        {
            string s = "zzz3[a2[cb]]";
            Console.WriteLine($"{s}字符串解码{decodeString(s)}");
        }
    }
}
