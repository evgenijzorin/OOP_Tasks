using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
   {
   static class MathHelper
      {
      /// <summary>
      ///  Наибольшее общий делитель
      /// </summary>
      /// <param name="a"></param>
      /// <param name="b"></param>
      /// <returns></returns>
      public static double Nod(double a, double b)
         {
         if (b < 0)
            b = -b;
         if (a < 0)
            a = -a;
         while (b > 0)
            {
            double temp = b;
            b = a % b;
            a = temp;
            }
         return a;
         }
      /// <summary>
      ///  Наибольшее общее кратное
      /// </summary>
      /// <param name="a"></param>
      /// <param name="b"></param>
      /// <returns></returns>
      public static double Nok(double a, double b)
         {
         return Math.Abs(a * b) / Nod(a, b);
         }
      }
   }
