using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
   {
   class Building
      {
      private int numFloor;
      private int numFlats;
      private string street;
      private int numOfHouse;
      private int numOfEntrance;
      private float higthOfBuilding;

      public int NumFloor
         {
         get { return numFloor; }
         set { numFloor = value; }           
         }
      public int NumFlats
         {
         get { return numFlats; }
         set { numFlats = value; }
         }
      public string Street
         {
         get { return street; }
         set { street = value; }
         }
      public int NumOfHouse
         {
         get { return numOfHouse; }
         set { numOfHouse = value; }
         }
      public int NumOfEntrance
         {
         get { return numOfEntrance; }
         set { numOfEntrance = value; }
         }
      public float HigthOfBuilding
         {
         get { return higthOfBuilding; }
         set { higthOfBuilding = value; }
         }

      public Building()
         {
         }
      }
   }
