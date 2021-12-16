using System;
using Interview.Core;

namespace Lesson_5
   {
   class Program
      {
      static void Main(string[] args)
         {
         Logger logger = new ConsoleLogger();
         RationalNumber r1 = new RationalNumber(3, 5);
         RationalNumber r2 = new RationalNumber(4, 7);
         RationalNumber r3 = new RationalNumber(4, 7);
         // Проверка на равенство и Сравнение
            {
            logger.ShowMessage($"Результат проверки равенства: {r1.Numerator}/{r1.Denominator} = {r2.Numerator}/{r2.Denominator} = {r1 == r2}");
            logger.ShowMessage($"Результат проверки равенства: {r3.Numerator}/{r3.Denominator} = {r2.Numerator}/{r2.Denominator} = {r3 == r2}");
            logger.ShowMessage($"Результат проверки equals: {r3.Numerator}/{r3.Denominator} = {r2.Numerator}/{r2.Denominator} = {r3.Equals(r2)}");
            logger.ShowMessage($"Результат проверки equals: {r1.Numerator}/{r1.Denominator} = {r2.Numerator}/{r2.Denominator} = {r1.Equals(r2)}");
            logger.ShowMessage($"Результат проверки <: {r1.Numerator}/{r1.Denominator} < {r2.Numerator}/{r2.Denominator} = {r1 < r2}");
            logger.ShowMessage($"Результат проверки >: {r1.Numerator}/{r1.Denominator} > {r2.Numerator}/{r2.Denominator} = {r1 > r2}");
            logger.ShowMessage($"Результат проверки <=: {r1.Numerator}/{r1.Denominator} <= {r2.Numerator}/{r2.Denominator} = {r1 <= r2}");
            logger.ShowMessage($"Результат проверки >=: {r1.Numerator}/{r1.Denominator} >= {r2.Numerator}/{r2.Denominator} = {r1 >= r2}");
            }            

         // Сложение и вычитание
            {
            RationalNumber rRezult1 = r1 + r2;
            logger.ShowMessage($"результат сложения числа: {r1.Numerator}/{r1.Denominator} + {r2.Numerator}/{r2.Denominator} = {rRezult1.Numerator}/{rRezult1.Denominator}");
            RationalNumber rRezult2 = r1 - r2;
            logger.ShowMessage($"результат вычитания числа: {r1.Numerator}/{r1.Denominator} - {r2.Numerator}/{r2.Denominator} = {rRezult2.Numerator}/{rRezult2.Denominator}");
            }
         // Умножение и деление
            {
            RationalNumber rRezult1 = r1 * r2;
            logger.ShowMessage($"результат умножения числа: {r1.Numerator}/{r1.Denominator} * {r2.Numerator}/{r2.Denominator} = {rRezult1.Numerator}/{rRezult1.Denominator}");
            RationalNumber rRezult2 = r1 / r2;
            logger.ShowMessage($"результат деления числа: {r1.Numerator}/{r1.Denominator} / {r2.Numerator}/{r2.Denominator} = {rRezult2.Numerator}/{rRezult2.Denominator}");
            }

         // Инкремент и декремент
            {
            RationalNumber rRezult1 = r1;
            rRezult1++;
            logger.ShowMessage($"результат инкремента числа: {r1.Numerator}/{r1.Denominator}  = {rRezult1.Numerator}/{rRezult1.Denominator}");
            RationalNumber rRezult2 = r1;
            rRezult2--;
            logger.ShowMessage($"результат декремента числа: {r1.Numerator}/{r1.Denominator}  = {rRezult2.Numerator}/{rRezult2.Denominator}");
            }



         }
      }
   }
