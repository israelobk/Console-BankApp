using Bank_ConsoleApp.Customers;
using Bank_ConsoleApp.Tools;
using Bank_ConsoleApp.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_ConsoleApp.Authentication
{
    public class CreateAccount : CustomerRepository
    {
        public static List<KeyValuePair<string, string[]>> statements = AccountStatement.statements;

        public static void CustomerDetails() 
        {
           
            Console.WriteLine("Input your Firstname");
            string firstname = Console.ReadLine();
            //if (ValidateInfo.GetFirstname(firstname) == false)
            //{
            //    throw new Exception("the god named E");
            //}

            //ValidateInfo UserInputValidation = new ValidateInfo();

            while (ValidateInfo.GetFirstname(firstname) == false)
            {
                Console.WriteLine("Incorrect Name Format, No Numerical Figure");
                firstname = Console.ReadLine();
            }

            Console.WriteLine("Input your Surname");
            string lastname = Console.ReadLine();
            while (ValidateInfo.Surname(lastname) == false)
            {
                Console.WriteLine("Incorrect Name Format, No Numerical Figure");
                lastname = Console.ReadLine();
            }

            Console.WriteLine("Input your BVN");
            string bvn = Console.ReadLine();
            while (ValidateInfo.GetBvn(bvn) == false)
            {
                Console.WriteLine("Incorrect BVN, 11 Digits is Required");
                bvn = Console.ReadLine();
            }

            Console.WriteLine("Input your Phone number");
            string phoneNumber = Console.ReadLine();
            while (ValidateInfo.PhoneNumber(phoneNumber) == false)
            {
                Console.WriteLine("Incorrect Phone Number, 11 Digits is Required");
                phoneNumber = Console.ReadLine();
            }

            Console.WriteLine("Input your Email");
            string email = Console.ReadLine();
            while (ValidateInfo.Email(email) == false)
            {
                Console.WriteLine("Please enter the right name");
                email = Console.ReadLine();
            }

            Console.WriteLine("Input your Password");
            string password = Console.ReadLine();


            Console.WriteLine("What type of account do you want?");
            Console.WriteLine("Press S for Savings and C for Current");
            string AccountType = Console.ReadLine();

            switch (AccountType)
            {
                case "S" or "s":
                    AccountType = "SAVINGS";
                    break;

                case "C" or "c":
                    AccountType = "CURRENT";
                    break;
            }
            Console.Clear();

            bool found = false;
            foreach (var registeredUsers in AllCustomers)
            {
                Customer user = registeredUsers.Value;
                if (user.GetBVN() == bvn)
                {
                    if (user.GetAccountType() == AccountType)
                    {
                        Logger.Log($"You already have a {AccountType} account");
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                Customer customer = new Customer(firstname, lastname, phoneNumber, email, AccountType, password, bvn);
                string accountNumber = GenerateAccountNo.GenerateNewAccountNumber();

                AddCustomer(accountNumber, customer);

                string[] values = { firstname + " " + lastname, "0", accountNumber, AccountType, "0", "New Account" };
                statements.Add(new KeyValuePair<string, string[]>(accountNumber, values));

                Console.WriteLine("Account created successfully. Your account number is " + accountNumber);
            }

            Login.UserLogin();

        }

    }
}
