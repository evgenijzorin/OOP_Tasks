using System;
using Interview.Core;

namespace Lesson_4
   {
   class Program
      {
      static void Main(string[] args)
         {
         Logger logger = new ConsoleLogger();

         Building building = Creator.CreateBuilding(higthOfBuilding: 60, numFlats: 30, numFloors: 5, numOfEntrance: 2);
         Creator.CreateBuilding(higthOfBuilding: 600, numFlats: 50, numFloors: 40, numOfEntrance: 3);
         Creator.CreateBuilding(higthOfBuilding: 620, numFlats: 53, numFloors: 44, numOfEntrance: 7);
         Creator.ShowTableBuildings();
         // Удалить здание из коллекции 
         Creator.DelBuildingByHash(3);
         logger.ShowMessage($"\nПосле удаления записи 3 из таблицы:");
         Creator.ShowTableBuildings();
         // Проверка работы калькулятора высоты этажа
         var hightFloor = building.Calculate_HightFloor();
         logger.ShowMessage($"Рассчитаная высота этажа: {hightFloor}");
         }
      }
   }
