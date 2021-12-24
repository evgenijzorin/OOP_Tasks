using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7
   {
   public class BCoder : ICoder
      {      
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
               // Замена символа на аналогичный по нумерации с конца
                  { 
                  ar[i] = alphabetArray[alphabetArray.Length - j -1];    
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
               // Замена символа на аналогичный по нумерации с конца
                  {
                  ar[i] = alphabetArray[alphabetArray.Length - j - 1];
                  break;
                  }
               }
            }
         return new string(ar);
         }
      }
   }
