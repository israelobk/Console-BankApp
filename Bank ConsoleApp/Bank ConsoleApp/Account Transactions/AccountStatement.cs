using Bank_ConsoleApp.Authentication;
using Bank_ConsoleApp.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_ConsoleApp.Transactions
{
    public class AccountStatement : Logged
    {
        public static List<KeyValuePair<string, string[]>> statements = new List<KeyValuePair<string, string[]>>();
        public static string customerInfo = @"C:\Users\Decagon\source\repos\Tasks\Bank ConsoleApp\JSON\transaction.json";
        //static string customersTransaction = JsonConvert.SerializeObject(statements);

        static void PrintTable()
        {
            Console.Clear();
            Logger.Log("---------------------------------- ACCOUNT STATEMENT ---------------------------------");
            Logger.Log("|   Customer Name   | Amount | Account Number | Account Type | Balance |   Remarks   |");
            Logger.Log("--------------------------------------------------------------------------------------");


        }
        public static void PrintAccountStatement()
        {
            PrintTable();
            SaveToFileAsync();
            foreach (var item in statements)
            {
                if (item.Key == loggedAccount)
                {
                    string[] value = item.Value;
                    Logger.Log(value[0] + "   |   " + value[1] + "   |   " + value[2] + "   |   " + value[3] + "   |   " + value[4] + "   |   " + value[5]);
                }
            }
        }

        public static async Task SaveToFileAsync()
        {
            await Task.Run(() =>
            {
                    string customersTransaction = JsonConvert.SerializeObject(statements);
                    File.WriteAllText(customerInfo, customersTransaction);
            });

        }

    }
}
