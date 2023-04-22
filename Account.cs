using System;
using Newtonsoft.Json;
namespace BankingApp
{
    public class BankAccount
    {
        private double ID;
        private string username;
        private string name;
        private string PIN;
        private string email;
        private string phone;
        private string AccountNumber;
        private double Balance;

        public BankAccount(double ID, string username, string name, string PIN, string email, string phone)
        {
            this.ID = ID;
            this.username = username;
            this.name = name;
            this.PIN = PIN;
            this.email = email;
            this.phone = phone;
            this.AccountNumber = generateAccountNumber();
            this.Balance = 0;
        }
    
        public string Withdraw(double amount)
        {
            var response = new Object();
            if (amount > this.Balance){
                response = new {
                    status = false,
                    message = "Insufficient Funds"
                };
            }
            else if (amount < 500){
                response = new {
                    status = false,
                    message = "Minimum Withdrawal Amount is 500"
                };
            }
            else{
                this.Balance -= amount;
                response = new {
                    status = true,
                    message = "Withdrawal Successful",
                    balance = this.Balance
                };
            }
            return JsonConvert.SerializeObject(response);
        }
        public string Deposit(double amount)
        {
            var response = new Object();
            if (amount < 500)
            {
                response = new {
                    status = false,
                    message = "Minimum Deposit Amount is 500"
                };
            }
            else
            {
                this.Balance += amount;
                response = new {
                    status = true,
                    message = "Deposit Successful",
                    balance = this.Balance
                };
            }
            return JsonConvert.SerializeObject(response);
        }
        private string generateAccountNumber()
        {
            int year = DateTime.Now.Year % 100;
            return $"{ID}{year}{generateRandomNumber()}";
        }
        private double generateRandomNumber()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }
        
        public string getUserName()
        {
            return username;
        }
        public string getPIN()
        {
            return PIN;
        }
        public string getAccountNumber()
        {
            return AccountNumber;
        }
        
        public override string ToString()
        {
            return $"\nAccountNumber: {this.AccountNumber}\nUsername: {this.username}\nName: {this.name}\nEmail: {this.email}\nPhone: {this.phone}\nBalance:{this.Balance}\nPIN: {this.PIN}\n";
        }

    }
}