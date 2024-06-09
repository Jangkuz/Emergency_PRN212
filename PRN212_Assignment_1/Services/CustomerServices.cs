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
            return _repo.GetAll();
        }

        public Customer? CheckLogin(string email, string password)
        {
            return _repo.GetByEmailAndPassword(email, password);
        }

        public List<Customer>? SearchByNameAndEmail(string name, string email)
        {
            return _repo.GetAll().Where(
                delegate (Customer customer)
            {
                return customer.CustomerFullName.ToLower().Contains(name.ToLower()) && customer.EmailAddress.ToLower().Contains(email.ToLower());
            }).ToList();
        }

        public bool DeleteCustomerFromUI(Customer customer) {
            var result = false;
            if(_repo.DeleteCustomer(customer) != null)
            {
                result = true;
            }
            //TODO: try catch
            return false;
        }
    }
}
