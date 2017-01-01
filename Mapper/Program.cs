using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sample
            var customerModel = new CustomerModel()
            {
                ClientId = 1,
                Name = "Julio",
                LastName = "Avellaneda",
                Email = "julito_gtu@hotmail.com",
                CreationDate = DateTime.Now.ToString(),
                Password = "123456"
            };

            var customers = new List<CustomerModel>();
            customers.Add(customerModel);

            var repository =  new ClientRepository(customers);

            var customer = repository.GetCustomer();
        }
    }
}
