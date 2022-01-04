using ConsoleFileManager.Repositores;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z_Services;
using Z_Services.Interfaces;

namespace ConsoleFileManager
{
    public class ConsoleVisualisator : IVisualisator
    {
        public void FileVisualize(string currentPath)
        {
            throw new NotImplementedException();
        }

        public void TreeVisualize(string currentPath)
        {
            // Перевести строку в массив        
            string[] userPathArray = currentPath.Split('\\'); // массив строк 
            string parseDirectory = userPathArray[0];   // рассматриваемоя директория
            string spaseLine = ""; // маркировка отступов (пробелов)
            // для корневого каталога:
            spaseLine = GetSpaseLine(spaseLine, parseDirectory);
            // Создаем список строк для визуализации дерева
            List<string> listLines = new List<string>();
            // добавляем первую строку в список строк
            listLines.Add(new string(parseDirectory));

            // File.AppendAllText("user_Tree.txt", parseDirectory + Environment.NewLine);
            listLines.AddRange(GetfilesAndDir(currentPath, parseDirectory, 0, spaseLine));

            // Визуализация списка:
            #region Линии оформления и цвета
            string horisontLineSingle = "-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            string horisontLineDouble = "===================================================================================================================================================================================";
            // цвета выделения:
            ConsoleColor currentBackground = Console.BackgroundColor;
            ConsoleColor settingsBackground = ConsoleColor.Red;
            #endregion
            Console.Clear();
            // Вывести первой строчкой полный путь текущей папки
            Console.WriteLine($"текущий каталог: {currentPath}");
            // Вывести горизонтальную черту
            Console.WriteLine(horisontLineSingle);
            // вывести дерево каталогов

            // Подбор страницы для пейджинга
            if (
                (FileManagerOptions.NumberPage < 1)
                ||
                // Условие чтобы все поместилось на странице
                ((1 + listLines.Count / FileManagerOptions.MaxNumberLinesInPage) < FileManagerOptions.NumberPage))
                FileManagerOptions.NumberPage = 1;
            int i;
            for (i = (FileManagerOptions.NumberPage - 1) * FileManagerOptions.MaxNumberLinesInPage;
                i < FileManagerOptions.MaxNumberLinesInPage * FileManagerOptions.NumberPage;
                i++)
            {
                if (i < listLines.Count)
                    Console.WriteLine(listLines[i]);
                else
                    Console.WriteLine();
            }
            FileManagerOptions.NumberLineInPage = i;

            // Оформление области свойств
            Console.WriteLine(horisontLineDouble);// двойной разделитель
            Console.WriteLine();
            //выводится информация:
            Console.WriteLine($"Имя директории: {Tree.NameCurentDirectory} \t Количество папок: {Tree.DirectorysArray.Length} \t Количество файлов: {Tree.FilesArray.Length} \t {Environment.NewLine}Директория создана: {Tree.CreationTime} \t");
            Console.WriteLine();
            Console.WriteLine(horisontLineDouble);
            Console.WriteLine($"Предыдущая операция: {FileManagerOptions.LastOperationInfo}");
            Console.WriteLine(horisontLineDouble);// двойной разделитель
        }

        static List<string> GetfilesAndDir(string userPathText, string parseDirectory, int numberDirectory, string spaseLine)
        {
            // Создаем список строк для визуализации дерева
            List<string> listLines = new List<string>();
            // обработка содержимого корневого каталога:
            string nextDirectory;
            if (userPathText.Split('\\').Length > numberDirectory + 1)
                nextDirectory = userPathText.Split('\\')[numberDirectory + 1];
            else
                nextDirectory = "";
            string[] filesArray = Directory.GetFiles(parseDirectory + "\\");            // получить файлы директории
            string[] directorys = Directory.GetDirectories(parseDirectory + "\\"); // получить каталоги директории            
            // Соединить два массива
            string[] filesAndDir = new string[directorys.Length + filesArray.Length];
            directorys.CopyTo(filesAndDir, 0);
            filesArray.CopyTo(filesAndDir, directorys.Length);
            // записать имена файлов в список
            for (int i1 = 0; i1 < filesAndDir.Length; i1++)
            {
                string LinePath = filesAndDir[i1];
                string[] fileDirName = LinePath.Split('\\');
                string name = fileDirName[fileDirName.Length - 1]; // текущий файл или каталог
                if (name == nextDirectory)
                {// Перегрузка
                    // добавляем новую строку в список строк
                    listLines.Add(new string(spaseLine + name));
                    // File.AppendAllText("user_Tree.txt", spaseLine + name + Environment.NewLine);
                    listLines.AddRange(GetfilesAndDir(userPathText, LinePath, numberDirectory + 1, GetSpaseLine(spaseLine, name)));
                }
                else
                {
                    // добавляем новую строку в список строк
                    listLines.Add(new string(spaseLine + name)); // + Environment.NewLine -убрал
                }
            }
            // В случае если папка конечная и пустая    
            if (filesAndDir.Length == 0)
            {
                listLines.Add(new string(spaseLine + "****** Папка не содержит доступных пользователю файлов и папок"));
            }
            return listLines;
        }

        // Метод получение строки тире, для визуализации строки дерева
        static string GetSpaseLine(string spaseLine, string line)
        {
            string lineSpase = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (i == line.Length - 1)
                    lineSpase = lineSpase + "|";
                else
                    lineSpase = lineSpase + "-";
            }
            return spaseLine + lineSpase;
        }

    }

}
