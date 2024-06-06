using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerServices
    {
        private CustomerRepository _repo = new();

        public List<Customer> GetCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public Customer? CheckLogin(string email, string password)
        {
            return _repo.GetAccount(email, password);
        }
    }
}
