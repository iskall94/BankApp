using BankApp.Accounts;


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

        public static List<User> FindUserLocked()
        {
            var allUsersLocked = allUsers.FindAll(a => a.IsLocked == true);
            var allUsersUnlocked = allUsers.FindAll(a => a.IsLocked == false);
            Console.WriteLine("Current Users that are locked:");
            foreach (User user in allUsersLocked)
            {
                Console.WriteLine(user.Name);
            }
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Current Users that are unlocked:");
            foreach(User user in allUsersUnlocked)
            {
                Console.WriteLine(user.Name);
            }
            Console.WriteLine("-----------------------------------------");
            return allUsersLocked;
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
