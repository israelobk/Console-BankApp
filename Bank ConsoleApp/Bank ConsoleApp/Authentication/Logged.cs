using Bank_ConsoleApp.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_ConsoleApp.Authentication
{
    public class Logged
    {
        public static string loggedAccount { get; set; }

        public static Customer loggedCustomer { get; set; }
    }
}
