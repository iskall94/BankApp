# Bankapp
Group 3, Project for Chas Academy

---

## Welcome to Chas Bank 3
---
## How To Use the App
---
### Links:
- https://github.com/users/iskall94/projects/1
- https://miro.com/app/board/uXjVJ3ZTTn8=/
---
### All classes in the program:
#### Admin.cs  
- Inherits from User.cs  
- Admin class handles all the functions that an admin would deal with.  
- CreateUser(): Creates a new instance of a User  
- CreateUserwInfo(): Creates a new instance of a User with additional information  
- UnlockBankAccount(): In case a user locked out their account, you can unlock it as admin  
- AdminLogin(): Sets a 8-number code and sends it to Admin-email if matched, successfully login  
- UpdateExchangeRates(): Opens a list of currency values from a dictionary and then updates the selected currency to a new value  
---
#### BankAccount.cs
- Withdraw(): Enables a User to withdraws a certain amount from bank account  
- Deposit(): Enables a User to Deposit a certain amount to bank account  
- AddTransaction(): Adds transaction to a list (TransactionHistory)  
- GetTransactionHistory(): Get a transaction history from a User  
- ChangeAccountCurrency(): Change the currency of a Users account  
- ChangeBankAccountName(): Changes the name of your bank account for Users  
- ApplyInterest(): When a year has passed, apply interest  
---
#### User.cs
- Login(): Logins a User, newly created Users have default password, prompts the user to change it after logging in first time. If user fails enter the right password, lock the User's account  
- ChangePassword(): Changes Users password
- EditUser(): Edits any additional information user has added
- AccountNumbersList(): Returns a list of user account numbers
- FindAccount(): Returns a specific bank account based on account number
- CreateBankAccount(): Creates a bank account for User
- CreateTransaction(): Creates a new transaction and is added to the pending transactions list (for timers)
- CreateLoan(): Creates a loan (from Loan class) for user, with a hardcoded interest rate, loan cannot exceed 5 times the Users balance
- HandleTransfer(): When transferring between same User's accounts, handle the transfer
---
#### CurrencyManager.cs
- ChangeCurrencyValue(): Changes the selected currency value
---
#### AccountNumber.cs
- Generates an 16 number enum
---
#### CurrencyType.cs
- Enum for currencies
---
#### TransactionType.cs
- Enum for transactions (normal or loan)
---
#### AdminMenu.cs
- AdminMenuStart(): Makes an admin menu (from Menu class) from a list
- AdminCreateUser(): A tool for admin to create a new user, entering a User's account name and first time balance (maybe with additional info)
---
#### MainMenu.cs
- MainMenuStart(): Makes a main menu (from Menu class) from a list
- AsciiTitle(): Just prints an string with ascii art
---
#### Menu.cs
- Run(): Runs each menu with DisplayMenu() with Up and Down Arrow keys, for easy use
- DisplayMenu(): Makes each selected menu (index) get highlighted in the console
---
#### UserMenu.cs
- UserMenuStart(): Makes a user menu (from Menu class) from a list
- AskReturnOrContinue(): Helper method to escape from a visual method
- ChooseAccountNumber(): Displays a menu of account numbers and returns a selected account
- GetUserFieldValue(): Shows information of current User
- GetCurrencyMenu(): Shows a menu of currencies, then changes the User's account's currency
- All menus containing visual methods allows the user to input information in order to execute functions
##### List of Visual Methods:
- CheckAccountsVisual()
- DepositVisual()
- TransactionHistoryVisual()
- EditUserVisual()
- HandleTransferVisual()
- TransactionVisual()
- CreateLoanVisual()
- CreateBankAccountVisual()
- ChangeBankAccountVisual()
- ChangeBankAccountNameVisual()
- ChangeCurrencyVisual()
---
#### Loan.cs (Inherits from Transaction)
- CalculateLoan(): Calculates the loan, the user asked for
---
#### Transaction.cs
- ExecutePendingTransaction(): Causes each transaction to go through every 15 minutes
- ExecuteTransaction(): Executes transactions between User accounts, if it is a loan, the admin's account's Balance gets withdrawn. If user sends suspiciously high transaction, send email to admin
---
#### BankAccountDB.cs
- AddBankAccount(): Adds a bank account to a list
- FindBankAccount(): Returns a bank account with from a specific account number
---
#### HelperMethod.cs
- HelperDecimal(): TryParses any decimal from user input
---
### MailService.cs
- GenerateRandomCode(): Returns at least a 6 numbered code
- EnvErrorMessage(): If user have not setup Environment Variables for Email and Password, cause an invalid operation exception
- SendLoginCode(): Initializes SMTP to send an email using the env variables values with the generated login code
- GetLastLoginCode(): Returns the login code to be used later
- SendIssueCodeEmail(): Sends email regarding different issues from bank app actions, from Users
---
#### Program.cs
- Starts the main menu
---
#### Timer.cs
- Start(): Starts the timer
- Tick(): Runs every minute, checks ExecutePendingTransactions()
---
#### UserDB.cs
- FindUserByName(): Returns a User by their name
- FindUserLocked(): Returns a list of locked Users
- ShowAllUsers(): Shows a list of all existing Users
