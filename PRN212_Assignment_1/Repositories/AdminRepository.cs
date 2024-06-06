using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AdminRepository
    {
        private FuminiHotelManagementContext _dbContext;
        public bool CheckLogin(string email, string password)
        {
            _dbContext = new();
            bool result = false;
            var adminModel = _dbContext.Admin;
            if (adminModel.Email.ToLower().Equals(email.ToLower()) && adminModel.Password.ToLower().Equals(password.ToLower()))
            {
                result = true;
            }

            return result;
        }
    }
}
