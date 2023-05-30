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


    public class Validation
    {
        /// <summary>
        /// Validates the email address
        /// </summary>
        /// <returns></returns>
        public static string validateEmail()
        {
            Console.Write("Enter Email: ");
            string email = Console.ReadLine().Trim().ToLower();
            if (email.Contains("@") && email.Contains("."))
            {
                return email;
            }
            else
            {
                Console.WriteLine("Invalid Email");
                return validateEmail();
            }
        }

        
        /// <summary>
        /// Validates the phone number
        /// </summary>
        /// <returns></returns>
        public static string validatePhone()
        {
            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine().Trim();
            if (phone.Length == 11)
            {
                return phone;
            }
            else
            {
                Console.WriteLine("Phone Number must be 11 digits");
                return validatePhone();
            }
        }

        /// <summary>
        /// Validates the PIN
        /// </summary>
        /// <returns></returns>
        public static string validatePIN()
        {
            Console.Write("Enter PIN: ");
            string PIN = Console.ReadLine().Trim();
            if (PIN.Length == 4)
            {
                return PIN;
            }
            else
            {
                Console.WriteLine("PIN must be 4 digits");
                return validatePIN();
            }
        }

        /// <summary>
        /// Validates the name
        /// </summary>
        /// <returns></returns>
        public static string validateName()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine().Trim();
            if (name.Length > 0)
            {
                return name;
            }
            else
            {
                Console.WriteLine("Invalid Name");
                return validateName();
            }
        }

        
        /// <summary>
        /// Validates the username
        /// </summary>
        /// <returns></returns>
        public static string validateUsername()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine().Trim().ToLower();
            if (username.Length > 0)
            {
                return username;
            }
            else
            {
                Console.WriteLine("Invalid Username");
                return validateUsername();
            }
        }
    
        /// <summary>
        /// Validates the amount
        /// </summary>
        /// <returns></returns>
        public static double validateAmount()
        {
            Console.Write("Enter Amount: ");
            try
            {
                double amount = Double.Parse(Console.ReadLine().Trim());
                return amount;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Amount");
                return validateAmount();
            }
        }
    
    }

}