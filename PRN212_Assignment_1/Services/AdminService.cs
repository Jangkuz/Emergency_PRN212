using Repositories;

namespace Services
{
    public class AdminService
    {
        private AdminRepository _repo;

        public AdminService()
        {
            _repo = AdminRepository.GetInstance();
        }

        public bool CheckLogin(string username, string password)
        {
            return _repo.CheckLogin(username, password);
        }
    }
}
