using Newtonsoft.Json;
namespace BankingApp
{
     public class Bank
    {
        private static double id = 0;
        private static Dictionary<string, BankAccount> BankAccounts = new Dictionary<string, BankAccount>();

        private static List<string> EMAILS = new List<string>();

        private static bool validateAccount(string email)
        {
            if(EMAILS.Contains(email))  return false;

            else    EMAILS.Add(email);

            return true;
        }
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
                id++;
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