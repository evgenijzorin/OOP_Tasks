using System;
using System.IO;


namespace Z_Services
{
    public class FileExecutor
    {       
        /// <summary>
        /// Копирование файла или директории
        /// </summary>
        /// <param name="path1">Путь копируемого файла</param>
        /// <param name="path2">Путь нового (скопированного файла)</param>
        /// <param name="remove_id">Удалить фаайл источник (т.е. переместить)</param>
        /// <param name="massege">Сообщение о выполнении операции</param>
        /// <returns></returns>
        public virtual bool CopyDirOrFile (string path1, string path2, bool remove_id, out string massege)
        {
            massege = "";
            //Создать идентичную структуру папок
            if (!(Directory.Exists(path2)))
            {
                Directory.CreateDirectory(path2);
                massege = $"Пустая директория скопирована.";
            }
                
            foreach (string dirPath in Directory.GetDirectories(path1, "*", SearchOption.AllDirectories))
            {
                try
                {
                    Directory.CreateDirectory(dirPath.Replace(path1, path2));
                    massege = $"Операция копирования из {path1} в {path2} выполнена успешно.";
                }
                catch (Exception e)
                {                    
                    massege = $"Операция копирования из {path1} в {path2} не выполнена. Проверьте правильность ввода данных и права доступа [{e}]";
                    return false;
                }
            }
            //Копировать все файлы и перезаписать файлы с идентичным именем
            foreach (string newPath in Directory.GetFiles(path1, "*.*",
                SearchOption.AllDirectories))
            {
                try
                {
                    File.Copy(newPath, newPath.Replace(path1, path2), true);
                    massege = $" cp - Операция копирования из {path1} в {path2} выполнена.";                    
                }
                catch (Exception e)
                {                    
                    massege = $"Операция копирования из {path1} в {path2} не выполнена. Проверьте правильность ввода данных и права доступа [{e}]";
                    return false;
                }
            }
            if (remove_id)
            {
                try
                {
                    Directory.Delete(path1, true);
                }
                catch (Exception e)
                {
                    massege = $"Операция перемещения из {path1} в {path2} не выполнена. Проверьте правильность ввода данных и права доступа [{e}]";
                    return false;
                }                
            }
            return true;
        }
        public virtual bool DeleteFileOrDir (string delDirName, out string massege)
        {
            if (Directory.Exists(delDirName)) // проверка существования директории
            {
                try
                {
                    Directory.Delete(delDirName, true);
                    massege = $"{delDirName} - директория удалена";
                    return true;
                }
                catch (Exception e)
                {
                    massege = $"Не удалось удалить директорию: {e}";
                    return false;
                }
            }
            else if (File.Exists(delDirName)) // если введен глобальный путь
            {
                try
                {
                    File.Delete(delDirName);
                    massege = $"rm {delDirName} - файл удалён";
                    return true;
                }
                catch (Exception e)
                {
                    massege = $"Не удалось удалить файл: {e}";
                    return false;
                }
            }
            massege = $"Не найден нужный файл либо директория";
            return false;
        }
        // создать директорию
        public virtual bool MakeDir (string newDirName, out string massege)
        {
            if (!Directory.Exists(newDirName)) // проверка существования директории
            {
                try
                {
                    Directory.CreateDirectory(newDirName);
                    massege = $"{newDirName} - директория создана";
                    return true;
                }
                catch (Exception e)
                {
                    massege = $"Не удалось создать директорию: {e}";
                    return false;
                }
            }
            else
            {
                massege = $"{newDirName} - директория не создана. Директория с таким именем существует";
                return false;
            }
        }
    }
}
