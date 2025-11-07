# Bankapp
Group 3, Project for Chas Academy

---

## Welcome to Chas Bank 3

## How To Use the App
---
### All classes in the program:
#### Admin.cs
Inherits from User.cs

Admin class handles all the functions that an admin would deal with.

CreateUser(): Creates a new instance of a User
CreateUserwInfo(): Creates a new instance of a User with additional information
UnlockBankAccount(): In case a user locked out their account, you can unlock it as admin
AdminLogin(): Sets a 8-number code and sends it to Admin-email if matched, successfully login
UpdateExchangeRates(): Opens a list of currency values from a dictionary and then updates the selected currency to a new value
---
#### BankAccount.cs
Withdraw(): Enables a User to withdraws a certain amount from bank account  
Deposit(): Enables a User to Deposit a certain amount to bank account  
AddTransaction(): Adds transaction to a list (TransactionHistory)  
GetTransactionHistory(): Get a transaction history from a User  
ChangeAccountCurrency(): Change the currency of a Users account  
ChangeBankAccountName(): Changes the name of your bank account for Users  
ApplyInterest(): When a year has passed, apply interest  
---
#### User.cs
Login(): Logins a User, newly created Users have default password, prompts the user to change it after logging in first time. If user fails enter the right password, lock the User's account  


CurrencyManager.cs
AccountNumber.cs
CurrencyType.cs
TransactionType.cs
AdminMenu.cs
MainMenu.cs

Menu.cs

UserMenu.cs


Loan.cs
CalculateLoan():

Transaction.cs
ExecutePendingTransactions():
ExecuteTransaction():

BankAccountDB.cs
FindBankAccount():


UserDB.cs
FindUserByName():
FindUserLocked():
ShowAllUsers():

HelperMethod.cs
MailService.cs
Timer.cs
Program.cs
