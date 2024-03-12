using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Recursion
{
    public class Fibonacci
    {
        int fibonacci(int first, int second, int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            if (n < 3)
            {
                return 1;
            }
            else if (n == 3)
            {
                return first + second;
            }
            else
            {
                return fibonacci(second, first + second, n - 1);
            }
        }
    }
}
