using Newtonsoft.Json;
namespace BankingApp
{
    public class Bank
    {
        private static double id = 0;
        /// <summary>
        /// Dictionary to store all the bank accounts
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <typeparam name="BankAccount"></typeparam>
        /// <returns></returns>
        private static Dictionary<string, BankAccount> BankAccounts = new Dictionary<string, BankAccount>();

        /// <summary>
        /// List to store all the emails
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <returns></returns>
        private static List<string> EMAILS = new List<string>();

        /// <summary>
        /// Validates the email address
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private static bool validateAccount(string email)
        {
            if(EMAILS.Contains(email))  return false;

            else    EMAILS.Add(email);

            return true;
        }
        /// <summary>
        /// Signs in the user if the username and PIN are correct
        /// </summary>
        /// <param name="username"></param>
        /// <param name="PIN"></param>
        /// <returns></returns>
        public static BankAccount SignIn(string username, string PIN)
        {
            if(BankAccounts.TryGetValue(username, out BankAccount Account))
            {
                 if (Account.getPIN().Equals(PIN))
                 {
                    return Account;
                 }
            }
            return null;
        }


        /// <summary>
        /// Creates a new account
        /// </summary>
        /// <param name="username"></param>
        /// <param name="name"></param>
        /// <param name="PIN"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static string CreateAccount(string username, string name, string PIN, string email, string phone)
        {
            var response = new Object();
            if(!validateAccount(email))
            {
                response = new {
                    status = false,
                    message = "Account Already Exists"
                };
            }
            else
            {
                id =  BankAccounts.LastOrDefault().Value.ID + 1;
                BankAccount account = new BankAccount(id, username, name, PIN, email, phone);
                BankAccounts.Add(username, account);
                string accountDetails = account.ToString();
                response = new {
                    status = true,
                    message = "Account Created Successfully",
                    accountDetails = accountDetails
                };
            }  
            return JsonConvert.SerializeObject(response);
        }

    
        /// <summary>
        /// Saves the accounts to a file
        /// </summary>
        /// <returns></returns>
        public static string saveAccounts()
        {
            var response = new Object();
            try
            {
            
                string AccountsJson = JsonConvert.SerializeObject(BankAccounts, Formatting.Indented);
                string EmailsJson = JsonConvert.SerializeObject(EMAILS, Formatting.Indented);
          
            
                File.WriteAllText("BankAccounts.json", AccountsJson);
                File.WriteAllText("Emails.json", EmailsJson);
                response = new {
                    status = true,
                    message = "Accounts Saved Successfully"
                };
                return JsonConvert.SerializeObject(response);
            }
            catch (Exception e)
            {
                response = new {
                    status = false,
                    message = "Error Saving Accounts"
                };
                return JsonConvert.SerializeObject(response);
            }
        }

        /// <summary>
        /// Retrieves the accounts from the file
        /// </summary>
        /// <returns></returns>
        public static string retrieveAccounts()
        {
            var response = new Object();
            try
            {
                string AccountsJson = File.ReadAllText("BankAccounts.json");
                string EmailsJson = File.ReadAllText("Emails.json");
                BankAccounts = JsonConvert.DeserializeObject<Dictionary<string, BankAccount>>(AccountsJson);
                EMAILS = JsonConvert.DeserializeObject<List<string>>(EmailsJson);
                response = new {
                    status = true,
                    message = "Accounts Retrieved Successfully"
                };
                return JsonConvert.SerializeObject(response);
            }
            catch (Exception e)
            {
                response = new {
                    status = false,
                    message = "Error Retrieving Accounts"
                };
                return JsonConvert.SerializeObject(response);
            }
        }
    
    }
}