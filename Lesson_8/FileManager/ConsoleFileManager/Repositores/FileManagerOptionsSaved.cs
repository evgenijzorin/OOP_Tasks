using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFileManager.Repositores
{
    public class FileManagerOptionsSaved
    {
        // Настройки пэйджинга
        public int MaxNumberLinesInPage; // Максимальное количестро строк на странице
        public int NumberLineInPage; // номер первой выводимой строк на странице
        public int NumberPage; // номер первой выводимой строк на странице
        public string LastOperationInfo ;
        public string CurrentPath;
        public FileManagerOptionsSaved()
        {

        }
    }
}
