using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_ConsoleApp.Customers
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set;  }
        public string Password { get; set; }
        public string BVN { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }



        public Customer(string firstName, string lastName, string phoneNumber, string email,
       string accountType, string password, string bvn)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Balance = 0;
            this.AccountType = accountType;
            this.Password = password;
            this.BVN = bvn;
        }

        public string GetFirstname()
        {
            return FirstName;
        }
        public string GetFullname()
        {
            return GetFirstname() + " " + GetLastname();
        }
        public void SetBalance(decimal amount)
        {
            Balance = amount;
        }

        public string GetLastname()
        {
            return LastName;
        }

        public string GetPhoneNumber()
        {
            return PhoneNumber;
        }

        public string GetEmail()
        {
            return Email;
        }

        public string GetAccountType()
        {
            return AccountType;
        }

        public string GetPassword()
        {
            return Password;
        }
        public decimal GetBalance()
        {
            return Balance;
        }

        public string GetBVN()
        {
            return BVN;
        }

    }
}

