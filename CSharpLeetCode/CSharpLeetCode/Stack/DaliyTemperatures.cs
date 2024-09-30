using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Stack
{
    //每日温度
    //https://leetcode.cn/problems/daily-temperatures/solutions/283196/mei-ri-wen-du-by-leetcode-solution/?envType=study-plan-v2&envId=top-100-liked
    public class DaliyTemperatures
    {
        public static int[] dailyTemperatures(int[] temperatures)
        {
            int length = temperatures.Length;
            int[] ans = new int[length];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"遍历{i}");
                int temperature = temperatures[i];
                while (!(stack.Count == 0 )&& temperature > temperatures[stack.Peek()])
                {
                    Console.WriteLine($"当前温度{temperature} > 栈顶温度{temperatures[stack.Peek()]}，弹出索引{stack.Peek()},更新ans[{stack.Peek()}] = { i - stack.Peek()} ");
                    //单调递减栈，弹出时，说明栈顶的索引对应值，找到了右边第一个比它大的温度，更新ans对应的索引
                    int prevIndex = stack.Pop();
                    ans[prevIndex] = i - prevIndex;
                    Console.WriteLine($"ans = {PublicFunc.GetObjet2Str(ans)},栈为{PublicFunc.GetObjet2Str(stack)}");
                }
                stack.Push(i);
                //每个索引都会入栈，为单调递减栈。只是入栈前，大于的都会先出栈
                Console.WriteLine($"入栈{i}，此时栈{PublicFunc.GetObjet2Str(stack)}");
            }
            return ans;
        }

        public static void Test()
        {
            int[] temperatures = new int[] { 73, 74, 75, 71, 69, 72, 76, 73 };
            int[] ans = dailyTemperatures(temperatures);
            Console.WriteLine($"每日温度{PublicFunc.GetObjet2Str(ans)}");
        }
    }
}
