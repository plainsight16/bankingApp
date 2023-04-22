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

    
    
    }
}