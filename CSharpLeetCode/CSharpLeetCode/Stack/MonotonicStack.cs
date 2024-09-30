using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Stack
{
    //单调栈
    public class MonotonicStack
    {
        public static int[] NextGreaterElement(int[] nums)
        {
            int[] result = new int[nums.Length];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"当前遍历{i}");
                while (stack.Count > 0 && nums[stack.Peek()] < nums[i])
                {
                    //单调递减栈，栈顶大，弹出，并且赋值结果数组
                    //需要使用while弹出，可能栈顶一直大，知道栈顶小
                    //栈存的是索引，才能得到更多信息
                    Console.WriteLine($"当前值[{i}] = {nums[i]}大于栈顶[{stack.Peek()}] = {nums[stack.Peek()]},出栈{stack.Peek()}");
                    result[stack.Pop()] = nums[i];
                    Console.WriteLine($"结果：{PublicFunc.GetObjet2Str(result)}");
                }
                stack.Push(i);
                Console.WriteLine($"入栈{i},栈{PublicFunc.GetObjet2Str(stack)}");
            }

            return result;
        }

        public static void Test()
        {
            int[] nums = { 2, 1, 5, 3, 6 };
            int[] result = NextGreaterElement(nums);
            PublicFunc.DebugObj(result,"结果");
        }
    }
}
