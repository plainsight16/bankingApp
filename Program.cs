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
            sign in - get details from a particular account using password only.
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
            private String AccountNumber { get; }

            private Double Balance{ get; private set };

            public Account(String AccountNumber, String Balance)
            {
                this.AccountNumber = AccountNumber;
                this.Balance = Balance;
            }

            public void Withdraw(Double amount)
            {
                if (amount < this.Balance)
                {
                    this.Balance -= amount;
                }

                else
                {
                    Console.WriteLine("Insuffienct Funds");
                }
            }

            public void Deposit(Double amount)
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

        }

       
        public class Database
        {
            private static String path = "C:\\Users\\user\\Desktop\\accounts.txt";
            public static Dictionary<String, Account> Accounts = new Dictionary<String, Account>();

           
            public static void signIn(String username, String password)
            {
                if(Accounts.TryGetValue(username, out Account account))
                {
                    if(account.getPassword().Equals(password))
                    {
                        return account;
                    }
                    else
                    {
                        //return null
                    }
                }
                else
                {
                    //return null
                }
            }

            public static void createAccount(String username, String password)
            {
                Account account = new Account(username, password);
                Accounts.Add(username, account);
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

