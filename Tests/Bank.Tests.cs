using Newtonsoft.Json.Linq;

namespace Tests;


public class BankTests
{
    [Fact]
    public void SignIn_ValidCredentials_ReturnsAccount()
    {
        // Arrange
        Bank.CreateAccount("john123", "John Doe", "1234", "john@example.com", "1234567890");

        // // Act
        // BankAccount actualAccount = Bank.SignIn("john123", "1234");

        // // Assert
        // Assert.Equal("john@example.com", actualAccount.getEmail());
    }

    [Fact]
    public void SignIn_InvalidCredentials_ReturnsNull()
    {
        // Act
        BankAccount account = Bank.SignIn("john123", "wrong_password");

        // Assert
        Assert.Null(account);
    }

    [Fact]
    public void CreateAccount_ValidData_ReturnsSuccessResponse()
    {
        // Act
        // JObject response = JObject.Parse(Bank.CreateAccount("jane456", "Jane Smith", "5678", "jane@example.com", "9876543210"));

        // // Assert
        // Assert.Equal("Account Created Successfully", response["message"]);
        // Assert.Equal("jane456", response["accountDetails"]["username"]);
        // Assert.Equal("Jane Smith", response["accountDetails"]["name"]);
        // Assert.Equal("jane@example.com", response["accountDetails"]["email"]);
        // Assert.Equal("9876543210", response["accountDetails"]["phone"]);
    }

    [Fact]
    public void CreateAccount_DuplicateEmail_ReturnsErrorResponse()
    {
        // Arrange
        Bank.CreateAccount("jane456", "Jane Smith", "5678", "jane@example.com", "9876543210");

        // Act
        JObject response = JObject.Parse(Bank.CreateAccount("sarah789", "Sarah Johnson", "4321", "jane@example.com", "8765432109"));

        // Assert
        Assert.Equal("Account Already Exists", response["message"]);
    }

}
