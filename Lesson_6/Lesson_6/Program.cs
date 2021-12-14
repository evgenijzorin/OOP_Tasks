using System;
using Interview.Core;
using BankStructure;

namespace Lesson_6
   {
   class Program
      {
      static void Main(string[] args)
         {
         Logger logger = new ConsoleLogger();
         // Задание №1. Перевод денег на другой счет.            
         BankAccount bankAccount1 = new BankAccount(1000, AccountType.credit);
         BankAccount bankAccount2 = new BankAccount(1200, AccountType.debit);
         BankAccount bankAccount3 = new BankAccount(1000, AccountType.credit);         
         BankAccount[] bankAccounts = new BankAccount[] { bankAccount1, bankAccount2, bankAccount3 };
         logger.ShowMessage("Создано 3 банковских счета: ");
         foreach (var item in bankAccounts)
            {
            item.PrintData();
            }
         logger.ShowMessage("Проверка бинарных операторов: ");
         logger.ShowMessage($"(==) счет {bankAccount1.AccountNumber} = {bankAccount2.AccountNumber} = {bankAccount1 == bankAccount2}");
         logger.ShowMessage($"(!=) счет {bankAccount1.AccountNumber} != {bankAccount2.AccountNumber} = {bankAccount1 != bankAccount2}");
         logger.ShowMessage($"(==) счет {bankAccount1.AccountNumber} = {bankAccount3.AccountNumber} = {bankAccount1 == bankAccount3}");
         logger.ShowMessage($"(Equals) счет {bankAccount1.AccountNumber} Equals {bankAccount3.AccountNumber} = {bankAccount1.Equals(bankAccount3)}");
         logger.ShowMessage($"(GetHashCode) счет {bankAccount1.AccountNumber} GetHashCode  = {bankAccount1.GetHashCode()}");
         logger.ShowMessage($"(ToString) счет {bankAccount1.AccountNumber} ToString  = {bankAccount1.ToString()}");


         }
      }
   }
