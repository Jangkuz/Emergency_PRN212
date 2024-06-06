using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AdminService
    {
        private AdminRepository _repo = new();
        public bool CheckLogin(string username, string password)
        {
            return _repo.CheckLogin(username, password);
        }
    }
}
