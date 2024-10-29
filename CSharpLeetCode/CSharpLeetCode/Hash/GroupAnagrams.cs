using CSharpLeetCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Hash
{
    public class GroupAnagrams
    {
        public static List<List<string>> DoGroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            for (int strsIdx = 0; strsIdx < strs.Length; strsIdx++)
            {
                string str = strs[strsIdx];
                //生成key
                int[] counts = new int[26];
                int length = str.Length;
                for (int i = 0; i < length; i++)
                {
                    counts[str[i] - 'a']++;
                }
                // 将每个出现次数大于 0 的字母和出现次数按顺序拼接成字符串，作为哈希表的键
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 26; i++)
                {
                    if (counts[i] != 0)
                    {
                        sb.Append((char)('a' + i));
                        sb.Append(counts[i]);
                    }
                }
                string key = sb.ToString();
                Console.WriteLine($"key：{key}");
                //相同key 的加在一起
                if (map.ContainsKey(key))
                {
                    map[key].Add(str);
                }
                else
                {
                    List<string> listNew = new List<string>();
                    listNew.Add(str);
                    map.Add(key, listNew);
                }
            }
            return new List<List<string>>(map.Values);
        }

        public static void Test()
        {
            string[] strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            List<List<string>> ret = DoGroupAnagrams(strs);
            PublicFunc.DebugObj(ret);
        }


    }
}
