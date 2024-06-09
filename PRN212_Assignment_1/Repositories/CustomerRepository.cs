using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository
    {
        private FuminiHotelManagementContext _dbContext;

        public List<Customer> GetAll()
        {
            _dbContext = new();
            return _dbContext.Customers.ToList();
        }

        public Customer? GetByEmailAndPassword(string email, string password)
        {
            _dbContext = new();
            return _dbContext.Customers.FirstOrDefault(x => x.EmailAddress == email && x.Password == password);
        }

        public Customer DeleteCustomer(Customer customer)
        {
            _dbContext = new();
            _dbContext.Remove(customer);
            _dbContext.SaveChanges();
            return customer;
        }
    }
}
