using Bank_ConsoleApp.Authentication;
using Bank_ConsoleApp.Customers;
using Bank_ConsoleApp.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bank_ConsoleApp.Transactions
{
    public class Methods : Logged
    {
        static Dictionary<string, Customer> customerList = CustomerRepository.AllCustomers;
        static List<KeyValuePair<string, string[]>> statements = AccountStatement.statements;

        public static void DepositFunds(decimal amount)
        {
            if (amount > 0)
            {
                Transaction.Deposit(amount);
                Console.Clear();
                Logger.Log($"{amount} naira has been credited to your account.");
            }
            else
            {
                Console.Clear();
                Logger.Log("Transaction failed. Invalid amount");
            }

        }

        public static void Withdraw(decimal amount)
        {
            if (amount > 0)
            {
                decimal bal = Transaction.CheckBalance();
                string accountType = Transaction.GetAccountType();

                if (accountType == "SAVINGS")
                {
                    if (bal - 1000 >= amount)
                    {
                        Transaction.Withdraw(amount);
                        Logger.Log("Withdrawal successfull");
                    }
                    else
                    {
                        Logger.Log("Insufficient Funds");
                    }
                }
                else if (accountType == "CURRENT")
                {
                    if (bal >= amount)
                    {
                        Transaction.Withdraw(amount);
                        Logger.Log("Withdrawal successfull");
                    }
                    else
                    {
                        Logger.Log("Insufficient Funds");
                    }
                }
            }
            else
            {
                Console.Clear();
                Logger.Log("Invalid withdrawal amount.");
            }
        }

        public static void Transfer(decimal amount)
        {
            if (amount < 0)
            {
                Logger.Log("Invalid transfer amount.");
            }
            else
            {
                Logger.Log("Input beneficiary account number");
                string beneficiaryAcc = Console.ReadLine();
                if (beneficiaryAcc == loggedAccount)
                {
                    Logger.Log("You cannot transfer to your account.");
                }
                else
                {
                    decimal balance = loggedCustomer.GetBalance();
                    if (loggedCustomer.GetAccountType() == "SAVINGS")
                    {
                        if (balance - 1000 < amount)
                        {
                            Logger.Log("Insufficient funds");
                            return;
                        }
                    }

                    if (balance >= amount)
                    {

                        bool found = false;

                        foreach (var regUsers in customerList)
                        {
                            if (regUsers.Key == beneficiaryAcc)
                            {
                                decimal currentBalance = balance - amount;
                                loggedCustomer.SetBalance(currentBalance);

                                decimal beneBalance = regUsers.Value.GetBalance() + amount;
                                regUsers.Value.SetBalance(beneBalance);

                                string[] values = { regUsers.Value.GetFullname(), amount.ToString(), beneficiaryAcc, regUsers.Value.GetAccountType(), currentBalance.ToString(), "CREDIT" };
                                statements.Add(new KeyValuePair<string, string[]>(beneficiaryAcc, values));

                                string[] value = { loggedCustomer.GetFullname(), amount.ToString(), loggedAccount, loggedCustomer.GetAccountType(), loggedCustomer.GetBalance().ToString(), "DEBIT" };
                                statements.Add(new KeyValuePair<string, string[]>(loggedAccount, value));


                                found = true;
                                break;
                            }
                        }
                        if (found)
                        {
                            Logger.Log("Transfer successful");
                        }
                        else
                        {
                            Logger.Log("Invalid recepient account");
                        }
                    }
                    else
                    {
                        Logger.Log("Insufficient balance");
                    }


                }
            }
        }


    }
}
