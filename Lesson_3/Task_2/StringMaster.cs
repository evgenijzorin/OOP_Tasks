using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task_2
{
    public class StringMaster
    {
        public string ReverseStringLine (string str)
        {
            char[] charArray = new char[str.Length];
            for (int i = 0, j = str.Length - 1; i < str.Length; i++, j--)
            {
                charArray[i] = str[j];
            }
            // Преобразовать массив символов в строку
            string str1 = new string(charArray);
            return str1;
        }
    }
}
