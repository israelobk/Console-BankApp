using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bank_ConsoleApp.Authentication
{
    public class ValidateInfo
    {
        public static bool GetFirstname(string firstName)
        {
            return !string.IsNullOrEmpty(firstName) && Regex.IsMatch(firstName, @"^[a-zA-Z]+$");
        }
        public static bool Surname(string lastName)
        {
            return !string.IsNullOrEmpty(lastName) && Regex.IsMatch(lastName, @"^[a-zA-Z]+$");
        }

        public static bool GetBvn(string BVN)
        {
            return !string.IsNullOrEmpty(BVN) && Regex.IsMatch(BVN, @"^[0-9]{11}$");
        }
        public static bool PhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrEmpty(phoneNumber) && Regex.IsMatch(phoneNumber, @"^[0-9]{11}$");
        }
        public static bool Email(string email)
        {
            return !string.IsNullOrEmpty(email) && Regex.IsMatch(email, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$");
        }
    }
}
