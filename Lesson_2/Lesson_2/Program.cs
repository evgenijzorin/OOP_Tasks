using System;

namespace Lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // первый способ 
            BankAccount bankAccount1 = new BankAccount();
            bankAccount1.AccountBalance = 300_012.213;           
            bankAccount1.AccountType = AccountType.accumulative;
            // 2-й способ 
            BankAccount bankAccount2 = new BankAccount(200_000);
            // 3-й способ 
            BankAccount bankAccount3 = new BankAccount(1_000, AccountType.debit);

            BankAccount[] bankAccounts = new BankAccount[]
            {
                bankAccount1,
                bankAccount2,
                bankAccount3
            };

            // Вывод информации:
            foreach (var item in bankAccounts)
            {
                item.PrintData();
            }

            Console.WriteLine();
            Console.WriteLine(" Снять деньги 400 у.е. со счета 2 и пополнить счет 3 на 400 у.е.");

            bankAccount2.WithdrawMoney(400);
            bankAccount3.TopUpAccount(400);

            Console.WriteLine();
            Console.WriteLine(" Полученный результат:");

            // Вывод информации:
            foreach (var item in bankAccounts)
            {
                item.PrintData();
            }
        }
    }
}
