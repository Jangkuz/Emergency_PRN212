using Repositories.Entities;

namespace Repositories
{
    public class AdminRepository
    {
        private FuminiHotelManagementContext? _dbContext;

        private static AdminRepository? _instance;
        private AdminRepository()
        {
        }
        public static AdminRepository GetInstance()
        {
            if (AdminRepository._instance == null)
            {
                _instance = new AdminRepository();
            }
            return AdminRepository._instance;
        }

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
