
using Bank_ConsoleApp.Authentication;

namespace BankAppTest
{
    public class CreatAccountTest
    {
        [Fact]
        public void ValidFirstName()
        {
            //Arrange
            string fn = "israel";
            //ValidateInfo vi = new ValidateInfo();

            //Act
            var testcase = ValidateInfo.GetFirstname(fn);

            //Assert
            Assert.True(testcase);
        }
        [Fact]
        public void InValidFirstName() 
        {
            //Arrange
            string fn = "israel233";
            //ValidateInfo vi = new ValidateInfo();

            //Act
            var testcase = ValidateInfo.GetFirstname(fn);

            //Assert
            Assert.False(testcase);
        }

        [Fact]
        public void ValidSurName()
        {
            //Arrange
            string surName = "Obakpolor";
            //ValidateInfo vi = new ValidateInfo();

            //Act
            var testcase = ValidateInfo.Surname(surName);

            Assert.True(testcase);
        }

        [Fact]
        public void InValidSurName()
        {
            //Arrange
            string surName = "Obakpolor111";
            //ValidateInfo vi = new ValidateInfo();

            //Act
            var tastecase = ValidateInfo.Surname(surName);

            Assert.False(tastecase);
        }

        [Fact]
        public void ValidateBvn_ShouldValidateBVN()
        {
            //Arrange
            string bvn = "12345678909";
            //ValidateInfo vi = new ValidateInfo();

            //Act
            var isValidBVN = ValidateInfo.GetBvn(bvn);

            Assert.True(isValidBVN);
        }

        [Fact]
        public void InValidateBvn_ShouldValidateBVN()
        {
            //Arrange
            string bvn = "whhjjj45678909";
            //ValidateInfo vi = new ValidateInfo();

            //Act
            var isValidBVN = ValidateInfo.GetBvn(bvn);

            //Assert
            Assert.False(isValidBVN);
        }

        [Fact]
        public void ValidatePhone()
        {
            //Arrange
            string phoneNumber = "12345678909";

            //Act
            var isValidPhoneNumber = ValidateInfo.PhoneNumber(phoneNumber);

            //Assert
            Assert.True(isValidPhoneNumber);
        }

        [Fact]
        public void InValidatePhone()
        {
            //Arrange
            string phoneNumber = "erwrr7890";

            //Act
            var isValidPhoneNumber = ValidateInfo.PhoneNumber(phoneNumber);

            //Assert
            Assert.False(isValidPhoneNumber);
        }

        [Fact]
        public void ValidateEmail()
        {
            string email = "israelObk1@gmail.com";

            var isValidEmail = ValidateInfo.Email(email);

            Assert.True(isValidEmail);
        }

        [Fact]
        public void InValidateEmail()
        {
            string email = "israelObk1@gmail";

            var isValidEmail = ValidateInfo.Email(email);

            Assert.False(isValidEmail);
        }

        //[Fact]
        //public void TestWithdraw()
        //{
        //    // Arrange
        //    var accountNo = "12345633333";
        //    var customer = new customer("John Doe", "Savings", 1000);
        //    Bank.AddCustomer(accountNo, customer);
        //    var amount = 500;
        //    var expectedBalance = 500;

        //    // Act
        //   var validtr = Transaction.Withdraw(amount);

        //    // Assert
        //    Assert.Equal(expectedBalance, customer.GetBalance());
        //}

    }
}