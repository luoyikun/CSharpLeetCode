using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpLeetCode.Regex
{
    //正则表达式，捕获aaa，bbb两行之间
    public static class RegexBetween
    {
        static string m_sUIBindStar = "--region UI绑定开始------------------------------------\r\n";
        static string m_sUIBindEnd = "--endregion UI绑定结束------------------------------------\r\n";

        public static void Test()
        {
            string input = "function UIForm:UIBinding()\r\n--region UI绑定开始------------------------------------\r\n\r\n--endregion UI绑定结束------------------------------------\r\nend\r\n";

            string prefix = string.Format($"function ShiTuMainForm:UIBinding()\r\n{m_sUIBindStar}");
            string suffix = m_sUIBindEnd + "end\r\n";
            // 正则表达式模式需要用 @ 符号定义为原字符串
            string pattern = $@"(?<={m_sUIBindStar})(.*?)(?={m_sUIBindEnd})";
            string replacement = "目标字符串\n目标字符串2\n";

            // 使用正则表达式替换内容
            string result = System.Text.RegularExpressions.Regex.Replace(input, pattern, replacement, RegexOptions.Singleline);

            Console.WriteLine("替换后的结果是：\n" + result);
        }
    }
}
