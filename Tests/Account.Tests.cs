using Newtonsoft.Json.Linq;
namespace Tests;

public class AccountTests
{
     [Fact]
    public void Withdraw_InsufficientFunds_ReturnsFalse()
    {
        // Arrange
        var bankAccount = new BankAccount(1, "user1", "John Doe", "1234", "john@example.com", "1234567890");
        bankAccount.Deposit(1000);

        // Act
        JObject result = JObject.Parse(bankAccount.Withdraw(1500));

        // Assert
        Assert.Equal("Insufficient Funds", result["message"]);
        Assert.True(!(bool)result["status"]);
    }

    [Fact]
    public void Withdraw_ValidAmount_ReturnsTrue()
    {
        // Arrange
        var bankAccount = new BankAccount(1, "user1", "John Doe", "1234", "john@example.com", "1234567890");
        bankAccount.Deposit(2000);

        // Act
        JObject result = JObject.Parse(bankAccount.Withdraw(1500));

        // Assert
        Assert.Equal("Withdrawal Successful", result["message"]);
        Assert.True((bool)result["status"]);
    }

    [Fact]
    public void Withdraw_AmountBelowMinimum_ReturnsFalse()
    {
        // Arrange
        var bankAccount = new BankAccount(1, "user1", "John Doe", "1234", "john@example.com", "1234567890");
        bankAccount.Deposit(1000);
         // Act
        JObject result = JObject.Parse(bankAccount.Withdraw(400));

        // Assert
        Assert.Equal("Minimum Withdrawal Amount is 500", result["message"]);
        Assert.True(!(bool)result["status"]);
    }

    [Fact]
    public void Deposit_ValidAmount_ReturnsTrue()
    {
        // Arrange
        var bankAccount = new BankAccount(1, "user1", "John Doe", "1234", "john@example.com", "1234567890");

        // Act
        JObject result = JObject.Parse(bankAccount.Deposit(1000));

        // Assert
        Assert.Equal("Deposit Successful", result["message"]);
        Assert.True((bool)result["status"]);
    }

    [Fact]
    public void Deposit_AmountBelowMinimum_ReturnsFalse()
    {
        // Arrange
        var bankAccount = new BankAccount(1, "user1", "John Doe", "1234", "john@example.com", "1234567890");

        // Act
        JObject result = JObject.Parse(bankAccount.Deposit(200));

        // Assert
        Assert.Equal("Minimum Deposit Amount is 500", result["message"]);
        Assert.True(!(bool)result["status"]);
    }

    [Fact]
    public void ToString_ReturnsFormattedString()
    {
        // Arrange
        var bankAccount = new BankAccount(1, "user1", "John Doe", "1234", "john@example.com", "1234567890");
        bankAccount.Deposit(1000);

        // Act
        string result = bankAccount.ToString();

        // Assert
        Assert.Contains("AccountNumber: ", result);
        Assert.Contains("Username: user1", result);
        Assert.Contains("Name: John Doe", result);
        Assert.Contains("Email: john@example.com", result);
        Assert.Contains("Phone: 1234567890", result);
        Assert.Contains("Balance: 1000", result);
    }
}