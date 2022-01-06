using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z_Services.Interfaces;
using System.IO;
using ConsoleFileManager.Services;
using ConsoleFileManager.Repositores;
using Z_Services;

namespace ConsoleFileManager
{
    public class ConsoleInterviewer : IInterviewer
    {
        ConsoleFileExecutor consoleFileExecutor = new ConsoleFileExecutor();

        public void ExecuteUserCommand(string userCommand)
        {
            #region Команды пользователя.
            // cd.. – перейти в папку на уровень выше
            // cd <каталог> – перейти во вложенный каталог, 
            // md – создать директорию
            // cp '<файл который копируем>' '<файл в который копируем>' - копирование файлов
            //      !!Внимание!! Пути файлов должны быть помещены в одинарные ковычки
            // rm <файл, директория которую удаляем> – удалить файл или директорию (рекурсивное удаление –r)
            // info <файл, директория> - получение информации о файле либо директории, находящемся в текущем каталоге
            // > - следующая страница дерева
            // < - Предыдущая страница дерева
            // quit - Завершить работу и выйти
            #endregion
            string massage;
            string[] userCommandArray = userCommand.Split(' ');
            string command = userCommandArray[0];
            switch (command)
            {
                case "cp":
                    #region копировать файл или директорию     
                    // Удалить первый элемент из списка (команду cp)
                    string pathString = "";
                    for (int i = 1; i < userCommandArray.Length; i++)
                    {
                        if (!(i == 1))
                            pathString = pathString + " " + userCommandArray[i];
                        else
                            pathString = userCommandArray[i];
                    }
                    // Определить массив путей 
                    string[] pathArray = pathString.Split('\'');
                    // Удалить из массива пустые строки
                    string path1 = "";
                    string path2 = "";
                    foreach (string str in pathArray)
                    {
                        if (path1 == "")
                        {
                            if (!(str == ""))
                                path1 = str;
                        }
                        else
                        {
                            if (!(str == ""))
                                path2 = str;
                        }
                    }
                    if ((path1 == "") || (path2 == ""))
                    {
                        FileManagerOptions.LastOperationInfo = $"Операция копирования не выполнена. Не удалость определить пути копирования. Проверьте правильность ввода данных";
                        return;
                    }
                    consoleFileExecutor.CopyDirOrFile(path1, path2, false, out massage);
                    break;
                #endregion
                case "rm":
                    #region Удалить файл либо директорию рекурсивно
                    // Определить название удаляемой директории (глобальный путь либо директория в текущем каталоге)
                    string delDirName = "";
                    for (int i = 1; i < userCommandArray.Length; i++)
                    {
                        if (!(i == 1))
                            delDirName = delDirName + " " + userCommandArray[i];
                        else
                            delDirName = userCommandArray[i];
                    }
                    consoleFileExecutor.DeleteFileOrDir(delDirName, out massage);
                    break;
                #endregion
                case "md":
                    #region создать директорию
                    // Определить название создаваемой директории
                    string newDirName = "";
                    for (int i = 1; i < userCommandArray.Length; i++)
                    {
                        if (!(i == 1))
                            newDirName = newDirName + " " + userCommandArray[i];
                        else
                            newDirName = userCommandArray[i];
                    }
                    consoleFileExecutor.MakeDir(newDirName, out massage);
                    break;
                #endregion
                case "cd..":
                    #region Переход по дереву вверх
                    // var parentDirectory = Directory.GetParent(pathCurrent);
                    var parentDirectory = Tree.ParentDirectoryInfo;
                    if (parentDirectory != null)
                    {
                        string pathCurrent = parentDirectory.FullName;
                        // Нужно убрать из родительской директории в конце "//"                               
                        string[] pathCurrentArray_1 = pathCurrent.Split('\\');
                        string pathCurrent_1 = "";
                        for (int i = 0; i < pathCurrentArray_1.Length; i++)
                        {
                            if (i != 0)
                            {
                                if (pathCurrentArray_1[i] != "")
                                    pathCurrent_1 = pathCurrent_1 + "\\" + pathCurrentArray_1[i];
                            }
                            else
                                pathCurrent_1 = pathCurrent_1 + pathCurrentArray_1[i];
                        }
                        Tree.PathCurrent = pathCurrent_1;
                        FileManagerOptions.LastOperationInfo = "cd.. - Переход на уровень вверх выполнен";
                    }
                    else
                    {
                        FileManagerOptions.LastOperationInfo = "cd.. - Переход на уровень вверх не выполнен, отображается корневая директория";
                    }
                    break;
                #endregion
                case "cd":
                    #region Переход в следующую директорию
                    // следующая директория в которую пользователь хочет перейти                     
                    // Удалить первый элемент из массива (команду cp)
                    string nextDirectory = "";
                    for (int i = 1; i < userCommandArray.Length; i++)
                    {
                        if (!(i == 1))
                            nextDirectory = nextDirectory + " " + userCommandArray[i];
                        else
                            nextDirectory = userCommandArray[i];
                    }
                    if (SearchingElementInStringArray(Tree.PathCurrent + "\\" + nextDirectory, Tree.DirectorysArray))
                    {
                        Tree.PathCurrent = Tree.PathCurrent + "\\" + nextDirectory;
                        FileManagerOptions.LastOperationInfo = $"cd {nextDirectory} - Переход в директорию выполнен.";
                    }
                    else
                    {
                        FileManagerOptions.LastOperationInfo = $"cd {nextDirectory} - Переход в директорию НЕ ВЫПОЛНЕН. Директория не найдена!";
                    }
                    //MyGlobals.numberLineInPage = 0; // обнуляем страницу
                    break;
                #endregion
                case ">":
                    #region переход по визуализации вперед
                    FileManagerOptions.NumberPage = FileManagerOptions.NumberPage + 1;
                    break;
                #endregion
                case "<":
                    #region переход по визуализации назад
                    if (FileManagerOptions.NumberPage > 1)
                        FileManagerOptions.NumberPage = FileManagerOptions.NumberPage - 1;
                    else
                        FileManagerOptions.NumberPage = 1;
                    break;
                #endregion
                case "quit":
                    #region Сохранить настройки пользователя
                    FileManagerOptions.SaveFileManagerOptions();
                    break;
                #endregion
                default:
                    break;
            }
        }
        static bool SearchingElementInStringArray(string element, string[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                if (String.Compare(Array[i], element) == 0)
                    return true;
            }
            return false;
        }
    }

}
