using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Accounts;
using BankApp.Enums;

namespace BankApp
{
   internal class BankAccountDB
    {
        public BankAccountDB(List<BankAccount> bankAccounts)
        {
            BankAccounts = new List<BankAccount>();
        }

        public static List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();



        public static  void AddBankAccount(BankAccount bankAccount)
        {
            BankAccounts.Add(bankAccount);
        }

        public  static BankAccount FindBankAccount(AccountNumber accountNumber)
        {
             BankAccount foundAccount = BankAccounts.Find(a => a.AccountNumber == accountNumber);
            return foundAccount;
        }

        


    }
}
