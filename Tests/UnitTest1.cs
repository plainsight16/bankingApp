namespace Tests;

public class UnitTest1
{
    
    [Fact]
    public void Withdraw_InsufficientFunds_ReturnsFalse()
    {
        // Arrange
        var bankAccount = new BankAccount(1, "user1", "John Doe", "1234", "john@example.com", "1234567890");
        bankAccount.Deposit(1000);

        // Act
        string result = bankAccount.Withdraw(1500);

        // Assert
        Assert.Contains("Insufficient Funds", result);
        Assert.Contains("status\": false", result);
    }

    [Fact]
    public void Withdraw_ValidAmount_ReturnsTrue()
    {
        // Arrange
        var bankAccount = new BankAccount(1, "user1", "John Doe", "1234", "john@example.com", "1234567890");
        bankAccount.Deposit(2000);

        // Act
        string result = bankAccount.Withdraw(1500);

        // Assert
        Assert.Contains("Withdrawal Successful", result);
        Assert.Contains("status\": true", result);
    }

    [Fact]
    public void Withdraw_AmountBelowMinimum_ReturnsFalse()
    {
        // Arrange
        var bankAccount = new BankAccount(1, "user1", "John Doe", "1234", "john@example.com", "1234567890");
        bankAccount.Deposit(1000);

        // Act
        string result = bankAccount.Withdraw(200);

        // Assert
        Assert.Contains("Minimum Withdrawal Amount is 500", result);
        Assert.Contains("status\": false", result);
    }

    [Fact]
    public void Deposit_ValidAmount_ReturnsTrue()
    {
        // Arrange
        var bankAccount = new BankAccount(1, "user1", "John Doe", "1234", "john@example.com", "1234567890");

        // Act
        string result = bankAccount.Deposit(1000);

        // Assert
        Assert.Contains("Deposit Successful", result);
        Assert.Contains("status\": true", result);
    }

    [Fact]
    public void Deposit_AmountBelowMinimum_ReturnsFalse()
    {
        // Arrange
        var bankAccount = new BankAccount(1, "user1", "John Doe", "1234", "john@example.com", "1234567890");

        // Act
        string result = bankAccount.Deposit(200);

        // Assert
        Assert.Contains("Minimum Deposit Amount is 500", result);
        Assert.Contains("status\": false", result);
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
        Assert.Contains("PIN: 1234", result);
    }
}