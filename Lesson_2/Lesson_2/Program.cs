using System;

namespace Lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.AccountBalance = 300_012.213;           
            bankAccount.AccountType = AccountType.accumulative;




        }
    }
}
