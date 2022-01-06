using System;
using Interview.Core;

namespace Lesson_7
   {
   class Program
      {
      static void Main(string[] args)
         {
         Logger logger = new ConsoleLogger();
         ACoder aCoder = new ACoder();
            {
            logger.ShowMessage($"Демонстрация работы ACoder: ");
            string str1 = "абвгдеё";
            string str2 = aCoder.Encode(str1);
            string str3 = aCoder.Decode(str2);
            logger.ShowMessage($"Исходная строка: \"{str1}\"\nЗакодированная строка: \"{str2}\"\nДекодированная строка: \"{str3}");
            }

         BCoder bCoder = new BCoder();
            {
            logger.ShowMessage($"\nДемонстрация работы BCoder: ");
            string str1 = "абвгдеё";
            string str2 = bCoder.Encode(str1);
            string str3 = bCoder.Decode(str2);
            logger.ShowMessage($"Исходная строка: \"{str1}\"\nЗакодированная строка: \"{str2}\"\nДекодированная строка: \"{str3}");
            }
         }
      }
   }
