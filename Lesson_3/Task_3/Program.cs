using System;
using System.IO;
using System.Text.Json;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Путь файла с адресами электронной почты 
            string path = "email.txt";
            AdressBook adressBook = new AdressBook();
            adressBook.AddAdressFromTxt(path);
            Console.WriteLine();

            // Записать список адресов в файл согласно заданию            
            string json = JsonSerializer.Serialize(adressBook); // Сохранить список в json файле
            File.WriteAllText("adressBook.json", json);
        }
    }
}
