using ConsoleFileManager.Repositores;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z_Services;

namespace ConsoleFileManager.Services
{
    class ConsoleFileExecutor : FileExecutor
    {
        public override bool CopyDirOrFile(string path1, string path2, bool remove_id, out string massege)
        {
            var result = base.CopyDirOrFile(path1, path2, remove_id, out massege);
            FileManagerOptions.LastOperationInfo = massege;
            return result;
        }
        public override bool DeleteFileOrDir(string delDirName, out string massege)
        {
            // Определение введенного пути пользователем 
            if (Directory.Exists(Tree.PathCurrent + "\\" + delDirName)) // проверка существования директории
            {
                delDirName = Tree.PathCurrent + "\\" + delDirName;
            }
            else if (Directory.Exists(delDirName)) // если введен глобальный путь
            {               
            }
            else if (File.Exists(delDirName)) // если введен глобальный путь
            {
            }
            else if (File.Exists(Tree.PathCurrent + "\\" + delDirName)) // если введен глобальный путь
            {
                delDirName = Tree.PathCurrent + "\\" + delDirName;
            }
            else
            {
                massege = $"rm {delDirName} - директория не удалена. Директория не обнаружена";
                return false;
            }
            var result = base.DeleteFileOrDir(delDirName, out massege);
            FileManagerOptions.LastOperationInfo = massege;
            return result;
        }
        public override bool MakeDir(string newDirName, out string massege)
        {
            var result = base.MakeDir(Tree.PathCurrent + "\\" + newDirName, out massege);
            FileManagerOptions.LastOperationInfo = massege;
            return result;
        }
    }
}
