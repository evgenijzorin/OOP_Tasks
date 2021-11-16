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
        private static long _accountNumber = 6000_0000_0000_0000;
        private double _accountBalance;
        public AccountType _accountType;

        // public int AccountNumber { get { return _accountNumber; } set { _accountNumber = value; } }
        public double AccountBalance { get { return _accountBalance; } set { _accountBalance = value; } }

        public AccountType AccountType { get { return _accountType; } set { _accountType = value; } }

        public BankAccount()
        {
            _accountNumber++ ;
        }





    }
}
