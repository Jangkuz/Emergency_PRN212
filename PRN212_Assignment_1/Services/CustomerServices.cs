using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Entities;

namespace Services
{
    public class CustomerServices
    {
        //TODO: add const string for return result
        private CustomerRepository _repo;

        public CustomerServices()
        {
            _repo = CustomerRepository.GetInstance();
        }

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
            return _repo.GetAll().Where(c => c.CustomerFullName!.ToLower().Contains(name.ToLower()) && c.EmailAddress.ToLower().Contains(email.ToLower())).ToList();
        }

        public bool DeleteCustomerFromUI(Customer customer)
        {
            var result = false;
            if (_repo.DeleteCustomer(customer) != null)
            {
                result = true;
            }
            //TODO: try catch
            return result;
        }

        public bool SetCustomerStatusAsDelete(Customer customer)
        {
            var result = false;
            customer.CustomerStatus = 2;
            if (_repo.UpdateCustomer(customer) != null)
            {
                result = true;
            }
            //TODO: try catch
            return result;
        }
        public string UpdateCustomerFromUi(Customer customer)
        {
            string result = string.Empty;
            var customerModel = _repo.UpdateCustomer(customer);

            if (customerModel == null)
            {
                result = "Customer id don't exist";
            }
            else
            {
                result = "Update successful";
            }

            return result;
        }
        public string CreateCustomerFromUi(Customer customer)
        {
            string result = string.Empty;
            try
            {

                var cusModel = _repo.CreateCustomer(customer);
                if (cusModel != null)
                {
                    result = "Customer add cuccessful";
                }

                return result;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && ex.InnerException is SqlException sqlEx)
                {
                    if (sqlEx.Number == 2627 || sqlEx.Number == 2601)
                    {
                        result = "A book with the same ID already exists";
                        return result;
                    }
                }
                result = "An error occurred while adding the book.";
                return result;
            }
        }
    }
}
