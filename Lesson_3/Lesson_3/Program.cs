using System;

namespace Lesson_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание №1. Перевод денег на другой счет.            
            BankAccount bankAccount1 = new BankAccount(1000, AccountType.debit);
            BankAccount bankAccount2 = new BankAccount(0, AccountType.debit);
            BankAccount[] bankAccounts = new BankAccount[] { bankAccount1, bankAccount2 };
            foreach (var item in bankAccounts)
            {
                item.PrintData();
            }
            double sum = 300;
            Console.WriteLine($"Перевод денег {sum} у.е. с текущего счета {bankAccount1.AccountNumber} на другой счет {bankAccount2.AccountNumber}.");
            bankAccount1.SendMoneyToAnotherAccount(bankAccount2, sum);
            foreach (var item in bankAccounts)
            {
                item.PrintData();
            }

        }
    }
}
