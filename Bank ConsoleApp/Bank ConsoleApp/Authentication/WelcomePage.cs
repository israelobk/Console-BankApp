using Bank_ConsoleApp.Tools;
using Bank_ConsoleApp.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bank_ConsoleApp.Authentication
{
    public class WelcomePage
    {
        public void WelcomeUser() 
        {
            Console.WriteLine("|\\    |");
            Console.WriteLine("| \\   |");
            Console.WriteLine("|  \\  |");
            Console.WriteLine("|   \\ |");
            Console.WriteLine("|    \\|WELCOME TO NIGER BANK!\n");
            Console.WriteLine(" Press 1 For Account Opening\n Press 2 to Login ");
            
            string userInput = Console.ReadLine();
            switch (userInput)
            {
              
                case "1":
                    //try
                    //{
                     CreateAccount.CustomerDetails();
                    //}
                    //catch 
                    ////{
                    //    Console.WriteLine("account creation failed");
                    //}
                break;

                case "2":
                    Login.UserLogin();
                break;
            }
        }

        public static void TransactionOptions()
        {
            Console.WriteLine("\nPress 1 to Deposit\nPress 2 to Withdraw");
            Console.WriteLine("Press 3 to Transfer\nPress 4 to Print Account Statement");
            Console.WriteLine("Press 5 to Check balance\nPress 6 to Create another Account");
            Console.WriteLine("Press 7 to Login to another Account\nPress 8 to Exit");


            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Logger.Log("Input amount to deposit");
                    string inputAmount = Console.ReadLine();

                    decimal amount = Convert.ToDecimal(inputAmount);

                    Methods.DepositFunds(amount);
                    TransactionOptions();
                    break;

                case "2":
                    Logger.Log("Input amount to withdraw");
                    string inputWithrawAmount = Console.ReadLine();
                    decimal amountToWithdaw = Convert.ToDecimal(inputWithrawAmount);

                    Methods.Withdraw(amountToWithdaw);
                    TransactionOptions();
                    break;

                case "3":
                    Logger.Log("Input amount to transfer");
                    decimal amountt = decimal.Parse(Console.ReadLine());
                    Methods.Transfer(amountt);
                    TransactionOptions();
                    break;

                case "4":
                    AccountStatement.PrintAccountStatement();
                    TransactionOptions();
                    break;
                case "5":
                    decimal bal = Transaction.CheckBalance();
                    Console.Clear();
                    Logger.Log($"Your current balance is {bal}");
                    TransactionOptions();
                    break;

                case "6":
                    CreateAccount.CustomerDetails();
                    // Options();
                    break;

                case "7":
                    Login.UserLogin();
                    break;
                case "8":

                    break;
            }
        }

    }
}
