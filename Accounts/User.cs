using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Accounts
{
    internal class User
    {
        public User(Guid userID, string password, string name, List<BankAccount> userBankAccount)
        {
            UserID = Guid.NewGuid();
            Password = password;
            Name = name;
            UserBankAccount = userBankAccount;
        }

        private Guid UserID { get; set; }
        private string Password { get; set; }
        public string Name { get; set; }

        private List<BankAccount> UserBankAccount { get; set; } = new List<BankAccount>();

        public void Login()
        {

        }

        public void Logout()
        {

        }
        
        public void ResetPassword()
        {

        }

        public void GetBalanceForAll()
        {

        }

        public void CreateBankAccount()
        {

        }

        public void EditBankAccount()
        {

        }
    }
}
