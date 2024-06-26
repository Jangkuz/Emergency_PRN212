﻿using Repositories.Entities;

namespace Repositories
{
    public class CustomerRepository
    {
        private FuminiHotelManagementContext? _dbContext;

        private static CustomerRepository? _instance;
        private CustomerRepository()
        {
        }
        public static CustomerRepository GetInstance()
        {
            if (CustomerRepository._instance == null)
            {
                _instance = new CustomerRepository();
            }
            return CustomerRepository._instance;
        }

        public List<Customer> GetAll()
        {
            _dbContext = new();
            return _dbContext!.Customers.ToList();
        }

        public Customer? GetByEmailAndPassword(string email, string password)
        {
            _dbContext = new();
            return _dbContext!.Customers.FirstOrDefault(x => x.EmailAddress == email && x.Password == password);
        }

        public Customer DeleteCustomer(Customer customer)
        {
            _dbContext = new();
            _dbContext!.Customers.Remove(customer);
            _dbContext.SaveChanges();
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            //var cus = _dbContext.Customers.FirstOrDefault(x => x.CustomerId == customer.CustomerId);
            //if (cus != null)
            //{
            _dbContext = new();
            _dbContext!.Customers.Update(customer);
            _dbContext.SaveChanges();
            //}
            return customer;
        }

        public Customer CreateCustomer(Customer customer)
        {
            _dbContext = new();
            _dbContext!.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }
    }
}
