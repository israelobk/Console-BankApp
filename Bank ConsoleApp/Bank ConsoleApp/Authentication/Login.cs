using Bank_ConsoleApp.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_ConsoleApp.Authentication
{
    public class Login : Logged
    {
        public static void UserLogin()
        {
            Console.WriteLine("Enter your account number to login");
            string accountNo = Console.ReadLine();

            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();

            if (accountNo == "" || password == "")
            {
                Console.WriteLine("All fields are required. Try again");
                UserLogin();
            }
            else
            {
                Customer foundCustomer = null;

                var customerList = CustomerRepository.AllCustomers;
                bool found = false;
                foreach (var item in customerList)
                {
                    if (item.Key == accountNo)
                    {
                        foundCustomer = item.Value;
                        string passwd = foundCustomer.GetPassword();

                        if (password == passwd)
                        {
                            found = true;
                        }
                    }
                }

                if (found)
                {
                    loggedAccount = accountNo;
                    loggedCustomer = foundCustomer;
                    Console.WriteLine("Login successful");
                    WelcomePage.TransactionOptions();

                }
                else
                {
                    Console.WriteLine("Invalid login Details. Try again");
                    UserLogin();
                }
            }

        }
    }

    }