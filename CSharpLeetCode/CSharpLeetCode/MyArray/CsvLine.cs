using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.MyArray
{
    public static class CsvLine
    {
        public static void Test()
        {
            string text = "1,\"gdf,\"\"123,\"\"\",5";
            string splitter = "[liyu]";
            bool startCell = false;
            StringBuilder line = new StringBuilder();
            for (int i = 0; i < text.Length; ++i)
            {
                char c = text[i];
                if (c == '"')
                {
                    if (text[i + 1] == '"') i++;
                    else
                    {
                        startCell = !startCell;
                        continue;
                    }
                }
                else if (!startCell && c == ',')
                {
                    line.Append(splitter);
                    continue;
                }
                else if (!startCell && c == '\n')
                {
                    
                    line.Length = 0;
                    continue;
                }
                line.Append(c);
            }
            Console.Write(line);
        }
    }
}
