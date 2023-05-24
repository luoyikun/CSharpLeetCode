using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.For
{
    //https://blog.algomooc.com/005.html
    public static class StringReplaceBank
    {
        static string m_strOri = "We are happy";


        public static string ReplaceBlank()
        {
            int oriLen = m_strOri.Length;
            int i = 0;
            int numBlank = 0;
            while (i < oriLen)
            {
                if (m_strOri[i] == ' ')
                {
                    numBlank++;
                }
                i++;
            }
            int newLen = oriLen + numBlank * 2;
            int idxOri = oriLen-1;
            int idxNew = newLen -1;
            char[] newStr = new char[newLen];
            while (idxOri >= 0)
            {
                if (m_strOri[idxOri] == ' ')
                {
                    newStr[idxNew--] = '0';
                    newStr[idxNew--] = '2';
                    newStr[idxNew--] = '/';
                }
                else
                {
                    newStr[idxNew--] = m_strOri[idxOri];
                }
                idxOri--;
            }
            string strNew = new string(newStr);
            Console.WriteLine(strNew);
            return strNew;
        }

    }
}
