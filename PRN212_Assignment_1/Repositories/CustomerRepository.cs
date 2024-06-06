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

        public List<Customer> GetAllCustomers()
        {
            _dbContext = new();
            return _dbContext.Customers.ToList();
        }

        public Customer? GetAccount(string email, string password)
        {
            _dbContext = new();
            return _dbContext.Customers.FirstOrDefault(x => x.EmailAddress == email && x.Password == password);
        }
    }
}
