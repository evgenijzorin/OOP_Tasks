using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2
{
    public enum AccountType
    {
        credit,
        debit,
        accumulative
    }

    public class BankAccount
    {
        private static long _accountCountNumber = 6000_0000_0000_0000;
        private long _accountNumber = 6000_0000_0000_0000;
        private double _accountBalance;
        public AccountType _accountType;

        public long AccountNumber { get { return _accountNumber; }  }
        public double AccountBalance { get { return _accountBalance; } set { _accountBalance = value; } }
        public AccountType AccountType { get { return _accountType; } set { _accountType = value; } }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public BankAccount() : this(0 , AccountType.debit)
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
        public bool TopUpAccount (double TopUpSumm)
        {
            this._accountBalance = _accountBalance + TopUpSumm;
            return true;
        }

        /// <summary>
        /// Снять деньги со счета
        /// </summary>
        /// <param name="WithdrawSumm"></param>
        /// <returns></returns>
        public bool  WithdrawMoney (double WithdrawSumm)
        {
            if (this.AccountBalance >= WithdrawSumm)
            {
                this._accountBalance = _accountBalance - WithdrawSumm;
                return true;
            }
            else
                return false; 
        }

        public void PrintData()
        {
            Console.WriteLine($"Номер счета: {AccountNumber} \t Тип счета: {AccountType} \t Баланс счета: {AccountBalance} у.е.");
        }
    }
}
