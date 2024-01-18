


using Newtonsoft.Json;

namespace Bank_ConsoleApp.Customers
{
    public class CustomerRepository
    {
        public static Dictionary<string, Customer> AllCustomers = new Dictionary<string, Customer>();
        public static string customerInfo = @"C:\Users\Decagon\source\repos\Tasks\Bank ConsoleApp\JSON\bank.json";
        // FileStream fs = File.Create(customerInfo);
      // static string customerss = JsonConvert.SerializeObject(AllCustomers);       

        public static void AddCustomer(string accountNo, Customer customer)
        {
            AllCustomers.Add(accountNo, customer);
            SaveToFileAsync();
        }
        public static async Task SaveToFileAsync()
        {
            await Task.Run(() =>
            {
                string customerss = JsonConvert.SerializeObject(AllCustomers);
                File.WriteAllText(customerInfo, customerss);
            });

        }


        public static void ReadAllText()
        {
            string jsonFile = File.ReadAllText(customerInfo);
            var customerSavedFile = JsonConvert.DeserializeObject<Dictionary<string, Customer>>(jsonFile);

            try
            {
                if (customerSavedFile != null)
                {
                    AllCustomers = customerSavedFile;
                }

                if (customerSavedFile.Count > 0)
                {
                    Console.WriteLine("Customer data loaded successfully");
                }
                else
                {
                    Console.WriteLine("No customer data found in the file");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"sorry an Error Occured {ex.Message}");
            }

        }


    }
}
