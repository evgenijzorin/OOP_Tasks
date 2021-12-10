using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
   {
   public class RationalNumber
      {
      private int _numerator; // числитель
      private double _denominator; // знаменатель

      public RationalNumber(int numerator, double denominator) 
         {
         _numerator = numerator;
         _denominator = denominator;
         }

      public int Numerator
         {
         get { return _numerator; }
         set { _numerator = value; }
         }
      public double Denominator
         {
         get { return _denominator; }
         set { _denominator = value; }
         }

      // 1.Перегрузка операторов
      // Равенство
      public static bool operator ==(RationalNumber r1, RationalNumber r2)
         {
         //if (r1 == null || r2 == null) return false;
         return (r1.Numerator == r2.Numerator && r2.Denominator == r2.Denominator);
         }
      public static bool operator !=(RationalNumber r1, RationalNumber r2)
         {
         //if (r1 == null || r2 == null) return false;
         return (! (r1.Numerator == r2.Numerator && r1.Denominator == r2.Denominator));
         }
      // Переопределение методов из object. Необходимо для полной одинаковой работы методов.
      public override bool Equals(object obj)
         {
         return base.Equals((RationalNumber)obj);
         }

      public override int GetHashCode()
         {
         return HashCode.Combine(Numerator,Denominator);
         }
      // сравнение 
      public static bool operator <(RationalNumber r1, RationalNumber r2)
         {
         double nok = MathHelper.Nok(r1.Denominator, r2.Denominator);
         int r1_Numerator = (int)(r1.Numerator * (nok / r1.Denominator));
         int r2_Numerator = (int)(r2.Numerator * (nok / r2.Denominator));
         if (r1_Numerator < r2_Numerator) return true;
         else return false;
         }
      public static bool operator >(RationalNumber r1, RationalNumber r2)
         {
         double nok = MathHelper.Nok(r1.Denominator, r2.Denominator);
         int r1_Numerator = (int)(r1.Numerator * (nok / r1.Denominator));
         int r2_Numerator = (int)(r2.Numerator * (nok / r2.Denominator));
         if (r1_Numerator > r2_Numerator) return true;
         else return false;
         }
      public static bool operator <=(RationalNumber r1, RationalNumber r2)
         {
         double nok = MathHelper.Nok(r1.Denominator, r2.Denominator);
         int r1_Numerator = (int)(r1.Numerator * (nok / r1.Denominator));
         int r2_Numerator = (int)(r2.Numerator * (nok / r2.Denominator));
         if (r1_Numerator <= r2_Numerator) return true;
         else return false;
         }
      public static bool operator >=(RationalNumber r1, RationalNumber r2)
         {
         double nok = MathHelper.Nok(r1.Denominator, r2.Denominator);
         int r1_Numerator = (int)(r1.Numerator * (nok / r1.Denominator));
         int r2_Numerator = (int)(r2.Numerator * (nok / r2.Denominator));
         if (r1_Numerator >= r2_Numerator) return true;
         else return false;
         }

      // Сложение
      public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
         {
         //if (r1 == null || r2 == null) return null;
         // Найти наименьшее общее кратное для знаменателя
         double nok = MathHelper.Nok(r1.Denominator, r2.Denominator);
         // Привести 
         int r1_Numerator = (int)(r1.Numerator * (nok / r1.Denominator));
         int r2_Numerator = (int)(r2.Numerator * (nok / r2.Denominator));
         // Новое рациональное число
         RationalNumber r3 = new RationalNumber((r1_Numerator + r2_Numerator), nok);
         // Сократить рациональное число:
         double nod;
         do
            {
            nod = MathHelper.Nod(r3.Denominator, r3.Numerator); // наибольший общий делитель
            r3.Numerator = r3.Numerator / (int)nod;
            r3.Denominator = r3.Denominator / (int)nod;
            } while (nod != 1);         
         return r3;
         }

      // Вычетание
      public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
         {
         //if (r1 == null || r2 == null) return null;
         // Найти наименьшее общее кратное для знаменателя
         double nok = MathHelper.Nok(r1.Denominator, r2.Denominator);
         // Привести 
         int r1_Numerator = (int)(r1.Numerator * (nok / r1.Denominator));
         int r2_Numerator = (int)(r2.Numerator * (nok / r2.Denominator));
         // Новое рациональное число
         RationalNumber r3 = new RationalNumber((r1_Numerator - r2_Numerator), nok);
         // Сократить рациональное число:
         double nod;
         do
            {
            nod = MathHelper.Nod(r3.Denominator, r3.Numerator); // наибольший общий делитель
            r3.Numerator = r3.Numerator / (int)nod;
            r3.Denominator = r3.Denominator / (int)nod;
            } while (nod != 1);
         return r3;
      }
      // Инкремент
      public static RationalNumber operator ++(RationalNumber r1)
         {
         return new RationalNumber((int)(r1.Numerator + r1.Denominator), r1.Denominator);
         }
      public static RationalNumber operator --(RationalNumber r1)
         {         
         return new RationalNumber((int)(r1.Numerator - r1.Denominator), r1.Denominator);
         }

      //Деление
      public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
         {
         return new RationalNumber((int)(r1.Numerator * r2.Denominator), r2.Numerator * r1.Denominator);
         }
      //Умножение
      public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
         {
         return new RationalNumber((int)(r1.Numerator * r2.Numerator), r2.Denominator * r1.Denominator);
         }
      // Операторы преобразования типов
      public static implicit operator double(RationalNumber rn)
         {
         return rn.Numerator;
         }
      public static explicit operator float(RationalNumber rn)
         {
         return (float)rn.Denominator;
         }






      }
   }
