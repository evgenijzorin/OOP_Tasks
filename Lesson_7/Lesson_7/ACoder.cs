using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7
   {
   class ACoder : ICoder
      {
      // public Dictionary<int,char> charsRusDictionary;
      char[] alphabetArray = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToCharArray();
      // Закодировать
      public string Encode(string lineEncode)
         {
         char[] ar = lineEncode.ToCharArray();
         for (int i = 0; i < ar.Length; i++)
            {
            for (int j = 0; j < alphabetArray.Length; j++)
               {
               if (alphabetArray[j] == ar[i])
               // сдвиг символа:
                  {
                  if (j != 0)
                     ar[i] = alphabetArray[j - 1];
                  else ar[i] = alphabetArray[alphabetArray.Length - 1];
                  break;
                  }
               }
            }
         return new string(ar);
         }

      public string Decode(string lineDecode)
         {
         char[] ar = lineDecode.ToCharArray();
         for (int i = 0; i < ar.Length; i++)
            {
            for (int j = 0; j < alphabetArray.Length; j++)
               {
               if (alphabetArray[j] == ar[i])
               // сдвиг символа:
                  {
                  if (j != alphabetArray.Length - 1)
                     ar[i] = alphabetArray[j + 1];
                  else ar[i] = alphabetArray[0];
                  break;
                  }
               }
            }
         return new string(ar);
         }
      }
   }
