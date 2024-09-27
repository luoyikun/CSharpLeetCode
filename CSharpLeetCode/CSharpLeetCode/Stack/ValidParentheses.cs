using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Stack
{
    //括号匹配
    public class ValidParentheses
    {
        public static bool IsValid(string s)
        {
            int n = s.Length;
            //一定是偶数才能匹配，先不符合条件的返回false
            if (n % 2 == 1)
            {
                return false;
            }

            //按照字典存储，key为右括号，用来匹配，方便扩展
            Dictionary<char, char> pairs = new Dictionary<char, char>() {
                { ')', '(' },
                { ']', '['},
                { '}', '{' }
            };

            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < n; i++)
            {
                //遍历字符串
                char ch = s[i];
                if (pairs.ContainsKey(ch))
                {
                    //如果是右括号，说明要匹配栈顶
                    if (stack.Count == 0 || stack.Peek() != pairs[ch])
                    {
                        //栈空，或者栈顶不是左括号，未匹配
                        return false;
                    }
                    //匹配成功，左括号栈顶出栈
                    stack.Pop();
                }
                else
                {
                    //左括号入栈
                    stack.Push(ch);
                }
            }
            //栈为空，说明全部匹配成功
            return stack.Count  == 0;
        }

        public static void Test()
        {
            string s = "(()[]{})";
            bool ret = IsValid(s);
            Console.WriteLine($"括号是否匹配{ret}");
        }
    }
}
