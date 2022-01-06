using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        { // Задание №2. Реализовать метод, который в качестве входного параметра принимает строку string, возвращает строку типа string, буквы в которой идут в обратном порядке. Протестировать метод.
            string str = "строка";
            StringMaster stringMaster = new StringMaster();
            Console.WriteLine($"После разворачивания строки \"{str}\", получен результат \"{stringMaster.ReverseStringLine(str)}\"");






        }
    }
}
