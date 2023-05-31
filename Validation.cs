namespace BankingApp;

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
