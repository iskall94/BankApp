using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Accounts;
using BankApp.Enums;

namespace BankApp
{
    internal class UserDB
    {

        public UserDB(List<User> allUsers)
        {
            allUsers = new List<User>();
        }

        public static List<User> allUsers { get; set; } = new List<User>();



        public static void AddUser(User newUser)
        {
            allUsers.Add(newUser);
        }

        public static User FindUserByName(string nameQuery)
        {
            User foundUser = allUsers.Find(a => a.Name == nameQuery);
            return foundUser;
        }



        public static void ShowAllUsers()
        {
            Console.Clear();

            allUsers.ForEach(user =>
            {
                Console.WriteLine("\n--------------------------------------------------------");
                Console.WriteLine(user.ToString());
                
                
            });
            Console.ReadKey();
        }
    }
}
