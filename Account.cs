using System;
using Newtonsoft.Json;
namespace BankingApp
{
    public class BankAccount
    {
        public double ID {get; private set;}
        public string username {get; private set;}
        public string name {get; private set;}
        public string PIN {get; private set;}
        public string email {get; private set;}
        public string phone {get; private set;}
        public string AccountNumber {get; private set;}
        public double Balance {get; private set;}

        /// <summary>
        /// Constructor for the BankAccount class
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="username"></param>
        /// <param name="name"></param>
        /// <param name="PIN"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
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

        /// <summary>
        /// Withdraws the specified amount from the account
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Deposits the specified amount into the account
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Generates a random account number for the account
        /// </summary>
        /// <returns></returns>
        private string generateAccountNumber()
        {
            int year = DateTime.Now.Year % 100;
            return $"{ID}{year}{generateRandomNumber()}";
        }
        /// <summary>
        /// Generates a random 4 digit number
        /// </summary>
        /// <returns></returns>
        private double generateRandomNumber()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }
        /// <summary>
        /// Returns the username of the account
        /// </summary>
        /// <returns></returns>
        public string getUserName()
        {
            return username;
        }
        /// <summary>
        /// returns the pin of the account
        /// </summary>
        /// <returns></returns>
        public string getPIN()
        {
            return PIN;
        }
        /// <summary>
        /// returns the account number of the account
        /// </summary>
        /// <returns></returns>
        public string getAccountNumber()
        {
            return AccountNumber;
        }
        
        /// <summary>
        /// Returns the string representation of the account
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"\nAccountNumber: {this.AccountNumber}\nUsername: {this.username}\nName: {this.name}\nEmail: {this.email}\nPhone: {this.phone}\nBalance:{this.Balance}\nPIN: {this.PIN}\n";
        }

    }
}