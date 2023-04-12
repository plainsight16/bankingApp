using System;
using System.IO;

namespace BankingApp
{
    public class Program
    {

        /*  
            deposit - update textfile() 
            withdrawal - update textfile amount()
            check amount - retrieve from text file()
            create_account - add to text file
            sign in - get details from a particular account using Account Number only.
        */

        /*
            notes:
                1. Functions handling database and its operations should be in a different class?
                2. Account class should have no states, only feeding the database class
                and retreiving from it
                3. An Account class constructor should call a database class to create an account
        */

        public static void Main(String []args)
        {
            menu();
        }


        private static void menu()
        {   
            Console.WriteLine("Select an Option");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Sign In");
            Console.WriteLine("3. Exit");
            string response = Console.ReadLine().Trim();
            switch(response)
            {
                case "1": 
                    //sign in
                    break;
                case "2":
                    //newAccount
                    break;
                case "3":
                    Console.WriteLine("Exiting...")
                    break;
                default:
                    Console.WriteLine("Incorrect Response. Try Again");
                    menu();
                    break;
            }
            
        }

        public class Account
        {

            private string AccountNumber { get; }

            private string Owner {get; set;}

            private double Balance{ get; private set };

            private static int NumberCounter = 0;

            private static year = DateTime.Now.Year % 100;

            public Account(string AccountNumber, string Owner, string Balance)
            {
                this.AccountNumber = AccountNumber;
                this.Owner = Owner;
                this.Balance = Balance;
            }

            public void Withdraw(double amount)
            {
                if (amount <= this.Balance)
                {
                    this.Balance -= amount;
                }

                else
                {
                    Console.WriteLine("Insuffienct Funds");
                }
            }

            public void Deposit(double amount)
            {
                if (amount > 0)
                {
                    this.Balance += amount;
                }

                else
                {
                    Console.WriteLine("Invalid Amount");
                }
            }

            public static string GenerateAccountNumber(string Owner)
            {
                formattedOwner = Owner.Trim().ToLower();
                return $"ACC0{year}0{formattedOwner}";
            }

            public override string ToString()
            {
                return $"AccountNumber: {this.AccountNumber}\nOwner:{this.Owner}\nBalance:{this.Balance}\n"
            }

        }

       
        public class Bank
        {
            private static string Path = "C:\\Users\\user\\Desktop\\accounts.txt";
            public static Dictionary<string, Account> BankAccounts = new Dictionary<String, Account>();

           
            public static Account SignIn(string AccountNumber)
            {
                if(Accounts.TryGetValue(AccountNumber, out Account Account))
                {
                   return account;
                }
                else
                {
                    return null;
                }
            }

            public static void CreateAccount(string Owner)
            {
                string AccountNumber = Account.GenerateAccountNumber(Owner);

                Account account = new Account(AccountNumber, Owner);

                if(Accounts.TryGetValue(AccountNumber, out Account Account))
                {
                   Console.WriteLine("Account Already Exists");
                }
                else
                {
                    Accounts.Add(AccountNumber, account);
                }  
            }

            public static void updateTextFile()
            {
                //update text file
            }

            public static void updateDictionary()
            {
                //update dictionary
            }

    
            public static void retrieveFromTextFile()
            {
                //retrieve from text file
            }

            public static void retrieveFromDictionary()
            {
                //retrieve from dictionary
            }

        }
    }
}

