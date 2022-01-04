using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleFileManager.Repositores
{
    public static class FileManagerOptions
    {
        // Настройки пэйджинга
        public static int MaxNumberLinesInPage = 40; // Максимальное количестро строк на странице
        public static int NumberLineInPage = 0; // номер первой выводимой строк на странице
        public static int NumberPage = 1; // номер первой выводимой строк на странице
        public static string LastOperationInfo = "нет";
        public static string CurrentPath = "C:";
        public static bool SaveFileManagerOptions()
        {
            try
            {
                FileManagerOptionsSaved fileManagerOptionsSaved = new FileManagerOptionsSaved()
                {
                    CurrentPath = CurrentPath,
                    LastOperationInfo = LastOperationInfo,
                    MaxNumberLinesInPage = MaxNumberLinesInPage,
                    NumberLineInPage = NumberLineInPage,
                    NumberPage = NumberPage
                };
                // Сохранить настройки в json файле
                string json = JsonSerializer.Serialize(fileManagerOptionsSaved);
                File.WriteAllText("fileManagerOptionsSaved.json", json);
                return true;
            }
            catch (Exception e)
            {
                return false;                
            }
        }
        public static bool LoadFileManagerOptions()
        {
            try
            {
                FileManagerOptionsSaved fileManagerOptionsSaved = new FileManagerOptionsSaved();
                // Загрузить json файл

                if (File.Exists("fileManagerOptionsSaved.json"))
                {
                    // извлечение настроек из json файла
                    fileManagerOptionsSaved = JsonSerializer.Deserialize<FileManagerOptionsSaved>("fileManagerOptionsSaved.json");
                    // запись настроек в статический класс
                    MaxNumberLinesInPage = fileManagerOptionsSaved.MaxNumberLinesInPage;
                    NumberLineInPage = fileManagerOptionsSaved.NumberLineInPage;
                    NumberPage = fileManagerOptionsSaved.NumberPage;
                    LastOperationInfo = fileManagerOptionsSaved.LastOperationInfo;
                    CurrentPath = fileManagerOptionsSaved.CurrentPath;
                    return true;
                }
                else
                {
                    SaveFileManagerOptions();
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;                
            }
        }

    }
}
