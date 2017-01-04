using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperSample
{
    public class ClientRepository
    {
        private readonly IEnumerable<CustomerModel> _customers;
        
        public ClientRepository(IEnumerable<CustomerModel> customers)
        {
            _customers = customers;
            Mapper.Initialize(c => c.AddProfile(new CustomMap()));
        }

        public ClientRepository()
        {
            _customers = new List<CustomerModel>();
        }

        public Customer GetCustomer()
        {
            var customer = _customers.FirstOrDefault();
            //Define the mapping 
            //Mapper.CreateMap<CustomerModel, Customer>();
            //Execute the mapping 
            var clientViewModel = Mapper.DynamicMap<CustomerModel,Customer>(customer);
            //Return a viewmodel 
            return clientViewModel;
        }
    }
}
