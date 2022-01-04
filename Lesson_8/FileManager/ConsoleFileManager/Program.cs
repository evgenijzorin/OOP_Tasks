using System;
using ConsoleFileManager.Repositores;
using ConsoleFileManager.Services;
using Z_Services;

namespace ConsoleFileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Действие 1.Настройки программы
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.SetWindowSize(180, 55);
            // Загрузить настройки файлового менеджера
            FileManagerOptions.LoadFileManagerOptions();
            ConsoleVisualisator consoleVisualisator = new ConsoleVisualisator();
            Logger logger = new ConsoleLogger();
            ConsoleInterviewer consoleInterviewer = new ConsoleInterviewer();
            #endregion

            #region Действие 2.Основной цикл диалога программы
            while (true)
            {
                // 2.1 Визуализировать файловую структуру, окно свойств
                consoleVisualisator.TreeVisualize(Tree.PathCurrent);
                // 2.2 Запрос у пользователя команды
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
                logger.ShowMessage("Введите команду:");
                string userMassage = logger.GetMessageFromUser();
                // 2.3 Обработка команды пользователя
                consoleInterviewer.ExecuteUserCommand(userMassage);
                // 2.4 Обновить зеркало дерева файлов:
                Tree.PathCurrent = Tree.PathCurrent;
                // 2.4 завершение цикла в случае если пользователь ввел "quit"
                if (userMassage == "quit")
                {
                    FileManagerOptions.SaveFileManagerOptions();
                    break;
                }
            }
            #endregion







        }
    }
}
