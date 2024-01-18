using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_ConsoleApp.Authentication;
using Bank_ConsoleApp.Customers;

namespace BankAppTest
{
    public class TransactionTest
    {
        [Fact]
        public void TestDeposit()
        {
            // Arrange
            List<Customer> customerList = new List<Customer>();


           // new Customer { Fullname = "John Doe", AccountNumber = "1234567890", AccountType = "Savings", Balance = 500m };

            string loggedAccount = "1234567890";
            decimal amount = 200m;

            // Act
           // Deposit(amount);

            // Assert
            Assert.True(customerList[0].GetBalance() == 700m);
           // Assert.Contains("CREDIT", statements[0].Value);
        }
    }
}
