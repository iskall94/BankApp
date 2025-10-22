using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Accounts
{
    internal class Admin : User
    {
        public Admin(Guid userID, string password, string name) : base(userID, password, name)
        {
        }

        public User CreateUser(string password, string name, BankAccount account)
        {
            List<BankAccount> userBankAccount = new List<BankAccount>();
            userBankAccount.Add(account);
            User newUser = new User(Guid.NewGuid(), password, name, userBankAccount);
            return newUser;

        }

        public void FreezeBankAccount()
        {

        }

        public void UpdateExchangeRates()
        {

        }

        

    }
}
