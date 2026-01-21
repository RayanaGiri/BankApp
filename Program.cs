using System;
class Program
{
    // variable to store account balance
    static double balance = 0.0;
    // PIN for login
    static string correctPin = "1234";
    static void Main(string[] args)
    {
        // Login system with maximum 3 attempts
        int attempts = 0;
        // loggedIn flag is false initially
        bool loggedIn = false;
        // loop runs until attempts are less than 3 and user is not logged in
        while (attempts < 3 && loggedIn == false)
        {
            Console.Write("Enter PIN: ");
            string enteredPin = Console.ReadLine();
            // checking if entered PIN matches correct PIN
            if (enteredPin == correctPin)
            {
                loggedIn = true; // login successful
                Console.WriteLine("Login successful!");
            }
            else
            {
                attempts++; // increase attempts on wrong PIN
                Console.WriteLine($"Incorrect PIN. Attempts remaining: {3 - attempts}");
            }
        }
        // if login fails after 3 attempts
        if (!loggedIn)
        {
            Console.WriteLine("Too many failed attempts. System locked.");
            return; // exit the program
        }
        // Main banking menu loop
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nBanking Menu:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Balance Inquiry");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            // reading user choice
            int choice;
            bool validChoice = int.TryParse(Console.ReadLine(), out choice);
            // checking if input is valid number
            if (!validChoice)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }
            // switch statement to handle user choice
            switch (choice)
            {
                case 1:
                    Deposit();
                    break;

                case 2:
                    Withdraw();
                    break;
                case 3:
                    CheckBalance();
                    break;
                case 4:
                    exit = true; // exiting loop
                    Console.WriteLine("************Thank you*************");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
    // function to deposit money
    static void Deposit()
    {
        Console.Write("Enter amount to deposit: ");
        double amount;

        // validating input and checking for positive value
        if (double.TryParse(Console.ReadLine(), out amount) && amount > 0)
        {
            balance += amount; // add amount to balance
            Console.WriteLine($"Deposit successful. Current Balance: Rs. {balance}");
        }
        else
        {
            Console.WriteLine("Invalid amount. Deposit must be positive.");
        }
    }
    // function to withdraw money
    static void Withdraw()
    {
        Console.Write("Enter amount to withdraw: ");
        double amount;

        // validating input and checking for positive value
        if (double.TryParse(Console.ReadLine(), out amount) && amount > 0)
        {
            // checking if balance is sufficient
            if (amount <= balance)
            {
                balance -= amount; // subtract amount from balance
                Console.WriteLine($"Withdrawal successful. Current Balance: Rs. {balance}");
            }
            else
            {
                Console.WriteLine($"Insufficient balance your balance is only Rs. {balance}. \n Withdrawal denied.");
            }
        }
        else
        {
            Console.WriteLine("Invalid amount. Withdrawal must be positive.");
        }
    }
    // function to check balance
    static void CheckBalance()
    {
        Console.WriteLine($"Your current balance is: Rs. {balance}");
    }
}