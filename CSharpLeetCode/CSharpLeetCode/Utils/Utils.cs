
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace CSharpLeetCode.Utils
{
    public class Utils
    {
        public static void PrintArr(int[] arr)
        {
            string str = JsonConvert.SerializeObject(arr);
            Console.WriteLine(str);
        }
    }
}
