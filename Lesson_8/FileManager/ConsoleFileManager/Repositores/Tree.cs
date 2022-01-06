using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;


namespace ConsoleFileManager.Repositores
{
    public static class Tree
    {
        // Поля
        private static string pathCurrent;
        private static string[] filesArray;
        private static string[] directorysArray;
        private static string nameCurentDirectory;
        private static DateTime creationTime;
        private static DirectoryInfo parentDirectoryInfo;

        // Свойства класса:
        public static string[] FilesArray { get { return filesArray; } }
        /// <summary>
        /// DirectorysArray - Массив папок
        /// </summary>
        public static string[] DirectorysArray { get { return directorysArray; } }
        /// <summary>
        /// NameCurentDirectory - имя рассматриваемой директории
        /// </summary>
        public static string NameCurentDirectory { get {return nameCurentDirectory; } }

        /// <summary>
        /// CreationTime - время и дата создания каталога
        /// </summary>
        public static DateTime CreationTime { get { return creationTime; } }
        /// <summary>
        /// ParentCurentDirectory - сведения о родительской директории
        /// </summary>
        public static DirectoryInfo ParentDirectoryInfo { get { return parentDirectoryInfo; } }
        public static string PathCurrent  
        {
            get { return pathCurrent; }
            set
            { 
                pathCurrent = value;
                // Перевести строку в массив
                string[] userPathArray = pathCurrent.Split('\\'); // массив строк         
                                                                  // При значении пути файла равному корневому каталогу(C:) необходимо добавить косую черту, чтобы сделать путь абсолютным, для корректной работы методов  Directory.GetFiles Directory.GetDirectories
                string userPathText_VR;
                if (userPathArray.Length == 1)
                {
                    userPathText_VR = pathCurrent + "\\";
                }
                else
                    userPathText_VR = pathCurrent;
                // Присваиваем значение основному параметру
                filesArray = Directory.GetFiles(userPathText_VR);            // получить файлы директории
                directorysArray = Directory.GetDirectories(userPathText_VR); // получить каталоги директории                                                                          
                creationTime = Directory.GetCreationTime(userPathText_VR);
                nameCurentDirectory = userPathArray[userPathArray.Length - 1];
                parentDirectoryInfo = Directory.GetParent(userPathText_VR);
            }

        }  

        // Конструктор статического класса
        static Tree()
        {
            pathCurrent = "C:";
            // Перевести строку в массив
            string[] userPathArray = pathCurrent.Split('\\'); // массив строк         
           // При значении пути файла равному корневому каталогу(C:) необходимо добавить косую черту, чтобы сделать путь абсолютным, для корректной работы методов  Directory.GetFiles Directory.GetDirectories
            string userPathText_VR;
            if (userPathArray.Length == 1)
            {
                userPathText_VR = pathCurrent + "\\";
            }
            else
                userPathText_VR = pathCurrent;
           // Присваиваем значение основному параметру
            filesArray = Directory.GetFiles(userPathText_VR);            // получить файлы директории
            directorysArray = Directory.GetDirectories(userPathText_VR); // получить каталоги директории          
            nameCurentDirectory = userPathArray[userPathArray.Length - 1];
            parentDirectoryInfo = Directory.GetParent(userPathText_VR);
        }
    }
}
