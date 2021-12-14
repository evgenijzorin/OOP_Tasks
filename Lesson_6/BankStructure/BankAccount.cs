using System;
using Interview.Core;

namespace BankStructure
   {
   public enum AccountType
      {
      credit,
      debit,
      accumulative
      }

   public class BankAccount
      {
      private Logger logger = new ConsoleLogger();
      private static long _accountCountNumber = 6000_0000_0000_0000;
      private long _accountNumber = 6000_0000_0000_0000;
      private double _accountBalance;
      public AccountType _accountType;

      public long AccountNumber { get { return _accountNumber; } }
      public double AccountBalance { get { return _accountBalance; } set { _accountBalance = value; } }
      public AccountType AccountType { get { return _accountType; } set { _accountType = value; } }

      /// <summary>
      /// Конструктор по умолчанию
      /// </summary>
      public BankAccount() : this(0, AccountType.debit)
         {
         }

      /// <summary>
      /// Конструктор с заполнением поля баланс
      /// </summary>
      /// <param name="accountBalance"></param>
      public BankAccount(double accountBalance) : this(accountBalance, AccountType.debit)
         {
         }

      /// <summary>
      /// Основной конструктор
      /// </summary>
      /// <param name="accountBalance"></param> 
      /// <param name="accountType"></param>
      public BankAccount(double accountBalance, AccountType accountType)
         {
         _accountCountNumber++;
         _accountNumber = _accountCountNumber;
         _accountBalance = accountBalance;
         _accountType = accountType;
         }


      /// <summary>
      /// Пополнить счет
      /// </summary>
      /// <param name="TopUpSumm"></param>
      /// <returns></returns>
      public bool TopUpAccount(double TopUpSumm)
         {
         this._accountBalance = _accountBalance + TopUpSumm;
         return true;
         }

      /// <summary>
      /// Снять деньги со счета
      /// </summary>
      /// <param name="WithdrawSumm"></param>
      /// <returns></returns>
      public bool WithdrawMoney(double WithdrawSumm)
         {
         if (this.AccountBalance >= WithdrawSumm)
            {
            this._accountBalance = _accountBalance - WithdrawSumm;
            return true;
            }
         else
            return false;
         }

      /// <summary>
      /// Перевод денег на другой счет
      /// </summary>
      /// <param name="toBankAccount"></param>
      /// <param name="summ"></param>
      /// <returns></returns>
      public bool SendMoneyToAnotherAccount(BankAccount toBankAccount, double summ)
         {
         if (toBankAccount.AccountBalance <= this._accountBalance)
            {
            this._accountBalance = this._accountBalance - summ;
            toBankAccount.AccountBalance = toBankAccount.AccountBalance + summ;
            logger.ShowMessage($"Перевод успешно выполнен. Ваш баланс {this._accountBalance}");
            return true;
            }
         else
            {
            logger.ShowMessage($"Недостаточная сумма на счете.Ваш баланс {this._accountBalance}");
            return false;
            }
         }

      public void PrintData()
         {
         logger.ShowMessage($"Номер счета: {AccountNumber} \t Тип счета: {AccountType} \t Баланс счета: {AccountBalance} у.е.");
         }
      // Перегрузка бинарных операторов
      // == !=
      public static bool operator ==(BankAccount ac1, BankAccount ac2)
         {
         if (ac1 is null && ac2 is null) return true;
         if (ac1 is null || ac2 is null) return false;
         if (
            // (ac1.AccountNumber == ac2.AccountNumber) &&
            (ac1.AccountBalance == ac2.AccountBalance) &&
            (ac1.AccountType == ac2.AccountType))
            return true;
         else return false;
         }
      public static bool operator !=(BankAccount ac1, BankAccount ac2)
         {
         if (ac1 is null && ac2 is null) return false;
         if (ac1 is null || ac2 is null) return true;
         if (
            // (ac1.AccountNumber != ac2.AccountNumber) ||
            (ac1.AccountBalance != ac2.AccountBalance) ||
            (ac1.AccountType != ac2.AccountType))
            return true;
         else return false;
         }
      public bool Equals(BankAccount ac2)
         {
         if (this is null && ac2 is null) return false;
         if (this is null || ac2 is null) return true;
         if (
            // (this.AccountNumber == ac2.AccountNumber) ||
            (this.AccountBalance == ac2.AccountBalance) ||
            (this.AccountType == ac2.AccountType))
            return true;
         else return false;
         }
      public override int GetHashCode()
         {
         return HashCode.Combine(this.AccountNumber, this.AccountBalance, this.AccountType);
         }
      public override string ToString()
         {
         return $"Номер счета: {this.AccountNumber} \t Тип счета: {this.AccountType} \t Баланс счета: {this.AccountBalance} у.е.";
         }
      }
   }