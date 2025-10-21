using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Accounts
{
    internal class Admin : User
    {
        public Admin(Guid userID, string password, string name, List<BankAccount> userBankAccount) : base(userID, password, name, userBankAccount)
        {
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
