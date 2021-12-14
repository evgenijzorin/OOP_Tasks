using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.Core;

namespace Lesson_4
   {   
   public class Creator
      {
      // поля
      public static Hashtable tablBuilding = new Hashtable();
      private static Logger logger = new ConsoleLogger();
      // Создание здания и добавление в коллекцию
      public static Building CreateBuilding(float higthOfBuilding, int numFlats, int numFloors, int numOfEntrance)
         {
         Building building = new Building() { HigthOfBuilding = higthOfBuilding, NumFlats = numFlats, NumFloors = numFloors, NumOfEntrance = numOfEntrance };
          try
            {
            tablBuilding.Add(building.NumOfHouse, building);
            }
         catch (Exception)
            {
            logger.ShowMessage("Не удалось довавить в таблицу");
            }
         return building;
         }
      // Создание здания без указания параметров
      public static Building CreateBuilding()
         {
         Building building = new Building() { HigthOfBuilding = 60, NumFlats = 30, NumFloors = 5, NumOfEntrance = 2 };
         try
            {
            tablBuilding.Add(building.NumOfHouse, building);
            }
         catch (Exception)
            {
            logger.ShowMessage("Не удалось довавить в таблицу");
            }
         return building;
         }
      // Просмотр таблицы
      public static void ShowTableBuildings ()
         {
         foreach (DictionaryEntry item in tablBuilding)
            {
            logger.ShowMessage($"Номер дома в таблице: {item.Key}");
            Building building1 = (Building)item.Value;
            building1.PrintBuilding();
            }
         }
      // Удаление записи
      public static bool DelBuildingByHash(int hash)
         {
         if (tablBuilding.Contains(hash))
            {
            try
               {
               tablBuilding.Remove(hash);
               return true;
               }
            catch (Exception)
               {
               logger.ShowMessage("Не удалось удалить из таблицы");               
               }  
            }
         return false;
         }

      private Creator()
         { }
      }
   }
