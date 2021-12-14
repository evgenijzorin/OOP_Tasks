using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_3
{
    public class AdressLine
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public AdressLine(string email)
        {            
            Email = email;
        }
    }

    class AdressBook
    {
        private List<AdressLine> _adressLines = new List<AdressLine>();
        public List<AdressLine> AdressLines 
        {
            get { return _adressLines; }
            set
            {
                _adressLines = value;
            } 
        }

        /// <summary>
        /// Добавить адресс из txt
        /// </summary>
        /// <param name="PathTxt"></param>
        public void AddAdressFromTxt(string PathTxt)
        {
            string [] FileText;
            if (File.Exists(PathTxt))
            {
                FileText = File.ReadAllLines(PathTxt);
            }
            else
            {
                return;
            }
            Console.WriteLine("Новые email адреса полученные из файла:");
            // Добавить новые адреса в книгу
            for (int i = 0; i < FileText.Length; i++)           
            {
                string line = FileText[i];
                this.SearchEmail(ref line);
                if (line != null)
                {
                    Console.WriteLine(line);
                    AdressLine adressLine = new AdressLine(line);
                    AdressLines.Add(adressLine);
                }
            }
        }

        /// <summary>
        /// Найти в строке email
        /// </summary>
        /// <param name="s"></param>
        public void SearchEmail (ref string s)
        {
            string[] lineList = s.Split('&');
            for (int i = 0; i < lineList.Length; i++)
            {
                if (Regex.IsMatch(lineList[i], @"\w*@\w*")) // Поиск - выражение содержащие собаку
                {
                    s = lineList[i];
                    return;
                }
                s = null;
            }
            
        }
    }
}
