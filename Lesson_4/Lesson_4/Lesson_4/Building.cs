using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.Core;

namespace Lesson_4
   {
   public class Building
      {
      // 1.Поля
      private int numOfHouse; // номер дома
      private static int numOfHouseIncrement = 0;
      private float higthOfBuilding; // высота
      private int numFloors; // этажность
      private int numFlats; // кол-во квартир       
      private int numOfEntrance; // кол-во подъездов
      Logger logger = new ConsoleLogger();
      

      // 2.Свойства
      public int NumOfHouse
         {
         get { return numOfHouse; }
         }
      public float HigthOfBuilding
         {
         get { return higthOfBuilding; }
         set { higthOfBuilding = value; }
         }
      public int NumFloors
         {
         get { return numFloors; }
         set { numFloors = value; }           
         }
      public int NumFlats
         {
         get { return numFlats; }
         set { numFlats = value; }
         }
      public int NumOfEntrance
         {
         get { return numOfEntrance; }
         set { numOfEntrance = value; }
         }

      // 3.Методы
      public float Calculate_HightFloor()
         {
         if (numFloors != 0)
            {
            return higthOfBuilding / numFloors;
            }
         else return 0;
         }
      public float Calculate_NumOfflatsInEntrance()
         {
         if (numOfEntrance != 0)
            {
            return numFlats / numOfEntrance;
            }
         else return 0;
         }
      public float Calculate_NumOfflatsInFloor()
         {
         if (numOfEntrance != 0 && numFloors != 0)
            {
            return numFlats / numOfEntrance / numFloors;
            }
         else return 0;
         }
      public void PrintBuilding()
         {
         logger.ShowMessage($"Номер дома: {numOfHouse} \n Высота дома: {higthOfBuilding} \n Колличество этажей {numFloors} \n Колличество квартир {numFlats} \n Колличество подъездов {numOfEntrance} ");
         }
               
      // 4.Конструкторы.      
      internal Building()
         {
         numOfHouseIncrement++;
         numOfHouse = numOfHouseIncrement;
         }  
      }
   }
