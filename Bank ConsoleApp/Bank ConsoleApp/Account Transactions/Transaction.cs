using Bank_ConsoleApp.Authentication;
using Bank_ConsoleApp.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_ConsoleApp.Transactions
{
    public class Transaction : Logged
    {
        static List<KeyValuePair<string, string[]>> statements = AccountStatement.statements;

        static Dictionary<string, Customer> customerList = CustomerRepository.AllCustomers;



        public static void Deposit( decimal amount)
        {

            foreach (var item in customerList)
            {
                if (item.Key == loggedAccount)
                {
                    Customer customer = item.Value;
                    decimal balance = customer.GetBalance();
                    decimal currentBalance = balance + amount;
                    customer.SetBalance(currentBalance);

                    string[] values = { customer.GetFullname(), amount.ToString(), loggedAccount, customer.GetAccountType(), currentBalance.ToString(), "CREDIT" };

                    statements.Add(new KeyValuePair<string, string[]>(loggedAccount, values));


                    break;
                }
            }
        }

        public static void Withdraw(decimal amount)
        {
            foreach (var item in customerList)
            {
                if (item.Key == loggedAccount)
                {
                    Customer customer = item.Value;
                    decimal balance = customer.GetBalance();
                    decimal currentBalance = balance - amount;
                    customer.SetBalance(currentBalance);

                    string[] values = { customer.GetFullname(), amount.ToString(), loggedAccount, customer.GetAccountType(), currentBalance.ToString(), "DEBIT" };

                    statements.Add(new KeyValuePair<string, string[]>(loggedAccount, values));

                    break;
                }
            }
        }

        public string Transfer()
        {
            decimal bal = Transaction.CheckBalance();
            Console.WriteLine("Input the account you want to transfer to");
            Console.WriteLine("Input the amount you want to transfer");
            decimal AmountToTransfer = Convert.ToDecimal(Console.ReadLine());
            if (bal > AmountToTransfer)
            {
                bal -= AmountToTransfer;
            }
            return "insuufficient balance";
        }

        public static decimal CheckBalance()
        {
            decimal bal = 0;
            foreach (var item in customerList)
            {
                if (item.Key == loggedAccount)
                {
                    Customer customer = item.Value;
                    bal = customer.GetBalance();
                    break;
                }
            }
            return bal;
        }

        public void GetStatementOfAccount()
        {

        }

        public static string GetAccountType()
        {
            string accountType = "";
            foreach (var item in customerList)
            {
                if (item.Key == loggedAccount)
                {
                    Customer customer = item.Value;
                    accountType = customer.GetAccountType();
                    break;
                }
            }
            return accountType;
        }

    }
}
