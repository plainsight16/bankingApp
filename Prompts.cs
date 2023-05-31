// Purpose: Contains the prompts for the user to interact with the banking app
using Newtonsoft.Json.Linq;
namespace BankingApp
{
    public class Prompts
    {

        static BankAccount account = null;

        /// <summary>
        /// Prompts the user to retrieve the accounts
        /// </summary>
        public static void retrieveAccountsPrompt()
        {
            JObject retrieveAccounts = JObject.Parse(Bank.retrieveAccounts());
            Console.WriteLine(retrieveAccounts["message"]);
        }
        
        /// <summary>
        /// Main menu for the banking app
        /// </summary>
        public static void menu()
        {   
            Console.WriteLine();
            Console.WriteLine("Main Menu");
            Console.WriteLine("Select an Option");
            Console.WriteLine("1. Sign In");
            Console.WriteLine("2. Create Account");
            Console.WriteLine("3. Exit");
            Console.Write("Enter Option: ");
            string response = Console.ReadLine().Trim();

            if(MainMenuOptions.TryGetValue(response, out Action action))
            {
                action();
                if (!response.Equals("3")) menu();
            }
            else
            {
                Console.WriteLine("Incorrect Response. Try Again");
                menu();
            }
        }  
        
        /// <summary>
        /// Sub menu for the banking app
        /// </summary>
        public static void subMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Sub Menu");
            Console.WriteLine("Select an Option");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. View Account");
            Console.WriteLine("4. Sign Out");
            Console.Write("Enter Option: ");
            string response = Console.ReadLine().Trim();

            if (SubMenuOptions.TryGetValue(response, out Action action))
            {
                action();
                if (!response.Equals("4")) subMenu();
            }
            else
            {
                Console.WriteLine("Incorrect Response. Try Again");
                subMenu();
            }
        }

        /// <summary>
        /// Prompts the user to sign in
        /// </summary>
        public static void SignInPrompt()
        {
            string username = Validation.validateUsername();
            string PIN = Validation.validatePIN();
            account = Bank.SignIn(username, PIN);
            if (account == null)
            {
                Console.WriteLine("Invalid Username or password");
            }
            else
            {
                Console.WriteLine("Signed in Successfully");
                Console.WriteLine($"Welcome {account.getUserName()}");
                subMenu();
            }
        }
      
        /// <summary>
        /// Prompts the user to deposit
        /// </summary>
        public static void DepositPrompt()
        {
            double amount = Validation.validateAmount();
            JObject response = JObject.Parse(account.Deposit(amount));
            if (!(bool)response["status"])
            {
                Console.WriteLine(response["message"]);
            }
            else
            {
                Console.WriteLine(response["message"]);
                Console.WriteLine($"New Balance: {response["balance"]}");
            }   
        }

        /// <summary>
        /// Prompts the user to withdraw
        /// </summary>
        public static void WithdrawPrompt()
        {
            double amount = Validation.validateAmount();
            JObject response = JObject.Parse(account.Withdraw(amount));
            if (!(bool)response["status"])
            {
                Console.WriteLine(response["message"]);
            }
            else
            {
                Console.WriteLine(response["message"]);
                Console.WriteLine($"New Balance: {response["balance"]}");
            };
        }
        
        /// <summary>
        /// Prompts the user to view the account
        /// </summary>
        public static void ViewAccountPrompt()
        {
            Console.WriteLine($"{account.ToString()}");
        }
        
        /// <summary>
        /// Prompts the user to create an account
        /// </summary>
        public static void CreateAccountPrompt()
        {
            string username = Validation.validateUsername();
            string email = Validation.validateEmail();
            string phone = Validation.validatePhone();
            string name = Validation.validateName();
            string PIN = Validation.validatePIN();
            JObject response = JObject.Parse(Bank.CreateAccount(username, name, PIN, email, phone));
            if((bool)response["status"])
            {
                Console.WriteLine(response["message"]);
                Console.WriteLine($"Account Details: {response["accountDetails"].ToString() }");
            }
            else
            {
                Console.WriteLine(response["message"]);
            }
        }

        /// <summary>
        /// Prompts the user to exit
        /// </summary>
        public static void exitPrompt()
        {
            Console.WriteLine("Exiting...");
        }

        /// <summary>
        /// Prompts the user to sign out
        /// </summary>
        public static void signOutPrompt()
        {
            Console.WriteLine("Signing Out...");
            account = null;
        }
        
        /// <summary>
        /// Prompts the user to save the accounts
        /// </summary>
        public static void saveAccountsPrompt()
        {
            JObject message = JObject.Parse(Bank.saveAccounts());
            Console.WriteLine(message["message"]);
        }
        /// <summary>
        /// Dictionary containing the main menu options
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <typeparam name="Action"></typeparam>
        /// <returns></returns>
        public static Dictionary<string, Action> MainMenuOptions = new Dictionary<string, Action>()
        {
            {"1", SignInPrompt},
            {"2", CreateAccountPrompt},
            {"3", exitPrompt}
        };
    
        /// <summary>
        /// Dictionary containing the sub menu options
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <typeparam name="Action"></typeparam>
        /// <returns></returns>
        public static Dictionary<string, Action> SubMenuOptions = new Dictionary<string, Action>()
        {
            {"1", DepositPrompt},
            {"2", WithdrawPrompt},
            {"3", ViewAccountPrompt},
            {"4", signOutPrompt}
        };
    }


   
}