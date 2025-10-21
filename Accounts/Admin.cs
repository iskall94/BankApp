using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Accounts
{
    internal class Admin : User
    {
        public Admin(Guid userID, string passoword, string name, List<BankAccount> userBankAccount) : base(UserID, Password, name, userBankAccount)
        {
            UserID = userID;
            Password = password;
            Name = name;
            UserBankAccount = userBankAccount;
        }

        public void CreateUser()
        {

        }

        public void FreezeBankAccount()
        {

        }

        public void UpdateExchangeRates()
        {

        }
    }
}
