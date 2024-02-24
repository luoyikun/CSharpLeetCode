using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Utils
{
    public static class PublicFunc
    {
        public static string GetObjet2Str<T>(T obj)
        {
            string str = "";
            str = JsonConvert.SerializeObject(obj);
            return str;
        }

        public static string DebugObj<T>(T obj,string sAdd = "")
        {
            string str = "";
            str = JsonConvert.SerializeObject(obj);
            if (sAdd == "")
            {
                Console.WriteLine(str);
            }
            else
            {
                Console.WriteLine(string.Format(sAdd, str));
            }
            return str;
        }
    }
}
